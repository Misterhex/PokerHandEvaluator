using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texas.Core.Portable.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void Should_return_correct_card_point()
        {
            Card card1 = new Card(Rank.Ace, Suit.Club);
            Card card2 = new Card(Rank.King, Suit.Club);
            Card card3 = new Card(Rank.Jack, Suit.Spade);
            Card card4 = new Card(Rank.Nine, Suit.Heart);
            Card card5 = new Card(Rank.Five, Suit.Spade);
            Card card6 = new Card(Rank.Three, Suit.Diamond);

            Assert.AreEqual(142, card1.Point);
            Assert.AreEqual(132, card2.Point);
            Assert.AreEqual(114, card3.Point);
            Assert.AreEqual(93, card4.Point);
            Assert.AreEqual(54, card5.Point);
            Assert.AreEqual(31, card6.Point);
        }

    }
}
