using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Linq.Expressions;

namespace Texas.Core.Portable
{
    /// <summary>
    /// ShowDown a texas holdem game.
    /// </summary>
    public class ShowDown
    {
        class FlushAndStraightFlushShowDown
        {
            public IEnumerable<Hand> GetWinners(IEnumerable<Hand> hands)
            {
                // find highest suit.
                int highestSuit = hands.GroupBy(i => (int)i.ToList().First().Suit).Select(i => i.Key).Max();

                var highestSuitStraighFlushes = hands.Where(i => (int)i.First().Suit == highestSuit);

                // show down in same suit
                int highestCardPointInHighestSuit = highestSuitStraighFlushes.SelectMany(i => i).Max(i => i.Point);
                foreach (var hand in highestSuitStraighFlushes)
                {
                    if (hand.Where(i => i.Point == highestCardPointInHighestSuit).Any())
                        return new List<Hand>() { hand };
                }

                throw new InvalidOperationException("was unable to determine any winner, check algorithm for FlushAndStraightFlushShowDown");
            }
        }

        class StraightShowDown
        {
            public IEnumerable<Hand> GetWinners(IEnumerable<Hand> hands)
            {
                int highestCardPointInHighestSuit = hands.SelectMany(i => i).Max(i => i.Point);
                foreach (var hand in hands)
                {
                    if (hand.Where(i => i.Point == highestCardPointInHighestSuit).Any())
                        return new List<Hand>() { hand };
                }

                throw new InvalidOperationException("was unable to determine any winner, check algorithm for StraightShowDown");
            }
        }

        class FourOfAKindShowDown
        {
            public IEnumerable<Hand> GetWinners(IEnumerable<Hand> hands)
            {
                List<Rank> allFourOfAKindRanks = new List<Rank>();
                foreach (var hand in hands)
                {
                    var rank = hand.GroupBy(i => i.Rank).Where(j => j.Count() == 4).Select(i => i.Key).Single();
                    allFourOfAKindRanks.Add(rank);
                }
                Rank highestFourOfAKindRank = allFourOfAKindRanks.Max(i => i);
                IEnumerable<Hand> highestFourOfKindHands = hands
                    .Where(i => i.GroupBy(j => j.Rank).Where(k => k.Count() == 4)
                    .Single().Key == highestFourOfAKindRank).ToList();

                // challenge kicker
                int highestKicker = highestFourOfKindHands
                    .Select(hand => hand.GetKickers()
                        .First()).Max(i => i.Point);

                foreach (var highestHand in highestFourOfKindHands)
                {
                    if (highestHand.Where(i => i.Point == highestKicker).Any())
                        return new List<Hand>() { highestHand };
                }

                throw new InvalidOperationException("was unable to determine any winner, check algorithm for FourOfAKindShowDown");
            }
        }

        class ThreeOfAKindShowDown
        {
            public IEnumerable<Hand> GetWinners(IEnumerable<Hand> hands)
            {
                List<Rank> allThreeOfAKind = new List<Rank>();
                foreach (var hand in hands)
                {
                    var rank = hand.GroupBy(i => i.Rank).Where(j => j.Count() == 3).Select(i => i.Key).Single();
                    allThreeOfAKind.Add(rank);
                }
                Rank highestRank = allThreeOfAKind.Max(i => i);
                IEnumerable<Hand> winningHands = hands.Where(i => i.GroupBy(j => j.Rank).Where(k => k.Count() == 3).Single().Key == highestRank).ToList();

                Card highestKicker = winningHands.Select(i => i.GetKickers()).SelectMany(i => i).Max(i => i);

                foreach (var winningHand in winningHands)
                {
                    if (winningHand.Where(i => i == highestKicker).Any())
                    {
                        return new List<Hand>() { winningHand };
                    }
                }

                throw new InvalidOperationException("was unable to determine any winner, check algorithm for FourOfAKindShowDown");

            }
        }

