using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHandEvaluator.Portable
{
    /// <summary>
    /// A hand always consists of five cards.
    /// </summary>
    public class Hand : IEnumerable<Card>
    {
        private IEnumerable<Card> _cards;

        public Hand(string card1, string card2, string card3, string card4, string card5)
        {
            List<Card> cards = new List<Card>()
            {
                card1.AsCard(), card2.AsCard(), card3.AsCard(), card4.AsCard(), card5.AsCard()
            };
            if (cards.Where(i => i == null).Any())
            {
                throw new ArgumentException("invalid card string passed into constructor.");
            }

            _cards = cards;
        }

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

        public override string ToString()
        {
            return string.Concat(values: _cards.Select(card => card.ToString() + " ").ToArray());
        }
    }
}

