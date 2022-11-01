namespace CsharpPoker.Tests
{
    public class CardTests
    {
        [Theory, AutoData]
        [InlineData(CardValue.Ace, CardSuit.Hearts)]
        public void CanCreateCard_WithValue(CardValue value, CardSuit suit)
        {
            var card = new Card(value, suit);

            card.Suit.Should().Be(suit);
            card.Value.Should().Be(value);
        }

        [Theory]
        [InlineData(CardValue.Ace, CardSuit.Spades, "Ace of Spades")]
        [InlineData(CardValue.Queen, CardSuit.Hearts, "Queen of Hearts")]
        public void CanDescribeCard_AsExpected(CardValue value, CardSuit suit, string expected)
        {
            var card = new Card(value, suit);

            card.ToString().Should().Be(expected);
        }
    }
}