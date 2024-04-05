using Bogus;
using Bogus.Extensions.UnitedKingdom;
using Moq;
using RentH2.Application.CQRSMotorcycle.Handlers;
using RentH2.Application.Test.Utility;
using RentH2.Common.Models;
using RentH2.Common.Utility;
using RentH2.Domain.Entities;
using RentH2.Infrastructure.Repositories.Interfaces;
using RentH2.Application.CQRSMotorcycle.Queries;
using RentH2.Domain.Entities.Validators;
using RentH2.Domain.Base;
using RentH2.Domain.Test._Utility;

namespace RentH2.Application.Test.MotorcycleTest
{
    public class GetMotorcycleListByStatusHandlerTest : ConfigBase
    {
        private readonly Faker _faker;
        private readonly MotorcycleModel _motorcycleModel;
        private GetMotorcycleListByStatusHandler _getMotorcycleListByStatusHandler;
        private GetMotorcycleListByStatusQuery _getMotorcycleListByStatusQuery;
        private readonly Mock<IMotorcycleGateway> _motorcycleGatewayMock;
        private readonly CancellationToken _cancellationToken;

        public GetMotorcycleListByStatusHandlerTest()
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
            _getMotorcycleListByStatusHandler = new GetMotorcycleListByStatusHandler(_motorcycleGatewayMock.Object, _mapper);
        }

        [Fact]
        public async void ShouldGetAllMotorcycleByStatus()
        {
            _getMotorcycleListByStatusQuery = new GetMotorcycleListByStatusQuery([RentStatus.Available, RentStatus.Deleted]);
            var motorcycle = _mapper.Map<Motorcycle>(_motorcycleModel);
            List<Motorcycle> result = [motorcycle];
            _motorcycleGatewayMock.Setup(r => r.GetAllByStatusAsync(It.IsAny<List<string>>())).ReturnsAsync(result);

            _getMotorcycleListByStatusHandler.Handle(_getMotorcycleListByStatusQuery, _cancellationToken);

            _motorcycleGatewayMock.Verify(r => r.GetAllByStatusAsync(
                It.IsAny<List<string>>()), Times.Once
            );
        }
    }
}