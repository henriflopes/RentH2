using Bogus;
using MediatR;
using Moq;
using RentH2.Application.CQRSPlan.Commands;
using RentH2.Application.CQRSPlan.Handlers;
using RentH2.Application.Test.Utility;
using RentH2.Common.Models;
using RentH2.Common.Utility;
using RentH2.Domain.Entities;
using RentH2.Domain.Entities.Validators;
using RentH2.Domain.Test._Builders;
using RentH2.Domain.Test._Utility;
using RentH2.Infrastructure.Repositories.Interfaces;
using RentH2.Domain.Base;

namespace RentH2.Application.Test.PlanTest
{
    public class UpdatePlanHandlerTest : ConfigBase
    {

        private readonly Faker _faker;
        private readonly PlanModel _planModel;
        private UpdatePlanHandler _updatePlanHandler;
        private UpdatePlanCommand _updatePlanCommand;
        private readonly Mock<IPlanGateway> _planGatewayMock;
        private readonly Mock<IMediator> _mediator;
        private readonly CancellationToken _cancellationToken;

        public UpdatePlanHandlerTest()
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
            _updatePlanHandler = new UpdatePlanHandler(_planGatewayMock.Object, _mapper);
        }

        [Fact]
        public async void ShouldUpdatePlan()
        {
            _updatePlanCommand = new UpdatePlanCommand(_planModel);
            var plan = PlanBuilder.New().Build();
            _planGatewayMock.Setup(r => r.GetAsync(_planModel.Id)).ReturnsAsync(plan);
            _planGatewayMock.Setup(r => r.UpdateAsync(_mapper.Map<Plan>(_planModel))).ReturnsAsync(plan);

            _updatePlanHandler.Handle(_updatePlanCommand, _cancellationToken);

            Assert.Equal(_planModel.Description, plan.Description);
            Assert.Equal(_planModel.TotalDays, plan.TotalDays);
            Assert.Equal(_planModel.DailyPrice, plan.DailyPrice);
            Assert.Equal(_planModel.TotalPrice, plan.TotalPrice);
            Assert.Equal(_planModel.FineAntecipated, plan.FineAntecipated);
            Assert.Equal(_planModel.FineDelayed, plan.FineDelayed);
            Assert.Equal(_planModel.Status, plan.Status);
        }

        [Fact]
        public async void ShouldNotUpdatePlanWithInvalidId()
        {
            _updatePlanCommand = new UpdatePlanCommand(_planModel);
            var plan = PlanBuilder.New().Build();
            _planGatewayMock.Setup(r => r.GetAsync(_planModel.Id)).ReturnsAsync((Plan)null);
            _planGatewayMock.Setup(r => r.UpdateAsync(_mapper.Map<Plan>(_planModel))).ReturnsAsync(plan);

            (await Assert.ThrowsAsync<ExceptionDomain>(() => _updatePlanHandler.Handle(_updatePlanCommand, _cancellationToken)))
                .WithMessage(Resources.PlanNotFound);

            _planGatewayMock.Verify(r => r.UpdateAsync(It.IsAny<Plan>()), Times.Never);
        }
    }
}