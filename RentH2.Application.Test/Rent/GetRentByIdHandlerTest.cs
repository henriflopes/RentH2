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
    public class GetRentByIdHandlerTest : ConfigBase
    {
        private readonly Faker _faker;
        private readonly RentModel _rentModel;
        private GetRentByIdHandler _getRentByIdHandler;
        private GetRentByIdQuery _getRentByIdQuery;
        private readonly Mock<IRentGateway> _rentGatewayMock;
        private readonly CancellationToken _cancellationToken;

        public GetRentByIdHandlerTest()
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
            _getRentByIdHandler = new GetRentByIdHandler(_rentGatewayMock.Object, _mapper);
        }

        [Fact]
        public async void ShouldFindRentById()
        {
            _getRentByIdQuery = new GetRentByIdQuery(_rentModel.Id);
            var rent = _mapper.Map<Rent>(_rentModel);
            _rentGatewayMock.Setup(r => r.GetAsync(It.IsAny<string>())).ReturnsAsync(rent);

            _getRentByIdHandler.Handle(_getRentByIdQuery, _cancellationToken);

            _rentGatewayMock.Verify(r => r.GetAsync(
                It.IsAny<string>()), Times.Once
            );
        }

        [Fact]
        public async void ShouldNotFindRentByInvalidId()
        {
            _getRentByIdQuery = new GetRentByIdQuery(_rentModel.Id);
            var rent = _mapper.Map<Rent>(_rentModel);
            _rentGatewayMock.Setup(r => r.GetAsync(It.IsAny<string>())).ReturnsAsync((Rent)null);

            (await Assert.ThrowsAsync<ExceptionDomain>(() => _getRentByIdHandler.Handle(_getRentByIdQuery, _cancellationToken)))
                .WithMessage(Resources.RentNotFound);

            _rentGatewayMock.Verify(r => r.GetAsync(
                It.IsAny<string>()), Times.Once
            );
        }
    }
}