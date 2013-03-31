using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandEvaluator.Portable.Tests
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
                new Card(Rank.Deuce, Suit.Spade),
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.King, Suit.Diamond),
                new Card(Rank.Jack, Suit.Spade),
                new Card(Rank.Queen, Suit.Club)
            };

            Hand hand = new Hand(cards);
            Assert.AreEqual(HandCategory.HighCard, hand.GetHandCategory());
        }

        [TestMethod]
        public void Should_return_straight_for_boardway_straight()
        {
            List<Card> cards = new List<Card>() 
            {
                new Card(Rank.Ten, Suit.Spade),
                new Card(Rank.Jack, Suit.Spade),
                new Card(Rank.Queen, Suit.Diamond),
                new Card(Rank.King, Suit.Spade),
                new Card(Rank.Ace, Suit.Club)
            };

            Hand hand = new Hand(cards);
            Assert.AreEqual(HandCategory.Straight, hand.GetHandCategory());
        }

        [TestMethod]
        public void Should_return_straight_for_wheel_straight()
        {
            List<Card> cards = new List<Card>() 
            {
                new Card(Rank.Five, Suit.Spade),
                new Card(Rank.Four, Suit.Spade),
                new Card(Rank.Three, Suit.Diamond),
                new Card(Rank.Deuce, Suit.Spade),
                new Card(Rank.Ace, Suit.Club)
            };

            Hand hand = new Hand(cards);
            Assert.AreEqual(HandCategory.Straight, hand.GetHandCategory());
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

        [TestMethod]
        public void Should_return_correct_kickers_for_one_pair_hand()
        {
            Hand hand = new Hand(
                new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.Ace, Suit.Diamond),
                new Card(Rank.Jack, Suit.Spade),
                new Card(Rank.King, Suit.Club),
                new Card(Rank.Four, Suit.Spade)
            });


            IEnumerable<Card> kickers = hand.GetKickers();
            Assert.AreEqual(3, kickers.Count());
            Assert.IsTrue(new Card(Rank.King, Suit.Club).Equals(kickers.First()));
            Assert.IsTrue(new Card(Rank.Jack, Suit.Spade).Equals(kickers.Second()));
            Assert.IsTrue(new Card(Rank.Four, Suit.Spade).Equals(kickers.Third()));
        }

        [TestMethod]
        public void Should_return_correct_kicker_for_two_pair_hand()
        {
            Hand hand = new Hand(
                new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.Ace, Suit.Diamond),
                new Card(Rank.King, Suit.Spade),
                new Card(Rank.King, Suit.Club),
                new Card(Rank.Four, Suit.Spade)
            });


            IEnumerable<Card> kickers = hand.GetKickers();
            Assert.AreEqual(1, kickers.Count());
            Assert.IsTrue(new Card(Rank.Four, Suit.Spade).Equals(kickers.Single()));
        }

        [TestMethod]
        public void Should_return_correct_kickers_for_three_of_a_kind_hand()
        {
            Hand hand = new Hand(
                new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.Ace, Suit.Diamond),
                new Card(Rank.Ace, Suit.Club),
                new Card(Rank.Nine, Suit.Heart),
                new Card(Rank.Eigth, Suit.Spade)
            });


            IEnumerable<Card> kickers = hand.GetKickers();
            Assert.AreEqual(2, kickers.Count());
            Assert.IsTrue(new Card(Rank.Nine, Suit.Heart).Equals(kickers.First()));
            Assert.IsTrue(new Card(Rank.Eigth, Suit.Spade).Equals(kickers.Second()));
        }

        [TestMethod]
        public void Should_return_correct_kicker_for_four_of_a_kind_hand()
        {
            Hand hand = new Hand(
                new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.Ace, Suit.Diamond),
                new Card(Rank.Ace, Suit.Club),
                new Card(Rank.Ace, Suit.Heart),
                new Card(Rank.Eigth, Suit.Spade)
            });


            IEnumerable<Card> kickers = hand.GetKickers();
            Assert.AreEqual(1, kickers.Count());
            Assert.IsTrue(new Card(Rank.Eigth, Suit.Spade).Equals(kickers.First()));
        }


        [TestMethod]
        public void Should_return_null_when_get_kickers_for_highcard_flush_straightflush_and_straight()
        {
            // high card
            Assert.IsNull(new Hand(new List<Card>() 
            {
                 new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.King, Suit.Diamond),
                new Card(Rank.Jack, Suit.Heart),
                new Card(Rank.Five, Suit.Club),
                new Card(Rank.Three, Suit.Diamond)
            })
            .GetKickers());

            // flush
            Assert.IsNull(new Hand(new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.Jack, Suit.Spade),
                new Card(Rank.Nine, Suit.Spade),
                new Card(Rank.Eigth, Suit.Spade),
                new Card(Rank.Four, Suit.Spade)
            })
           .GetKickers());

            // straight
            Assert.IsNull(new Hand(new List<Card>() 
            {
                 new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.King, Suit.Diamond),
                new Card(Rank.Jack, Suit.Spade),
                new Card(Rank.Queen, Suit.Club),
                new Card(Rank.Ten, Suit.Spade)
            })
           .GetKickers());

            // straightflush
            Assert.IsNull(new Hand(new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.King, Suit.Spade),
                new Card(Rank.Jack, Suit.Spade),
                new Card(Rank.Queen, Suit.Spade),
                new Card(Rank.Ten, Suit.Spade)
            })
           .GetKickers());

        }

        [TestMethod]
        public void Should_be_able_to_instantiate_hand_using_string_representation()
        {
            Hand hand = new Hand("ac", "2d", "3h", "6d", "7s"); // ace club, deuce diamond, three heart, six diamond, seven spade
            Assert.AreEqual(Rank.Ace, hand.First().Rank);
            Assert.AreEqual(Suit.Club, hand.First().Suit);

            Assert.AreEqual(Rank.Deuce, hand.Second().Rank);
            Assert.AreEqual(Suit.Diamond, hand.Second().Suit);

            Assert.AreEqual(Rank.Three, hand.Third().Rank);
            Assert.AreEqual(Suit.Heart, hand.Third().Suit);

            Assert.AreEqual(Rank.Six, hand.Fourth().Rank);
            Assert.AreEqual(Suit.Diamond, hand.Fourth().Suit);

            Assert.AreEqual(Rank.Seven, hand.Fifth().Rank);
            Assert.AreEqual(Suit.Spade, hand.Fifth().Suit);
        }

    }
}
