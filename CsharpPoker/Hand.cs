using System.Collections.Concurrent;

namespace CsharpPoker
{
    public class Hand
    {
        private readonly List<Card> _cards = new();

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

        public HandRank GetHandRank() => Rankings().First(x=>x.eval.Invoke(_cards)).

        private List<(Func<IEnumerable<Card>, bool> eval, HandRank rank)> Rankings() =>
            new()
            {
                { new((cards) => cards.HasRoyalFlush(), HandRank.RoyalFlush) },
                { new((cards) => cards.HasStraightFlush(), HandRank.StraightFlush) },
                { new((cards) => cards.HasFlush(), HandRank.Flush) },
                { new((cards) => cards.HasStraight(), HandRank.Straight) },
                { new((cards) => cards.HasFullHouse(), HandRank.FullHouse) },
                { new((cards) => cards.HasFourOfAKind(), HandRank.FourOfAKind) },
                { new((cards) => cards.HasThreeOfAKind(), HandRank.ThreeOfAKind) },
                { new((cards) => cards.HasTwoPair(), HandRank.TwoPair) },
                { new((cards) => cards.HasPair(), HandRank.Pair) },
                { new((cards) => true, HandRank.HighCard) },
            };
    }
}
