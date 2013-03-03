using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Texas.Core.Portable
{
    public class Card : IEquatable<Card>
    {
        public Rank Rank { get; private set; }
        public Suit Suit { get; private set; }

        public int Point
        {
            get
            {
                return (int)this.Rank + (int)this.Suit;
            }
        }

        public Card(Rank rank, Suit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        public bool Equals(Card other)
        {
            return this.Point == other.Point;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", this.Rank.ToPokerString(), this.Suit.ToPokerString());
        }
    }

}
