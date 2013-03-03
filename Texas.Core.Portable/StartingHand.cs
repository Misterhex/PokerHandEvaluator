using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Texas.Core.Portable
{
    /// <summary>
    /// The first 2 cards dealt to player.
    /// </summary>
    public class StartingHand : IEnumerable<Card>
    {
        public Card First { get; private set; }
        public Card Second { get; private set; }

        private IEnumerable<Card> _cards;

        public StartingHand(Card first, Card second)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");
            if (first.Equals(second)) throw new ArgumentException("first card cannot be the same as second card.");

            this.First = first;
            this.Second = second;
            _cards = new List<Card>() { first, second };
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
