using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Texas.Core.Tests
{
    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void Should_return_four_of_a_kind()
        {
            List<Card> cards = new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.Ace, Suit.Diamond),
                new Card(Rank.Ace, Suit.Club),
                new Card(Rank.Ace, Suit.Heart),
                new Card(Rank.Eigth, Suit.Spade)
            };

            Hand hand = new Hand(cards);

            Assert.AreEqual(HandCategory.FourOfAKind, hand.GetHandCategory());
        }

        [TestMethod]
        public void Should_return_three_of_a_kind()
        {
            List<Card> cards = new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.Ace, Suit.Diamond),
                new Card(Rank.Ace, Suit.Club),
                new Card(Rank.Nine, Suit.Heart),
                new Card(Rank.Eigth, Suit.Spade)
            };

            Hand hand = new Hand(cards);

            Assert.AreEqual(HandCategory.ThreeOfAKind, hand.GetHandCategory());
        }

        [TestMethod]
        public void Should_return_full_house()
        {
            List<Card> cards = new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.Ace, Suit.Diamond),
                new Card(Rank.Ace, Suit.Club),
                new Card(Rank.Eigth, Suit.Heart),
                new Card(Rank.Eigth, Suit.Spade)
            };

            Hand hand = new Hand(cards);

            Assert.AreEqual(HandCategory.FullHouse, hand.GetHandCategory());
        }

        [TestMethod]
        public void Should_return_flush()
        {
            List<Card> cards = new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.Jack, Suit.Spade),
                new Card(Rank.Nine, Suit.Spade),
                new Card(Rank.Eigth, Suit.Spade),
                new Card(Rank.Four, Suit.Spade)
            };

            Hand hand = new Hand(cards);

            Assert.AreEqual(HandCategory.Flush, hand.GetHandCategory());
        }

        [TestMethod]
        public void Should_return_two_pair()
        {
            List<Card> cards = new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.Ace, Suit.Diamond),
                new Card(Rank.King, Suit.Spade),
                new Card(Rank.King, Suit.Club),
                new Card(Rank.Four, Suit.Spade)
            };

            Hand hand = new Hand(cards);

            Assert.AreEqual(HandCategory.TwoPair, hand.GetHandCategory());
        }

        [TestMethod]
        public void Should_return_one_pair()
        {
            List<Card> cards = new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.Ace, Suit.Diamond),
                new Card(Rank.Jack, Suit.Spade),
                new Card(Rank.King, Suit.Club),
                new Card(Rank.Four, Suit.Spade)
            };

            Hand hand = new Hand(cards);

            Assert.AreEqual(HandCategory.OnePair, hand.GetHandCategory());
        }

        [TestMethod]
        public void Should_return_straight()
        {
            List<Card> cards = new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.King, Suit.Diamond),
                new Card(Rank.Jack, Suit.Spade),
                new Card(Rank.Queen, Suit.Club),
                new Card(Rank.Ten, Suit.Spade)
            };

            Hand hand = new Hand(cards);
            Assert.AreEqual(HandCategory.Straight, hand.GetHandCategory());
        }


        [TestMethod]
        public void Should_return_straightflush()
        {
            List<Card> cards = new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.King, Suit.Spade),
                new Card(Rank.Jack, Suit.Spade),
                new Card(Rank.Queen, Suit.Spade),
                new Card(Rank.Ten, Suit.Spade)
            };

            Hand hand = new Hand(cards);
            Assert.AreEqual(HandCategory.StraightFlush, hand.GetHandCategory());
        }

        [TestMethod]
        public void Should_return_highcard()
        {
            List<Card> cards = new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.King, Suit.Diamond),
                new Card(Rank.Jack, Suit.Heart),
                new Card(Rank.Five, Suit.Club),
                new Card(Rank.Three, Suit.Diamond)
            };

            Hand hand = new Hand(cards);
            Assert.AreEqual(HandCategory.HighCard, hand.GetHandCategory());
        }

        [TestMethod]
        public void Should_return_highcard_not_straight_because_cannot_cross_over()
        {
            List<Card> cards = new List<Card>() 
            {
                new Card(Rank.Two, Suit.Spade),
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.King, Suit.Diamond),
                new Card(Rank.Jack, Suit.Spade),
                new Card(Rank.Queen, Suit.Club)
            };

            Hand hand = new Hand(cards);
            Assert.AreEqual(HandCategory.HighCard, hand.GetHandCategory());
        }


        [TestMethod]
        [ExpectedException(typeof(DuplicatedCardInHandException))]
        public void Should_not_allow_duplicated_card_in_hand()
        {
            List<Card> cards = new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.Ace, Suit.Spade)
            };

            Hand hand = new Hand(cards);
        }
    }
}
