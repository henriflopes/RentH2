using Bogus;
using MediatR;
using Moq;
using RentH2.Application.CQRSRent.Commands;
using RentH2.Application.CQRSRent.Handlers;
using RentH2.Application.Test.Utility;
using RentH2.Common.Models;
using RentH2.Common.Utility;
using RentH2.Domain.Entities;
using RentH2.Domain.Entities.Validators;
using RentH2.Domain.Test._Builders;
using RentH2.Domain.Test._Utility;
using RentH2.Infrastructure.Repositories.Interfaces;
using RentH2.Domain.Base;

namespace RentH2.Application.Test.RentTest
{
    public class UpdateRentHandlerTest : ConfigBase
    {

        private readonly Faker _faker;
        private readonly RentModel _rentModel;
        private UpdateRentHandler _updateRentHandler;
        private UpdateRentCommand _updateRentCommand;
        private readonly Mock<IRentGateway> _rentGatewayMock;
        private readonly Mock<IMediator> _mediator;
        private readonly CancellationToken _cancellationToken;

        public UpdateRentHandlerTest()
        {
            _faker = new Faker();
            _rentModel = new RentModel
            {
                StartDate = DateTime.Now.AddDays(1),
                EndDate = DateTime.Now.AddDays(7),
                EndDateExpected = DateTime.Now.AddDays(7),
                Total = 70,
                TotalExpected = 70,
                UserId = Guid.NewGuid().ToString(),
                MotorcycleId = Guid.NewGuid().ToString(),
                Plan = PlanBuilder.New().Build(),
                Status = RentStatus.Available
            };
            _mediator = new Mock<IMediator>();
            _cancellationToken = new CancellationToken();

            _rentGatewayMock = new Mock<IRentGateway>();
            _updateRentHandler = new UpdateRentHandler(_rentGatewayMock.Object, _mapper, _mediator.Object);
        }

        [Fact]
        public async void ShouldUpdateRent()
        {
            _updateRentCommand = new UpdateRentCommand(_rentModel);
            var rent = RentBuilder.New().Build();
            _rentGatewayMock.Setup(r => r.GetAsync(_rentModel.Id)).ReturnsAsync(rent);
            _rentGatewayMock.Setup(r => r.UpdateAsync(_mapper.Map<Rent>(_rentModel))).ReturnsAsync(rent);

            _updateRentHandler.Handle(_updateRentCommand, _cancellationToken);

            Assert.Equal(_rentModel.StartDate, rent.StartDate);
            Assert.Equal(_rentModel.EndDate, rent.EndDate);
            Assert.Equal(_rentModel.EndDateExpected, rent.EndDateExpected);
            Assert.Equal(_rentModel.Total, rent.Total);
            Assert.Equal(_rentModel.TotalExpected, rent.TotalExpected);
            Assert.Equal(_rentModel.UserId, rent.UserId);
            Assert.Equal(_rentModel.MotorcycleId, rent.MotorcycleId);
            Assert.Equal(_rentModel.Plan, rent.Plan);
            Assert.Equal(_rentModel.Status, rent.Status);
        }

        [Fact]
        public async void ShouldNotUpdateRentWithInvalidId()
        {
            _updateRentCommand = new UpdateRentCommand(_rentModel);
            var rent = RentBuilder.New().Build();
            _rentGatewayMock.Setup(r => r.GetAsync(_rentModel.Id)).ReturnsAsync((Rent)null);
            _rentGatewayMock.Setup(r => r.UpdateAsync(_mapper.Map<Rent>(_rentModel))).ReturnsAsync(rent);

            (await Assert.ThrowsAsync<ExceptionDomain>(() => _updateRentHandler.Handle(_updateRentCommand, _cancellationToken)))
                .WithMessage(Resources.RentNotFound);

            _rentGatewayMock.Verify(r => r.UpdateAsync(It.IsAny<Rent>()), Times.Never);
        }
    }
}