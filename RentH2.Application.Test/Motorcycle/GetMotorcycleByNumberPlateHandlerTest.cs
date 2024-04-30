using Bogus;
using Bogus.Extensions.UnitedKingdom;
using Moq;
using RentH2.Application.CQRSMotorcycle.Handlers;
using RentH2.Application.Test.Utility;
using RentH2.Domain.Models;
using RentH2.Domain.Utility;
using RentH2.Domain.Entities;
using RentH2.Infrastructure.Repositories.Interfaces;
using RentH2.Application.CQRSMotorcycle.Queries;
using RentH2.Domain.Entities.Validators;
using RentH2.Domain.Base;
using RentH2.Domain.Test._Utility;

namespace RentH2.Application.Test.MotorcycleTest
{
    public class GetMotorcycleByNumberPlateHandlerTest : ConfigBase
    {
        private readonly Faker _faker;
        private readonly MotorcycleModel _motorcycleModel;
        private GetMotorcycleByNumberPlateHandler _getMotorcycleByNumberPlateHandler;
        private GetMotorcycleByNumberPlateQuery _getMotorcycleByNumberPlateQuery;
        private readonly Mock<IMotorcycleGateway> _motorcycleGatewayMock;
        private readonly CancellationToken _cancellationToken;

        public GetMotorcycleByNumberPlateHandlerTest()
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
            _cancellationToken = new CancellationToken();
            _motorcycleGatewayMock = new Mock<IMotorcycleGateway>();
            _getMotorcycleByNumberPlateHandler = new GetMotorcycleByNumberPlateHandler(_motorcycleGatewayMock.Object, _mapper);
        }

        [Fact]
        public async void ShouldFindMotorcycleByNumberPlate()
        {
            _getMotorcycleByNumberPlateQuery = new GetMotorcycleByNumberPlateQuery(_motorcycleModel.NumberPlate);
            var motorcycle = _mapper.Map<Motorcycle>(_motorcycleModel);
            _motorcycleGatewayMock.Setup(r => r.GetByNumberPlateAsync(It.IsAny<string>())).ReturnsAsync(motorcycle);

            _getMotorcycleByNumberPlateHandler.Handle(_getMotorcycleByNumberPlateQuery, _cancellationToken);

            _motorcycleGatewayMock.Verify(r => r.GetByNumberPlateAsync(
                It.IsAny<string>()), Times.Once
            );
        }

        [Fact]
        public async void ShouldNotFindMotorcycleByInvalidNumberPlate()
        {
            _getMotorcycleByNumberPlateQuery = new GetMotorcycleByNumberPlateQuery(_motorcycleModel.NumberPlate);
            var motorcycle = _mapper.Map<Motorcycle>(_motorcycleModel);
            _motorcycleGatewayMock.Setup(r => r.GetByNumberPlateAsync(It.IsAny<string>())).ReturnsAsync((Motorcycle)null);
            
            _getMotorcycleByNumberPlateHandler.Handle(_getMotorcycleByNumberPlateQuery, _cancellationToken);

            _motorcycleGatewayMock.Verify(r => r.GetByNumberPlateAsync(
                It.IsAny<string>()), Times.Once
            );
        }
    }
}