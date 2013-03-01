using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texas.Core
{
    public class Hand : Tuple<Card, Card, Card, Card, Card>, IEnumerable<Card>
    {
        private IEnumerable<Card> _cards;

        public Hand(IEnumerable<Card> cards)
            : base(cards.First(), cards.Second(), cards.Third(), cards.Fourth(), cards.Fifth())
        {
            if (cards == null) throw new ArgumentNullException("cards");
            if (cards.Count() != 5) throw new ArgumentException("hand must be exactly 5 cards.");
            if (cards.GroupBy(i => new { i.Rank, i.Suit }).Count() != 5) throw new DuplicatedCardInHandException();

            _cards = cards;

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
