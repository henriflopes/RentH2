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

namespace RentH2.Application.Test.MotorcycleTest
{
    public class GetMotorcycleListHandlerTest : ConfigBase
    {
        private readonly Faker _faker;
        private readonly MotorcycleModel _motorcycleModel;
        private GetMotorcycleListHandler _getMotorcycleListHandler;
        private GetMotorcycleListQuery _getMotorcycleListQuery;
        private readonly Mock<IMotorcycleGateway> _motorcycleGatewayMock;
        private readonly CancellationToken _cancellationToken;

        public GetMotorcycleListHandlerTest()
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
            _getMotorcycleListHandler = new GetMotorcycleListHandler(_motorcycleGatewayMock.Object, _mapper);
        }

        [Fact]
        public async void ShouldGetAllMotorcycle()
        {
            _getMotorcycleListQuery = new GetMotorcycleListQuery();
            var motorcycle = _mapper.Map<Motorcycle>(_motorcycleModel);
            List<Motorcycle> result = [motorcycle];
            _motorcycleGatewayMock.Setup(r => r.GetAsync()).ReturnsAsync(result);

            _getMotorcycleListHandler.Handle(_getMotorcycleListQuery, _cancellationToken);

            _motorcycleGatewayMock.Verify(r => r.GetAsync(), Times.Once);
        }
    }
}