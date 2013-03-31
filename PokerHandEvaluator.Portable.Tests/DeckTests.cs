using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandEvaluator.Portable.Tests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void Should_create_a_deck_contain_52_cards_without_duplicated_card()
        {
            Deck deck = new Deck();
            Assert.AreEqual(52, deck.Count());
            Assert.AreEqual(52, deck.Distinct(new CardComparer()).Count());
        }

    }
}
