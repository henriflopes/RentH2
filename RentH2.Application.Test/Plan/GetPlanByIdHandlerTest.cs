using Bogus;
using Moq;
using RentH2.Application.CQRSPlan.Handlers;
using RentH2.Application.Test.Utility;
using RentH2.Domain.Models;
using RentH2.Domain.Utility;
using RentH2.Domain.Entities;
using RentH2.Infrastructure.Repositories.Interfaces;
using RentH2.Application.CQRSPlan.Queries;
using RentH2.Domain.Entities.Validators;
using RentH2.Domain.Base;
using RentH2.Domain.Test._Utility;

namespace RentH2.Application.Test.PlanTest
{
    public class GetPlanByIdHandlerTest : ConfigBase
    {
        private readonly Faker _faker;
        private readonly PlanModel _planModel;
        private GetPlanByIdHandler _getPlanByIdHandler;
        private GetPlanByIdQuery _getPlanByIdQuery;
        private readonly Mock<IPlanGateway> _planGatewayMock;
        private readonly CancellationToken _cancellationToken;

        public GetPlanByIdHandlerTest()
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
            _getPlanByIdHandler = new GetPlanByIdHandler(_planGatewayMock.Object, _mapper);
        }

        [Fact]
        public async void ShouldFindPlanById()
        {
            _getPlanByIdQuery = new GetPlanByIdQuery(_planModel.Id);
            var plan = _mapper.Map<Plan>(_planModel);
            _planGatewayMock.Setup(r => r.GetAsync(It.IsAny<string>())).ReturnsAsync(plan);

            _getPlanByIdHandler.Handle(_getPlanByIdQuery, _cancellationToken);

            _planGatewayMock.Verify(r => r.GetAsync(
                It.IsAny<string>()), Times.Once
            );
        }

        [Fact]
        public async void ShouldNotFindPlanByInvalidId()
        {
            _getPlanByIdQuery = new GetPlanByIdQuery(_planModel.Id);
            var plan = _mapper.Map<Plan>(_planModel);
            _planGatewayMock.Setup(r => r.GetAsync(It.IsAny<string>())).ReturnsAsync((Plan)null);

            (await Assert.ThrowsAsync<ExceptionDomain>(() => _getPlanByIdHandler.Handle(_getPlanByIdQuery, _cancellationToken)))
                .WithMessage(Resources.PlanNotFound);

            _planGatewayMock.Verify(r => r.GetAsync(
                It.IsAny<string>()), Times.Once
            );
        }
    }
}