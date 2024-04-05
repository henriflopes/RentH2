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
    public class GetMotorcycleByIdHandlerTest : ConfigBase
    {
        private readonly Faker _faker;
        private readonly MotorcycleModel _motorcycleModel;
        private GetMotorcycleByIdHandler _getMotorcycleByIdHandler;
        private GetMotorcycleByIdQuery _getMotorcycleByIdQuery;
        private readonly Mock<IMotorcycleGateway> _motorcycleGatewayMock;
        private readonly CancellationToken _cancellationToken;

        public GetMotorcycleByIdHandlerTest()
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
            _getMotorcycleByIdHandler = new GetMotorcycleByIdHandler(_motorcycleGatewayMock.Object, _mapper);
        }

        [Fact]
        public async void ShouldFindMotorcycleById()
        {
            _getMotorcycleByIdQuery = new GetMotorcycleByIdQuery(_motorcycleModel.Id);
            var motorcycle = _mapper.Map<Motorcycle>(_motorcycleModel);
            _motorcycleGatewayMock.Setup(r => r.GetAsync(It.IsAny<string>())).ReturnsAsync(motorcycle);

            _getMotorcycleByIdHandler.Handle(_getMotorcycleByIdQuery, _cancellationToken);

            _motorcycleGatewayMock.Verify(r => r.GetAsync(
                It.IsAny<string>()), Times.Once
            );
        }

        [Fact]
        public async void ShouldNotFindMotorcycleByInvalidId()
        {
            _getMotorcycleByIdQuery = new GetMotorcycleByIdQuery(_motorcycleModel.Id);
            var motorcycle = _mapper.Map<Motorcycle>(_motorcycleModel);
            _motorcycleGatewayMock.Setup(r => r.GetAsync(It.IsAny<string>())).ReturnsAsync((Motorcycle)null);
            
            (await Assert.ThrowsAsync<ExceptionDomain>(() => _getMotorcycleByIdHandler.Handle(_getMotorcycleByIdQuery, _cancellationToken)))
                .WithMessage(Resources.MotorcycleNotFound);

            _motorcycleGatewayMock.Verify(r => r.GetAsync(
                It.IsAny<string>()), Times.Once
            );
        }
    }
}