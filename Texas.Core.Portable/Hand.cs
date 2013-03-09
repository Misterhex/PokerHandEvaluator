using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Texas.Core.Portable
{
    /// <summary>
    /// A hand always consists of five cards.
    /// </summary>
    public class Hand : IEnumerable<Card>
    {
        private IEnumerable<Card> _cards;

        public Hand(IEnumerable<Card> cards)
        {
            if (cards == null) throw new ArgumentNullException("cards");
            if (cards.Count() != 5) throw new ArgumentException("hand must be exactly 5 cards.");
            if (cards.GroupBy(i => new { i.Rank, i.Suit }).Count() != 5) throw new DuplicatedCardInHandException();

            _cards = cards.OrderByDescending(i => i.Point);
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return _cards.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _cards.GetEnumerator();
        }
    }
}

