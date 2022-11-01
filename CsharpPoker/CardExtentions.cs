using System.Collections.Concurrent;

namespace CsharpPoker
{
    public static class CardExtentions
    {
        public static IEnumerable<KeyValuePair<CardValue, int>> GetKindAndQuantities(this IEnumerable<Card> cards)
        {
            var dict = new ConcurrentDictionary<CardValue, int>();
            foreach (var card in cards)
            {
                dict.AddOrUpdate(card.Value, 1, (cardValue, quantity) => quantity + 1);
            }
            return dict;
        }

        public static IEnumerable<TResult> SelectConsecutive<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TSource, TResult> selector)
        {
            int index = -1;
            foreach (TSource element in source.Take(source.Count() - 1)) // skip the last, it will be evaluated by source.ElementAt(index + 1)
            {
                checked { index++; } // explicitly enable overflow checking
                yield return selector(element, source.ElementAt(index + 1)); // delegate element and element[+1] to Func<TSource, TSource, TResult>
            }
        }
    }
}
