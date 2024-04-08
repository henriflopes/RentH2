using Bogus;
using Moq;
using RentH2.Application.CQRSRent.Handlers;
using RentH2.Application.Test.Utility;
using RentH2.Common.Models;
using RentH2.Common.Utility;
using RentH2.Domain.Entities;
using RentH2.Infrastructure.Repositories.Interfaces;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Domain.Entities.Validators;
using RentH2.Domain.Base;
using RentH2.Domain.Test._Utility;
using RentH2.Domain.Test._Builders;

namespace RentH2.Application.Test.RentTest
{
    public class GetRentedMotorcyclesByIdHandlerTest : ConfigBase
    {
        private readonly Faker _faker;
        private readonly RentModel _rentModel;
        private GetRentedMotorcyclesByIdHandler _getRentedMotorcyclesByIdHandler;
        private GetRentedMotorcyclesByIdQuery _getRentedMotorcyclesByIdQuery;
        private readonly Mock<IRentGateway> _rentGatewayMock;
        private readonly CancellationToken _cancellationToken;
        private readonly List<string> _ids;

        public GetRentedMotorcyclesByIdHandlerTest()
        {
            _faker = new Faker();
            _ids = ["123", "321"];
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
            _rentGatewayMock = new Mock<IRentGateway>();
            _getRentedMotorcyclesByIdHandler = new GetRentedMotorcyclesByIdHandler(_rentGatewayMock.Object, _mapper);
        }

        [Fact]
        public async void ShouldFindRentedMotorcyclesById()
        {
            _getRentedMotorcyclesByIdQuery = new GetRentedMotorcyclesByIdQuery(_ids);
            var rent = _mapper.Map<Rent>(_rentModel);
            List<Rent> result = [rent];
            _rentGatewayMock.Setup(r => r.GetRentedMotorcyclesByIdAsync(It.IsAny<List<string>>())).ReturnsAsync(result);

            _getRentedMotorcyclesByIdHandler.Handle(_getRentedMotorcyclesByIdQuery, _cancellationToken);

            _rentGatewayMock.Verify(r => r.GetRentedMotorcyclesByIdAsync(It.IsAny<List<string>>()), Times.Once);
        }

        [Fact]
        public async void ShouldNotFindRentedMotorcyclesById()
        {
            _getRentedMotorcyclesByIdQuery = new GetRentedMotorcyclesByIdQuery(_ids);
            var rent = _mapper.Map<Rent>(_rentModel);
            List<Rent> result = [rent];
            _rentGatewayMock.Setup(r => r.GetRentedMotorcyclesByIdAsync(It.IsAny<List<string>>())).ReturnsAsync((List<Rent>)null);

            (await Assert.ThrowsAsync<ExceptionDomain>(() => _getRentedMotorcyclesByIdHandler.Handle(_getRentedMotorcyclesByIdQuery, _cancellationToken)))
                .WithMessage(Resources.RentNotFound);

            _rentGatewayMock.Verify(r => r.GetRentedMotorcyclesByIdAsync(It.IsAny<List<string>>()), Times.Once);
        }
    }
}