using Bogus;
using Moq;
using RentH2.Application.CQRSRent.Handlers;
using RentH2.Application.Test.Utility;
using RentH2.Domain.Models;
using RentH2.Domain.Utility;
using RentH2.Domain.Entities;
using RentH2.Infrastructure.Repositories.Interfaces;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Domain.Test._Builders;
using RentH2.Domain.Interface.Services;

namespace RentH2.Application.Test.RentTest
{
    public class GetAllRentedByExpectedDateHandlerTest : ConfigBase
    {
        private readonly Faker _faker;
        private readonly RentModel _rentModel;
        private GetAllRentedByExpectedDateHandler _getAllRentedByExpectedDateHandler;
        private GetAllRentedByExpectedDateQuery _getAllRentedByExpectedDateQuery;
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;
        private readonly Mock<IRentGateway> _rentGatewayMock;
        private readonly Mock<IMotorcycleService> _rentServiceMock;
        private readonly CancellationToken _cancellationToken;

        public GetAllRentedByExpectedDateHandlerTest()
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
            _rentGatewayMock = new Mock<IRentGateway>();
            _rentServiceMock = new Mock<IMotorcycleService>();
            _getAllRentedByExpectedDateHandler = new GetAllRentedByExpectedDateHandler(_rentGatewayMock.Object, _mapper, _rentServiceMock.Object);
        }

        [Fact]
        public async void ShouldGetAllRentedByExpectedDate()
        {
            _getAllRentedByExpectedDateQuery = new GetAllRentedByExpectedDateQuery(_startDate, _endDate);
            var rent = _mapper.Map<Rent>(_rentModel);
            List<Rent> result = [rent];
            _rentGatewayMock.Setup(r => r.GetAllRentedByExpectedDateAsync(_startDate, _endDate)).ReturnsAsync(result);

            _getAllRentedByExpectedDateHandler.Handle(_getAllRentedByExpectedDateQuery, _cancellationToken);

            _rentGatewayMock.Verify(r => r.GetAllRentedByExpectedDateAsync(_startDate, _endDate), Times.Once);
        }
    }
}