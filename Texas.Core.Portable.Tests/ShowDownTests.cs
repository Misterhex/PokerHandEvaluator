using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texas.Core.Portable.Tests
{
    [TestClass]
    public class ShowDownTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_catch_argument_exception_because_duplicated_card_was_passed_in_as_arguments()
        {
            List<Hand> allHands = new List<Hand>();

            // straightflush
            allHands.Add(new Hand(new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Club),
                new Card(Rank.King, Suit.Club),
                new Card(Rank.Jack, Suit.Club),
                new Card(Rank.Queen, Suit.Club),
                new Card(Rank.Ten, Suit.Club)
            }));
            // straightflush
            allHands.Add(new Hand(new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Club),
                new Card(Rank.King, Suit.Club),
                new Card(Rank.Jack, Suit.Club),
                new Card(Rank.Queen, Suit.Club),
                new Card(Rank.Ten, Suit.Club)
            }));

            ShowDown showDown = new ShowDown();
            showDown.GetWinners(allHands);
        }

        [TestMethod]
        public void Should_get_the_best_hands()
        {
            List<Hand> allHands = new List<Hand>();

            // high card
            allHands.Add(new Hand(new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.King, Suit.Club),
                new Card(Rank.Jack, Suit.Diamond),
                new Card(Rank.Five, Suit.Club),
                new Card(Rank.Three, Suit.Diamond)
            }));

            // flush
            allHands.Add(new Hand(new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Club),
                new Card(Rank.Jack, Suit.Club),
                new Card(Rank.Nine, Suit.Club),
                new Card(Rank.Eigth, Suit.Club),
                new Card(Rank.Four, Suit.Club)
            }));

            // straight
            allHands.Add(new Hand(new List<Card>() 
            {
                 new Card(Rank.Ace, Suit.Diamond),
                new Card(Rank.King, Suit.Diamond),
                new Card(Rank.Jack, Suit.Spade),
                new Card(Rank.Queen, Suit.Club),
                new Card(Rank.Ten, Suit.Spade)
            }));

            // straightflush
            allHands.Add(new Hand(new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Heart),
                new Card(Rank.King, Suit.Heart),
                new Card(Rank.Jack, Suit.Heart),
                new Card(Rank.Queen, Suit.Heart),
                new Card(Rank.Ten, Suit.Heart)
            }));

            ShowDown showDown = new ShowDown();
            var bestHands = showDown.GetWinners(allHands);

            Assert.IsTrue(bestHands.Single().Contains
                (new Card(Rank.Ace, Suit.Heart),
                new Card(Rank.King, Suit.Heart),
                new Card(Rank.Jack, Suit.Heart),
                new Card(Rank.Queen, Suit.Heart),
                new Card(Rank.Ten, Suit.Heart)));
        }

        [TestMethod]
        public void Should_get_the_best_hand_in_a_straight_flush_show_down()
        {
            List<Hand> allHands = new List<Hand>();

            // straightflush
            allHands.Add(new Hand(new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Club),
                new Card(Rank.King, Suit.Club),
                new Card(Rank.Jack, Suit.Club),
                new Card(Rank.Queen, Suit.Club),
                new Card(Rank.Ten, Suit.Club)
            }));


            // straightflush
            allHands.Add(new Hand(new List<Card>() 
            {
                new Card(Rank.Five, Suit.Club),
                new Card(Rank.Six, Suit.Club),
                new Card(Rank.Seven, Suit.Club),
                new Card(Rank.Eigth, Suit.Club),
                new Card(Rank.Nine, Suit.Club)
            }));

            // straightflush
            allHands.Add(new Hand(new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Heart),
                new Card(Rank.King, Suit.Heart),
                new Card(Rank.Jack, Suit.Heart),
                new Card(Rank.Queen, Suit.Heart),
                new Card(Rank.Ten, Suit.Heart)
            }));

            // straightflush
            allHands.Add(new Hand(new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Diamond),
                new Card(Rank.King, Suit.Diamond),
                new Card(Rank.Jack, Suit.Diamond),
                new Card(Rank.Queen, Suit.Diamond),
                new Card(Rank.Ten, Suit.Diamond)
            }));

            // straightflush
            allHands.Add(new Hand(new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.King, Suit.Spade),
                new Card(Rank.Jack, Suit.Spade),
                new Card(Rank.Queen, Suit.Spade),
                new Card(Rank.Ten, Suit.Spade)
            }));

            // straightflush
            allHands.Add(new Hand(new List<Card>() 
            {
                new Card(Rank.Two, Suit.Spade),
                new Card(Rank.Three, Suit.Spade),
                new Card(Rank.Four, Suit.Spade),
                new Card(Rank.Five, Suit.Spade),
                new Card(Rank.Six, Suit.Spade),
            }));

            ShowDown showDown = new ShowDown();
            var bestHands = showDown.GetWinners(allHands);

            Assert.IsTrue(bestHands.Single().Contains
                (new Card(Rank.Ace, Suit.Spade),
                new Card(Rank.King, Suit.Spade),
                new Card(Rank.Jack, Suit.Spade),
                new Card(Rank.Queen, Suit.Spade),
                new Card(Rank.Ten, Suit.Spade)));
        }

        [TestMethod]
        public void Should_get_the_best_hand_in_a_straight_show_down()
        {
            List<Hand> allHands = new List<Hand>();

            allHands.Add(new Hand(new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Heart),
                new Card(Rank.King, Suit.Club),
                new Card(Rank.Queen, Suit.Heart),
                new Card(Rank.Jack, Suit.Spade),
                new Card(Rank.Ten, Suit.Club)
            }));

            allHands.Add(new Hand(new List<Card>() 
            {
                new Card(Rank.Eigth, Suit.Diamond),
                new Card(Rank.Nine, Suit.Club),
                new Card(Rank.Jack, Suit.Club),
                new Card(Rank.Queen, Suit.Club),
                new Card(Rank.Ten, Suit.Spade)
            }));


            allHands.Add(new Hand(new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Diamond),
                new Card(Rank.King, Suit.Heart),
                new Card(Rank.Queen, Suit.Spade),
                new Card(Rank.Jack, Suit.Diamond),
                new Card(Rank.Ten, Suit.Diamond)
            }));


            ShowDown showDown = new ShowDown();
            var bestHands = showDown.GetWinners(allHands);

            Assert.IsTrue(bestHands.Single().Contains
                (new Card(Rank.Ace, Suit.Heart),
                new Card(Rank.King, Suit.Club),
                new Card(Rank.Queen, Suit.Heart),
                new Card(Rank.Jack, Suit.Spade),
                new Card(Rank.Ten, Suit.Club)));
        }

        [TestMethod]
        public void Should_get_the_best_hand_in_a_flush_show_down()
        {
            List<Hand> allHands = new List<Hand>();

            allHands.Add(new Hand(new List<Card>() 
            {
                new Card(Rank.King, Suit.Heart),
                new Card(Rank.Nine, Suit.Heart),
                new Card(Rank.Seven, Suit.Heart),
                new Card(Rank.Three, Suit.Heart),
                new Card(Rank.Two, Suit.Heart)
            }));

            allHands.Add(new Hand(new List<Card>() 
            {
                new Card(Rank.King, Suit.Club),
                new Card(Rank.Nine, Suit.Club),
                new Card(Rank.Seven, Suit.Club),
                new Card(Rank.Three, Suit.Club),
                new Card(Rank.Two, Suit.Club)
            }));

            allHands.Add(new Hand(new List<Card>() 
            {
                new Card(Rank.Ace, Suit.Diamond),
                new Card(Rank.Nine, Suit.Diamond),
                new Card(Rank.Seven, Suit.Diamond),
                new Card(Rank.Three, Suit.Diamond),
                new Card(Rank.Two, Suit.Diamond)
            }));


            ShowDown showDown = new ShowDown();
            var bestHands = showDown.GetWinners(allHands);

            Assert.IsTrue(bestHands.Single().Contains
                (new Card(Rank.King, Suit.Heart),
                new Card(Rank.Nine, Suit.Heart),
                new Card(Rank.Seven, Suit.Heart),
                new Card(Rank.Three, Suit.Heart),
                new Card(Rank.Two, Suit.Heart)));
        }
    }
}
