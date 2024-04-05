using Bogus;
using Bogus.Extensions.UnitedKingdom;
using MediatR;
using Moq;
using RentH2.Application.CQRSMotorcycle.Commands;
using RentH2.Application.CQRSMotorcycle.Handlers;
using RentH2.Application.Test.Utility;
using RentH2.Common.Models;
using RentH2.Common.Utility;
using RentH2.Domain.Entities;
using RentH2.Domain.Entities.Validators;
using RentH2.Domain.Test._Builders;
using RentH2.Domain.Test._Utility;
using RentH2.Infrastructure.Repositories.Interfaces;
using RentH2.Domain.Base;
using RentH2.Application.CQRSMotorcycle.Queries;

namespace RentH2.Application.Test.MotorcycleTest
{
    public class UpdateMotorcycleHandlerTest : ConfigBase
    {

        private readonly Faker _faker;
        private readonly MotorcycleModel _motorcycleModel;
        private UpdateMotorcycleHandler _updateMotorcycleHandler;
        private UpdateMotorcycleCommand _updateMotorcycleCommand;
        private readonly Mock<IMotorcycleGateway> _motorcycleGatewayMock;
        private readonly Mock<IMediator> _mediator;
        private readonly CancellationToken _cancellationToken;

        public UpdateMotorcycleHandlerTest()
        {
            _faker = new Faker();
            _motorcycleModel = new MotorcycleModel
            {
                Year = _faker.Random.Int(2000, 2024).ToString(),
                Type = _faker.Lorem.Paragraph()[..10],
                NumberPlate = _faker.Vehicle.GbRegistrationPlate(new DateTime(2005, 1, 1), new DateTime(2024, 1, 1)),
                Location = _faker.Address.FullAddress(),
                Status = RentStatus.Available
            };
            _mediator = new Mock<IMediator>();
            _cancellationToken = new CancellationToken();

            _motorcycleGatewayMock = new Mock<IMotorcycleGateway>();
            _updateMotorcycleHandler = new UpdateMotorcycleHandler(_motorcycleGatewayMock.Object, _mapper, _mediator.Object);
        }

        [Fact]
        public async void ShouldUpdateMotorcycle()
        {
            _updateMotorcycleCommand = new UpdateMotorcycleCommand(_motorcycleModel);
            var motorcycle = MotorcycleBuilder.New().Build();
            _motorcycleGatewayMock.Setup(r => r.GetAsync(_motorcycleModel.Id)).ReturnsAsync(motorcycle);
            _motorcycleGatewayMock.Setup(r => r.UpdateAsync(_mapper.Map<Motorcycle>(_motorcycleModel))).ReturnsAsync(motorcycle);

            _mediator
                .Setup(m => m.Send(It.IsAny<GetMotorcycleByNumberPlateQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((MotorcycleModel)null);

            _updateMotorcycleHandler.Handle(_updateMotorcycleCommand, _cancellationToken);

            Assert.Equal(_motorcycleModel.Year, motorcycle.Year);
            Assert.Equal(_motorcycleModel.Status, motorcycle.Status);
            Assert.Equal(_motorcycleModel.Type, motorcycle.Type);
            Assert.Equal(_motorcycleModel.NumberPlate, motorcycle.NumberPlate);
            Assert.Equal(_motorcycleModel.Location, motorcycle.Location);
        }

        [Fact]
        public async void ShouldNotUpdateMotorcycleWithInvalidId()
        {
            _updateMotorcycleCommand = new UpdateMotorcycleCommand(_motorcycleModel);
            var motorcycle = MotorcycleBuilder.New().Build();
            _motorcycleGatewayMock.Setup(r => r.GetAsync(_motorcycleModel.Id)).ReturnsAsync((Motorcycle)null);
            _motorcycleGatewayMock.Setup(r => r.UpdateAsync(_mapper.Map<Motorcycle>(_motorcycleModel))).ReturnsAsync(motorcycle);

            _mediator
                .Setup(m => m.Send(It.IsAny<GetMotorcycleByNumberPlateQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((MotorcycleModel)null);

            (await Assert.ThrowsAsync<ExceptionDomain>(() => _updateMotorcycleHandler.Handle(_updateMotorcycleCommand, _cancellationToken)))
                .WithMessage(Resources.MotorcycleNotFound);

            _mediator.Verify(r => r.Send(It.IsAny<GetMotorcycleByNumberPlateQuery>(), It.IsAny<CancellationToken>()), Times.Never);
            _motorcycleGatewayMock.Verify(r => r.UpdateAsync(It.IsAny<Motorcycle>()), Times.Never);
        }

        [Fact]
        public async void ShouldNotUpdateMotorcycleWithNumberPlateAlreadyExistsToTheSystem()
        {
            _updateMotorcycleCommand = new UpdateMotorcycleCommand(_motorcycleModel);
            var motorcycle = MotorcycleBuilder.New().Build();
            _motorcycleGatewayMock.Setup(r => r.GetAsync(_motorcycleModel.Id)).ReturnsAsync(motorcycle);
            _motorcycleGatewayMock.Setup(r => r.UpdateAsync(_mapper.Map<Motorcycle>(_motorcycleModel))).ReturnsAsync(motorcycle);

            _mediator
                .Setup(m => m.Send(It.IsAny<GetMotorcycleByNumberPlateQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(_motorcycleModel);

            (await Assert.ThrowsAsync<ExceptionDomain>(() => _updateMotorcycleHandler.Handle(_updateMotorcycleCommand, _cancellationToken)))
                .WithMessage(Resources.MotorcycleExistsNumberPlate);

            _motorcycleGatewayMock.Verify(r => r.UpdateAsync(It.IsAny<Motorcycle>()), Times.Never);
        }
    }
}