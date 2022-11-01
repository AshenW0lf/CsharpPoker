namespace CsharpPoker
{
    public static class FiveCardPokerScorer
    {
        public static bool HasOfAKind(this IEnumerable<Card> cards, int count) => cards.GetKindAndQuantities().Any(c => c.Value == count);
        
        public static int CountOfAKind(this IEnumerable<Card> cards, int count) => cards.GetKindAndQuantities().Count(c => c.Value == count);

        public static bool HasPair(this IEnumerable<Card> cards) => cards.HasOfAKind(2);

        public static bool HasTwoPair(this IEnumerable<Card> cards) => cards.CountOfAKind(2) == 2;

        public static bool HasThreeOfAKind(this IEnumerable<Card> cards) => cards.HasOfAKind(3);

        public static bool HasFourOfAKind(this IEnumerable<Card> cards) => cards.HasOfAKind(4);

        public static bool HasStraight(this IEnumerable<Card> cards) =>
            cards.OrderBy(card => card.Value).SelectConsecutive((n, next) => n.Value + 1 == next.Value).All(value => value);

        public static bool HasFullHouse(this IEnumerable<Card> cards) => cards.HasOfAKind(2) && cards.HasOfAKind(3);

        public static bool HasFlush(this IEnumerable<Card> cards) => cards.All(x => cards.First().Suit == x.Suit);

        public static bool HasStraightFlush(this IEnumerable<Card> cards) => cards.HasFlush() && cards.HasStraight();

        public static bool HasRoyalFlush(this IEnumerable<Card> cards) =>
            cards.HasFlush() && cards.HighCard().Value == CardValue.Ace && cards.HasStraight();

        public static Card HighCard(this IEnumerable<Card> cards) => cards.Aggregate((current, highcard) => current.Value > highcard.Value ? current : highcard);

    }
}
