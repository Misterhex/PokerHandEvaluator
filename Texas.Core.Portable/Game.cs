using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Texas.Core.Portable
{
    public class Game
    {
        private Deck _deck = new Deck();

        public decimal Pot { get; private set; }
        public List<Card> Board { get; private set; }

        public Game()
        {
            this.Board = new List<Card>();
        }

        public void DealStartingHands(IEnumerable<Player> players)
        {
            // deal 1st card
            foreach (var player in players)
            {
                player.FirstCard = _deck.Pop();
            }
            // deal 2nd card
            foreach (var player in players)
            {
                player.SecondCard = _deck.Pop();
            }
        }

        /// <summary>
        /// Deal the flop (three face-up community cards)
        /// </summary>
        public void DealFlop()
        {
            _deck.Pop(); // burn card

            this.Board.Add(_deck.Pop());
            this.Board.Add(_deck.Pop());
            this.Board.Add(_deck.Pop());
        }

        /// <summary>
        ///  A single community card (called the turn or fourth street) is dealt
        /// </summary>
        public void DealTurn()
        {
            _deck.Pop(); // burn card

            this.Board.Add(_deck.Pop());
        }

        /// <summary>
        /// A final single community card (called the river or fifth street) is dealt
        /// </summary>
        public void DealRiver()
        {
            _deck.Pop(); // burn card

            this.Board.Add(_deck.Pop());
        }

        public void GetWinner(IEnumerable<Player> players)
        {
            players.Select(player => player.StartingHand.Concat(this.Board));

            //new ShowDown().GetWinners();
        }
    }

    public class Player
    {
        public Guid Id { get; private set; }

        public Card FirstCard { get; set; }
        public Card SecondCard { get; set; }

        public IEnumerable<Card> StartingHand
        {
            get
            {
                return new List<Card>() { this.FirstCard, this.SecondCard };
            }
        }

        public decimal Stake { get; private set; }

        public Player()
        {
            this.Id = Guid.NewGuid();
            this.Stake = 40m;
        }
    }
}
