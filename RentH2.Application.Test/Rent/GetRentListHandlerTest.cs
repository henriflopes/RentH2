using Bogus;
using Bogus.Extensions.UnitedKingdom;
using Moq;
using RentH2.Application.CQRSRent.Handlers;
using RentH2.Application.Test.Utility;
using RentH2.Common.Models;
using RentH2.Common.Utility;
using RentH2.Domain.Entities;
using RentH2.Infrastructure.Repositories.Interfaces;
using RentH2.Application.CQRSRent.Queries;
using RentH2.Domain.Test._Builders;

namespace RentH2.Application.Test.RentTest
{
    public class GetRentListHandlerTest : ConfigBase
    {
        private readonly Faker _faker;
        private readonly RentModel _rentModel;
        private GetRentListHandler _getRentListHandler;
        private GetRentListQuery _getRentListQuery;
        private readonly Mock<IRentGateway> _rentGatewayMock;
        private readonly CancellationToken _cancellationToken;

        public GetRentListHandlerTest()
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
            _getRentListHandler = new GetRentListHandler(_rentGatewayMock.Object, _mapper);
        }

        [Fact]
        public async void ShouldGetAllRent()
        {
            _getRentListQuery = new GetRentListQuery();
            var rent = _mapper.Map<Rent>(_rentModel);
            List<Rent> result = [rent];
            _rentGatewayMock.Setup(r => r.GetAsync()).ReturnsAsync(result);

            _getRentListHandler.Handle(_getRentListQuery, _cancellationToken);

            _rentGatewayMock.Verify(r => r.GetAsync(), Times.Once);
        }
    }
}