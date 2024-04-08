using Bogus;
using Bogus.Extensions.UnitedKingdom;
using Moq;
using RentH2.Application.CQRSPlan.Handlers;
using RentH2.Application.Test.Utility;
using RentH2.Common.Models;
using RentH2.Common.Utility;
using RentH2.Domain.Entities;
using RentH2.Infrastructure.Repositories.Interfaces;
using RentH2.Application.CQRSPlan.Queries;

namespace RentH2.Application.Test.PlanTest
{
    public class GetPlanListHandlerTest : ConfigBase
    {
        private readonly Faker _faker;
        private readonly PlanModel _planModel;
        private GetPlanListHandler _getPlanListHandler;
        private GetPlanListQuery _getPlanListQuery;
        private readonly Mock<IPlanGateway> _planGatewayMock;
        private readonly CancellationToken _cancellationToken;

        public GetPlanListHandlerTest()
        {
            _faker = new Faker();
            _planModel = new PlanModel
            {
                Description = _faker.Random.Words(100)[..100],
                TotalDays = 7,
                DailyPrice = 10,
                TotalPrice = 70,
                FineAntecipated = 0.5,
                FineDelayed = 50,
                Status = RentStatus.Available
            };
            _cancellationToken = new CancellationToken();
            _planGatewayMock = new Mock<IPlanGateway>();
            _getPlanListHandler = new GetPlanListHandler(_planGatewayMock.Object, _mapper);
        }

        [Fact]
        public async void ShouldGetAllPlan()
        {
            _getPlanListQuery = new GetPlanListQuery();
            var plan = _mapper.Map<Plan>(_planModel);
            List<Plan> result = [plan];
            _planGatewayMock.Setup(r => r.GetAsync()).ReturnsAsync(result);

            _getPlanListHandler.Handle(_getPlanListQuery, _cancellationToken);

            _planGatewayMock.Verify(r => r.GetAsync(), Times.Once);
        }
    }
}