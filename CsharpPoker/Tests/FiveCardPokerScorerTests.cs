namespace CsharpPoker.Tests
{
    public class FiveCardPokerScorerTests
    {

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
            FiveCardPokerScorer.HighCard(hand.Cards).Value.Should().Be(CardValue.King);
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
            FiveCardPokerScorer.HasFlush(hand.Cards).Should().BeTrue();
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
            FiveCardPokerScorer.HasRoyalFlush(hand.Cards).Should().BeTrue();
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
            FiveCardPokerScorer.HasPair(hand.Cards).Should().BeTrue();
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
            FiveCardPokerScorer.HasTwoPair(hand.Cards).Should().BeTrue();
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
            FiveCardPokerScorer.HasThreeOfAKind(hand.Cards).Should().BeTrue();
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
            FiveCardPokerScorer.HasFourOfAKind(hand.Cards).Should().BeTrue();
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
            FiveCardPokerScorer.HasFullHouse(hand.Cards).Should().BeTrue();
        }

        [Fact]
        public void CanScoreStraight()
        {
            var hand = new Hand();
            hand.Draw(new Card(CardValue.Ten, CardSuit.Clubs));
            hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Queen, CardSuit.Spades));
            hand.Draw(new Card(CardValue.King, CardSuit.Hearts));
            hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));

            FiveCardPokerScorer.HasStraight(hand.Cards).Should().BeTrue();
        }

        [Fact]
        public void CanScoreStraightUnordered()
        {
            var hand = new Hand();
            hand.Draw(new Card(CardValue.Ace, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Queen, CardSuit.Clubs));
            hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
            hand.Draw(new Card(CardValue.King, CardSuit.Hearts));

            FiveCardPokerScorer.HasStraight(hand.Cards).Should().BeTrue();
        }

        [Fact]
        public void CanScoreStraightFlush()
        {
            var hand = new Hand();
            hand.Draw(new Card(CardValue.Nine, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Queen, CardSuit.Spades));
            hand.Draw(new Card(CardValue.King, CardSuit.Spades));

            FiveCardPokerScorer.HasStraightFlush(hand.Cards).Should().BeTrue();
        }

        [Fact]
        public void CanScoreStraightFlushUnordered()
        {
            var hand = new Hand();
            hand.Draw(new Card(CardValue.Nine, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Queen, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Jack, CardSuit.Spades));
            hand.Draw(new Card(CardValue.Ten, CardSuit.Spades));
            hand.Draw(new Card(CardValue.King, CardSuit.Spades));

            FiveCardPokerScorer.HasStraightFlush(hand.Cards).Should().BeTrue();
        }
    }
}
