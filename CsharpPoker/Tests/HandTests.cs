namespace CsharpPoker.Tests
{
    public class HandTests
    {
        [Fact]
        public void CanCreateHand()
        {
            var hand = new Hand();

            hand.Cards.Any().Should().BeFalse();
        }

        [Theory, AutoData]
        public void CanHandDrawCard(Card card)
        {
            // Arrange
            var hand = new Hand();

            // Act
            hand.Draw(card);

            //Assert
            hand.Cards.First().Should().Be(card);
        }

        [Fact]
        public void CanGetHighCard()
        {
            // Arrange
            var hand = new Hand();

            // Act
            hand.Draw(new Card(CardValue.Seven, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
            hand.Draw(new Card(CardValue.Five, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.Two, CardSuit.Hearts));

            //Assert
            hand.HighCard().Value.Should().Be(CardValue.King);
        }

        [Fact]
        public void CanScoreHighCard()
        {
            // Arrange
            var hand = new Hand();

            // Act
            hand.Draw(new Card(CardValue.Seven, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
            hand.Draw(new Card(CardValue.Five, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.Two, CardSuit.Hearts));

            // Assert
            hand.GetHandRank().Should().Be(HandRank.HighCard);
        }

        [Fact]
        public void CanScoreFlush()
        {
            // Arrange
            var hand = new Hand();

            // Act
            hand.Draw(new Card(CardValue.Two, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Three, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Five, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Six, CardSuit.Spades));

            // Assert
            hand.GetHandRank().Should().Be(HandRank.Flush);
        }

        [Fact]
        public void CanScoreRoyalFlush()
        {
            // Arrange
            var hand = new Hand();

            // Act
            hand.Draw(new Card(CardValue.Queen, CardSuit.Spades));
            hand.Draw(new Card(CardValue.King, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));

            // Assert
            hand.GetHandRank().Should().Be(HandRank.RoyalFlush);
        }

        [Fact]
        public void CanScorePair()
        {
            // Arrange
            var hand = new Hand();

            // Act
            hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
            hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Nine, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));

            // Assert
            hand.GetHandRank().Should().Be(HandRank.Pair);
        }

        [Fact]
        public void CanScoreTwoPair()
        {
            // Arrange
            var hand = new Hand();

            // Act
            hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
            hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Nine, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));

            // Assert
            hand.GetHandRank().Should().Be(HandRank.TwoPair);
        }

        [Fact]
        public void CanScoreThreeOfAKind()
        {
            // Arrange
            var hand = new Hand();
            
            // Act
            hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
            hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Nine, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
            
            // Assert
            hand.GetHandRank().Should().Be(HandRank.ThreeOfAKind);
        }

        [Fact]
        public void CanScoreFourOfAKind()
        {
            // Arrange
            var hand = new Hand();
            
            // Act
            hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
            hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ten, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
            
            // Assert
            hand.GetHandRank().Should().Be(HandRank.FourOfAKind);
        }

        [Fact]
        public void CanScoreFullHouse()
        {
            // Arrange
            var hand = new Hand();
            
            // Act
            hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
            hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Jack, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
            
            // Assert
            hand.GetHandRank().Should().Be(HandRank.FullHouse);
        }
    }
}