        class TwoPairShowDown
        {
            class TwoPair
            {
                public Hand Hand { get; private set; }
                public Rank HigherPair { get; private set; }
                public Rank LowerPair { get; private set; }
                public Card Kicker { get; private set; }

                public TwoPair(Hand hand)
                {
                    this.Hand = hand;
                    var ranks = hand.GroupBy(i => i.Rank).Where(j => j.Count() == 2).Select(k => k.Key).OrderByDescending(i => i).ToList();
                    this.HigherPair = ranks.First();
                    this.LowerPair = ranks.Second();
                    this.Kicker = hand.GetKickers().Single();
                }
            }

            public IEnumerable<Hand> GetWinners(IEnumerable<Hand> hands)
            {
                //fix deadlocking code here.
                var twoPairHands = hands.Select(i => new TwoPair(i));

                TwoPair highestTwoPair = twoPairHands.OrderByDescending(i => i.HigherPair)
                    .ThenByDescending(j => j.LowerPair)
                    .ThenByDescending<TwoPair, Card>(k => k.Kicker, new CardComparer())
                    .First();

                return new List<Hand> { highestTwoPair.Hand };
            }
        }

        class OnePairShowDown
        {
            class OnePair
            {
                public Hand Hand { get; private set; }
                public Rank Pair { get; private set; }
                public Card Kicker { get; private set; }

                public OnePair(Hand hand)
                {
                    this.Hand = hand;
                    this.Pair = hand.GroupBy(i => i.Rank).Where(j => j.Count() == 2).Select(k => k.Key).Single();
                    this.Kicker = hand.GetKickers().First();
                }
            }

            public IEnumerable<Hand> GetWinners(IEnumerable<Hand> hands)
            {
                var onePairs = hands.Select(hand => new OnePair(hand));

                OnePair highest = onePairs
                    .OrderByDescending(i => i.Pair)
                    .ThenByDescending<OnePair, Card>(k => k.Kicker, new CardComparer())
                    .First();

                return new List<Hand> { highest.Hand };
            }
        }

        class HighCardShowDown
        {
            public IEnumerable<Hand> GetWinners(IEnumerable<Hand> hands)
            {
                int highestCardPoint = hands.SelectMany(i => i).Max(i => i.Point);
                foreach (var hand in hands)
                {
                    if (hand.Where(i => i.Point == highestCardPoint).SingleOrDefault() != null)
                        return new List<Hand>() { hand };
                }

                throw new InvalidOperationException("was unable to determine any winner, check algorithm for HighCardShowDown");
            }
        }

        public IEnumerable<Hand> GetWinners(IEnumerable<Hand> allHands)
        {
            if (allHands == null) throw new ArgumentNullException("allHands");
            if (allHands.Count() < 2) throw new ArgumentNullException("nothing to show down if less than 2 hands.");

            HandCategory highestCategory = allHands.Select(i => i.GetHandCategory()).Max();
            IEnumerable<Hand> highestHands = allHands.Where(i => i.GetHandCategory() == highestCategory);

            switch (highestCategory)
            {
                case HandCategory.StraightFlush:
                case HandCategory.Flush:
                    return new FlushAndStraightFlushShowDown().GetWinners(highestHands);
                case HandCategory.Straight:
                    return new StraightShowDown().GetWinners(highestHands);
                case HandCategory.FourOfAKind:
                    return new FourOfAKindShowDown().GetWinners(highestHands);
                case HandCategory.ThreeOfAKind:
                    return new ThreeOfAKindShowDown().GetWinners(highestHands);
                case HandCategory.TwoPair:
                    return new TwoPairShowDown().GetWinners(highestHands);
                case HandCategory.OnePair:
                    return new OnePairShowDown().GetWinners(highestHands);
                case HandCategory.HighCard:
                    return new HighCardShowDown().GetWinners(highestHands);
            }

            throw new NotSupportedException(string.Format("does not support getting winners for hand category {0}", highestCategory.ToString()));
        }
    }
}
