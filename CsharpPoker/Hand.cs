using System.Collections.Concurrent;

namespace CsharpPoker
{
    public class Hand
    {
        private readonly List<Card> _cards = new();
        public Hand()
        {

        }

        public IEnumerable<Card> Cards => _cards;

        public void Draw(Card card)
        {
            _cards.Add(card);
        }

        public Card HighCard() => _cards.Aggregate((current, highcard) => current.Value > highcard.Value ? current : highcard);

        public HandRank GetHandRank() => 
            HasRoyalFlush() ? HandRank.RoyalFlush :
            HasFlush() ? HandRank.Flush :
            HasFullHouse() ? HandRank.FullHouse :
            HasFourOfAKind() ? HandRank.FourOfAKind :
            HasThreeOfAKind() ? HandRank.ThreeOfAKind :
            HasTwoPair() ? HandRank.TwoPair : 
            HasPair() ? HandRank.Pair :
            HandRank.HighCard;

        private bool HasOfAKind(int count) => GetKindAndQuantities(_cards).Any(c => c.Value == count);
        private int CountOfAKind(int count) => GetKindAndQuantities(_cards).Count(c => c.Value == count);

        private bool HasPair() => HasOfAKind(2);
        
        private bool HasTwoPair() => CountOfAKind(2) == 2;
        
        private bool HasThreeOfAKind() => HasOfAKind(3);
        
        private bool HasFourOfAKind() => HasOfAKind(4);
        
        private bool HasFullHouse() => HasOfAKind(2) && HasOfAKind(3);
        
        private bool HasFlush() => _cards.All(x => _cards.First().Suit == x.Suit);
        
        private bool HasRoyalFlush() =>
            HasFlush() && HighCard().Value == CardValue.Ace && HasStraight();
        
        private bool HasStraight()
        {
            var orderedValue = _cards.OrderBy(x => x.Value).Select(x => (int)x.Value).ToList();

            for (int i = 0; i < orderedValue.Count - 1; i++)
            {
                if (orderedValue[i + 1] != orderedValue[i] + 1)
                {
                    return false;
                }
            }

            return true;
        }

        private IEnumerable<KeyValuePair<CardValue, int>> GetKindAndQuantities(IEnumerable<Card> cards)
        {
            var dict = new ConcurrentDictionary<CardValue, int>();
            foreach (var card in cards)
            {
                dict.AddOrUpdate(card.Value, 1, (cardValue, quantity) => ++quantity);
            }
            return dict;
        }
    }
}
