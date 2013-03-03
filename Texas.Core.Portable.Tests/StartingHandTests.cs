using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texas.Core.Portable.Tests
{
    [TestClass]
    public class StartingHandTests
    {
        [TestMethod]
        public void Should_return_one_pair()
        {
            StartingHand startHand = new StartingHand(new Card(Rank.Ace, Suit.Spade), new Card(Rank.Ace, Suit.Heart));
            Assert.AreEqual(HandCategory.OnePair, startHand.GetHandCategory());
        }

        [TestMethod]
        public void Should_return_high_card()
        {
            StartingHand startHand = new StartingHand(new Card(Rank.Ace, Suit.Spade), new Card(Rank.King, Suit.Heart));
            Assert.AreEqual(HandCategory.HighCard, startHand.GetHandCategory());
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_throw_exception_because_starting_hand_cannot_contain_duplicate_cards()
        {
            StartingHand startHand = new StartingHand(new Card(Rank.Ace, Suit.Spade), new Card(Rank.Ace, Suit.Spade));
            Assert.AreEqual(HandCategory.HighCard, startHand.GetHandCategory());
        }
    }
}
