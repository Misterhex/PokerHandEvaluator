using FizzWare.NBuilder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texas.Core.Portable.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void Should_be_able_to_populate_player_first_and_second_card_after_calling_deal_starting_hand_method()
        {
            IEnumerable<Player> players = Builder<Player>.CreateListOfSize(7).Build().ToList();

            Game game = new Game();
            game.DealStartingHands(players);

            Assert.IsTrue(players.Count() > 0);
            players.ToList().ForEach(player =>
            {
                Assert.IsNotNull(player.FirstCard); Assert.IsNotNull(player.SecondCard);
            });
        }

        [TestMethod]
        public void Should_be_having_3_cards_on_board_after_flop_and_4_cards_on_board_after_turn_and_5_cards_on_board_after_river()
        {
            Game game = new Game();

            Assert.AreEqual(0, game.Board.Count);

            game.DealFlop();
            Assert.AreEqual(3, game.Board.Count);

            game.DealTurn();
            Assert.AreEqual(4, game.Board.Count);

            game.DealRiver();
            Assert.AreEqual(5, game.Board.Count);
        }

        [TestMethod]
        public void Test()
        {
            IEnumerable<Player> players = Builder<Player>.CreateListOfSize(7).Build().ToList();
            Game game = new Game();
            game.DealStartingHands(players);
            game.DealFlop();
            game.DealTurn();
            game.DealRiver();

            var winners = game.GetMatchResult(players);

            throw new NotImplementedException();
        }

    }
}
