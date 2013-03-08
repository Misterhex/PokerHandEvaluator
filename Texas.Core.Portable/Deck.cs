using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Texas.Core.Portable
{
    public class Deck : Stack<Card>
    {
        private static IEnumerable<Card> CreateDeck()
        {
            IEnumerable<Rank> ranks = typeof(Rank).GetFields().Select(i => i.TryGetValue<Rank>()).Where(i => i != 0);
            IEnumerable<Suit> suits = typeof(Suit).GetFields().Select(i => i.TryGetValue<Suit>()).Where(i => i != 0);

            var cards = (from rank in ranks
                         from suit in suits
                         select new Card(rank, suit));
            cards = Shuffle(cards);
            return cards;
        }

        private static List<Card> Shuffle(IEnumerable<Card> cards)
        {
            Random random = new Random();
            return cards.OrderBy(x => random.Next()).ToList();
        }

        public Deck()
            : this(CreateDeck())
        { }

        public Deck(IEnumerable<Card> cards)
            : base(cards)
        { }
    }
}
