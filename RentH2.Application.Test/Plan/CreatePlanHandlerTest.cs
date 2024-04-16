using Bogus;
using MediatR;
using Moq;
using RentH2.Application.CQRSPlan.Commands;
using RentH2.Application.CQRSPlan.Handlers;
using RentH2.Application.Test.Utility;
using RentH2.Domain.Models;
using RentH2.Domain.Utility;
using RentH2.Domain.Entities;
using RentH2.Infrastructure.Repositories.Interfaces;

namespace RentH2.Application.Test.PlanTest
{
    public class CreatePlanHandlerTest : ConfigBase
    {

        private readonly Faker _faker;
        private readonly PlanModel _planModel;
        private CreatePlanHandler _createPlanHandler;
        private CreatePlanCommand _createPlanCommand;
        private readonly Mock<IPlanGateway> _planGatewayMock;
        private readonly Mock<IMediator> _mediator;
        private readonly CancellationToken _cancellationToken;

        public CreatePlanHandlerTest()
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

            _mediator = new Mock<IMediator>();
            _cancellationToken = new CancellationToken();
            
            _planGatewayMock = new Mock<IPlanGateway>();
            _createPlanHandler = new CreatePlanHandler(_planGatewayMock.Object, _mapper, _mediator.Object);
        }

        [Fact]
        public async void ShouldAddPlan()
        {
            _createPlanCommand = new CreatePlanCommand(_planModel);
            var plan = _mapper.Map<Plan>(_createPlanCommand.planModel);
            _planGatewayMock.Setup(r => r.CreateAsync(It.IsAny<Plan>())).ReturnsAsync(plan);

            _createPlanHandler.Handle(_createPlanCommand, _cancellationToken);

            _planGatewayMock
                .Verify(r => r.CreateAsync(
                    It.Is<Plan>(
                        c => c.Description == plan.Description &&
                        c.TotalDays == plan.TotalDays
                    )
            ));

            _planGatewayMock.Verify(r => r.CreateAsync(
                It.IsAny<Plan>()), Times.Once
            );
        }
    }
}