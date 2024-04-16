using Bogus;
using Bogus.Extensions.UnitedKingdom;
using MediatR;
using Moq;
using RentH2.Application.CQRSMotorcycle.Commands;
using RentH2.Application.CQRSMotorcycle.Handlers;
using RentH2.Application.Test.Utility;
using RentH2.Domain.Models;
using RentH2.Domain.Utility;
using RentH2.Domain.Entities;
using RentH2.Domain.Entities.Validators;
using RentH2.Domain.Test._Builders;
using RentH2.Domain.Test._Utility;
using RentH2.Infrastructure.Repositories.Interfaces;
using RentH2.Domain.Base;
using RentH2.Application.CQRSMotorcycle.Queries;

namespace RentH2.Application.Test.MotorcycleTest
{
    public class CreateMotorcycleHandlerTest : ConfigBase
    {

        private readonly Faker _faker;
        private readonly MotorcycleModel _motorcycleModel;
        private CreateMotorcycleHandler _createMotorcycleHandler;
        private CreateMotorcycleCommand _createMotorcycleCommand;
        private readonly Mock<IMotorcycleGateway> _motorcycleGatewayMock;
        private readonly Mock<IMediator> _mediator;
        private readonly CancellationToken _cancellationToken;

        public CreateMotorcycleHandlerTest()
        {
            _faker = new Faker();
            _motorcycleModel = new MotorcycleModel
            {
                Year = _faker.Random.Int(2000, 2024).ToString(),
                Type = _faker.Lorem.Paragraph()[..10],
                NumberPlate  = _faker.Vehicle.GbRegistrationPlate(new DateTime(2005, 1, 1), new DateTime(2024, 1, 1)),
                Location = _faker.Address.FullAddress(),
                Status = RentStatus.Available
            };
            _mediator = new Mock<IMediator>();
            _cancellationToken = new CancellationToken();
            
            _motorcycleGatewayMock = new Mock<IMotorcycleGateway>();
            _createMotorcycleHandler = new CreateMotorcycleHandler(_motorcycleGatewayMock.Object, _mapper, _mediator.Object);
        }

        [Fact]
        public async void ShouldAddMotorcycle()
        {
            _createMotorcycleCommand = new CreateMotorcycleCommand(_motorcycleModel);
            var motorcycle = _mapper.Map<Motorcycle>(_createMotorcycleCommand.MotorcycleModel);
            _motorcycleGatewayMock.Setup(r => r.CreateAsync(It.IsAny<Motorcycle>())).ReturnsAsync(motorcycle);

            _createMotorcycleHandler.Handle(_createMotorcycleCommand, _cancellationToken);

            _motorcycleGatewayMock
                .Verify(r => r.CreateAsync(
                    It.Is<Motorcycle>(
                        c => c.Type == motorcycle.Type &&
                        c.NumberPlate == motorcycle.NumberPlate
                    )
            ));

            _motorcycleGatewayMock.Verify(r => r.CreateAsync(
                It.IsAny<Motorcycle>()), Times.Once
            );
        }

        [Fact]
        public async void ShouldNotAddMotorcycleWithNumberPlateAlreadyInTheSystem()
        {
            var motorcycleAlreadyInTheSystem = MotorcycleBuilder.New().WithNumberPlate("XPTO 3325 120").Build();
            var motorcycleModel = _mapper.Map<MotorcycleModel>(motorcycleAlreadyInTheSystem);

            _mediator
                .Setup(m => m.Send(It.IsAny<GetMotorcycleByNumberPlateQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(motorcycleModel);
            _createMotorcycleCommand = new CreateMotorcycleCommand(_mapper.Map<MotorcycleModel>(motorcycleAlreadyInTheSystem));

            (await Assert.ThrowsAsync<ExceptionDomain>(() => _createMotorcycleHandler.Handle(_createMotorcycleCommand, _cancellationToken)))
                .WithMessage(Resources.MotorcycleExistsNumberPlate);

            _motorcycleGatewayMock.Verify(r => r.CreateAsync(
                It.IsAny<Motorcycle>()), Times.Never
            );
        }
    }
}