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


        /*private bool HasStraight()
        {
            var card = _cards.OrderBy(x => x.Value).ToList();

            for (int i = 0; i < card.Count - 1; i++)
            {
                if (card[i + 1].Value != card[i].Value + 1)
                {
                    return false;
                }
            }

            return true;
        }
        
        private bool HasStraight() => _cards.OrderBy(card => card.Value)
           .Zip(_cards.OrderBy(card => card.Value).Skip(1), (n, next) => n.Value + 1 == next.Value)
           .All(value => value);*/

        public HandRank GetHandRank() =>
            _cards.HasRoyalFlush() ? HandRank.RoyalFlush :
            _cards.HasStraightFlush() ? HandRank.StraightFlush :
            _cards.HasFlush() ? HandRank.Flush :
            _cards.HasStraight() ? HandRank.Straight :
            _cards.HasFullHouse() ? HandRank.FullHouse :
            _cards.HasFourOfAKind() ? HandRank.FourOfAKind :
            _cards.HasThreeOfAKind() ? HandRank.ThreeOfAKind :
            _cards.HasTwoPair() ? HandRank.TwoPair :
            _cards.HasPair() ? HandRank.Pair :
            HandRank.HighCard;
    }
}
