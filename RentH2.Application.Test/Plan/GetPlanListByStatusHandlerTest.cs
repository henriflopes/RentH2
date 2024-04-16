using Bogus;
using Moq;
using RentH2.Application.CQRSPlan.Handlers;
using RentH2.Application.Test.Utility;
using RentH2.Domain.Models;
using RentH2.Domain.Utility;
using RentH2.Domain.Entities;
using RentH2.Infrastructure.Repositories.Interfaces;
using RentH2.Application.CQRSPlan.Queries;

namespace RentH2.Application.Test.PlanTest
{
    public class GetPlanListByStatusHandlerTest : ConfigBase
    {
        private readonly Faker _faker;
        private readonly PlanModel _planModel;
        private GetPlanListByStatusHandler _getPlanListByStatusHandler;
        private GetPlanListByStatusQuery _getPlanListByStatusQuery;
        private readonly Mock<IPlanGateway> _planGatewayMock;
        private readonly CancellationToken _cancellationToken;

        public GetPlanListByStatusHandlerTest()
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
            _getPlanListByStatusHandler = new GetPlanListByStatusHandler(_planGatewayMock.Object, _mapper);
        }

        [Fact]
        public async void ShouldGetAllPlanByStatus()
        {
            _getPlanListByStatusQuery = new GetPlanListByStatusQuery([RentStatus.Available, RentStatus.Deleted]);
            var plan = _mapper.Map<Plan>(_planModel);
            List<Plan> result = [plan];
            _planGatewayMock.Setup(r => r.GetAllByStatusAsync(It.IsAny<List<string>>())).ReturnsAsync(result);

            _getPlanListByStatusHandler.Handle(_getPlanListByStatusQuery, _cancellationToken);

            _planGatewayMock.Verify(r => r.GetAllByStatusAsync(
                It.IsAny<List<string>>()), Times.Once
            );
        }
    }
}