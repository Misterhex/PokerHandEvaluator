using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texas.Core
{
    public class Card : Tuple<Rank, Suit>
    {
        public Rank Rank { get; private set; }
        public Suit Suit { get; private set; }

        public Card(Rank rank, Suit suit)
            : base(rank, suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }
    }
}
