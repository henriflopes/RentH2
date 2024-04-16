using Bogus;
using MediatR;
using Moq;
using RentH2.Application.CQRSRent.Commands;
using RentH2.Application.CQRSRent.Handlers;
using RentH2.Application.Test.Utility;
using RentH2.Domain.Models;
using RentH2.Domain.Utility;
using RentH2.Domain.Entities;
using RentH2.Domain.Test._Builders;
using RentH2.Infrastructure.Repositories.Interfaces;
using RentH2.Domain.Interface.Services;

namespace RentH2.Application.Test.RentTest
{
    public class CreateRentHandlerTest : ConfigBase
    {

        private readonly Faker _faker;
        private readonly RentModel _rentModel;
        private CreateRentHandler _createRentHandler;
        private CreateRentCommand _createRentCommand;
        private readonly Mock<IRentGateway> _rentGatewayMock;
        private readonly Mock<IMotorcycleService> _motorcycleServiceMock;
        private readonly CancellationToken _cancellationToken;

        public CreateRentHandlerTest()
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

            _cancellationToken = new CancellationToken();
            _motorcycleServiceMock = new Mock<IMotorcycleService>();

            _rentGatewayMock = new Mock<IRentGateway>();
            _createRentHandler = new CreateRentHandler(_rentGatewayMock.Object, _mapper, _motorcycleServiceMock.Object);
        }

        [Fact]
        public async void ShouldAddRent()
        {
            _createRentCommand = new CreateRentCommand(_rentModel);
            var rent = _mapper.Map<Rent>(_createRentCommand.RentModel);
            _rentGatewayMock.Setup(r => r.CreateAsync(It.IsAny<Rent>())).ReturnsAsync(rent);

            _createRentHandler.Handle(_createRentCommand, _cancellationToken);

            _rentGatewayMock
                .Verify(r => r.CreateAsync(
                    It.Is<Rent>(
                        c => c.StartDate == rent.StartDate &&
                        c.EndDateExpected == rent.EndDateExpected
                    )
            ));

            _rentGatewayMock.Verify(r => r.CreateAsync(
                It.IsAny<Rent>()), Times.Once
            );
        }
    }
}