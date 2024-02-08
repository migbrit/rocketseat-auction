using Bogus;
using FluentAssertions;
using Moq;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Enums;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;
using Xunit;

namespace UseCases.Test.Auctions.GetCurrent;
public class GetCurrentAuctionUseCaseTest
{
    [Fact]
    public void Success()
    {
        //Arrange
        var mock = new Mock<IAuctionRepository>();
        var fakeAuction = new Faker<Auction>()
            .RuleFor(auction => auction.Id, f => f.Random.Number(1, 10))
            .RuleFor(auction => auction.Name, f => f.Random.Word())
            .RuleFor(auction => auction.Starts, f => f.Date.Past())
            .RuleFor(auction => auction.Ends, f => f.Date.Future())
            .RuleFor(auction => auction.Items, (f, auction) => new List<Item>
            {
                new Item
                {
                    Id = f.Random.Number(1, 10),
                    Name = f.Commerce.ProductName(),
                    Brand = f.Commerce.Department(),
                    BasePrice = f.Random.Decimal(50, 1000),
                    Condition = f.PickRandom<Condition>(),
                    AuctionId = auction.Id
                }
            }).Generate();

        mock.Setup(i => i.GetCurrent()).Returns(fakeAuction);

        var useCase = new GetCurrentAuctionUseCase(mock.Object);

        //Act
        var auction = useCase.Execute();

        //Assert
        auction.Should().NotBeNull();
        auction.Id.Should().Be(fakeAuction.Id);
        auction.Name.Should().Be(fakeAuction.Name);

    }
}
