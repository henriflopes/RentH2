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
    public class GetRentByUserIdHandlerTest : ConfigBase
    {
        private readonly Faker _faker;
        private readonly RentModel _rentModel;
        private GetRentByUserIdHandler _getRentByUserIdHandler;
        private GetRentByUserIdQuery _getRentByUserIdQuery;
        private readonly Mock<IRentGateway> _rentGatewayMock;
        private readonly CancellationToken _cancellationToken;

        public GetRentByUserIdHandlerTest()
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
            _getRentByUserIdHandler = new GetRentByUserIdHandler(_rentGatewayMock.Object, _mapper);
        }

        [Fact]
        public async void ShouldFindRentByUserId()
        {
            _getRentByUserIdQuery = new GetRentByUserIdQuery(_rentModel.UserId, _rentModel.Status);
            var rent = _mapper.Map<Rent>(_rentModel);
            _rentGatewayMock.Setup(r => r.GetRentByUserIdAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(rent);

            _getRentByUserIdHandler.Handle(_getRentByUserIdQuery, _cancellationToken);

            _rentGatewayMock.Verify(r => r.GetRentByUserIdAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async void ShouldNotFindRentByInvalidUserId()
        {
            _getRentByUserIdQuery = new GetRentByUserIdQuery(_rentModel.UserId, _rentModel.Status);
            var rent = _mapper.Map<Rent>(_rentModel);
            _rentGatewayMock.Setup(r => r.GetRentByUserIdAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync((Rent)null);

            (await Assert.ThrowsAsync<ExceptionDomain>(() => _getRentByUserIdHandler.Handle(_getRentByUserIdQuery, _cancellationToken)))
                .WithMessage(Resources.RentNotFound);

            _rentGatewayMock.Verify(r => r.GetRentByUserIdAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}