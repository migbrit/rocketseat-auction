using Bogus;
using FluentAssertions;
using Moq;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Http.Requests;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;
using Xunit;

namespace UseCases.Test.Offers.CreateOffer;
public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Success(int itemId)
    {
        //Arrange
        var requestCreateOffer = new Faker<RequestCreateOffer>()
            .RuleFor(request => request.Price, f => f.Random.Decimal())
            ;

        var offerRepository = new Mock<IOfferRepository>();
        var getUserUseCase = new Mock<IGetUserUseCase>();
        getUserUseCase.Setup(i => i.Execute()).Returns(new User());

        var useCase = new CreateOfferUseCase(getUserUseCase.Object, offerRepository.Object);

        //Act
        var act = () => useCase.Execute(itemId, requestCreateOffer);

        //Assert
        act.Should().NotThrow();
    }
}
