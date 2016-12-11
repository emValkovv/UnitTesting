using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestFixture]
    public class PokerHandsCheckerTest
    {
        [Test]
        public void PokerHand_ConsistFiveDifferentCards_ShouldBeValid()
        {
            IList<ICard> cards = new List<ICard>();

            cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsValidHand(hand));
        }

        [Test]
        public void PokerHand_ConsistFiveDifferentCards_ShouldNotBeValid()
        {
            IList<ICard> cards = new List<ICard>();

            cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));

            Hand hand = new Hand(cards);
            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [Test]
        public void PokerHand_MustHaveExactly5Cards()
        {
            IList<ICard> cards = new List<ICard>();

            Assert.Throws<ArgumentException>(() => new Hand(cards));
        }

        [Test]
        public void Hand_CantHaveMoreThan5Cards()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Jack, CardSuit.Diamonds));

            Assert.Throws<ArgumentException>(() => new Hand(cards));
        }

        [Test]
        public void HandCheck_IsFlush_MustBeFlush()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFlush(hand));
        }

        [Test]
        public void HandCheck_IsNotFlush_MustNotBeFlush()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));

            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFlush(hand));
        }

        [Test]
        public void Hand_HasFourOfAKind()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Eight, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));
            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsTrue(checker.IsFourOfAKind(hand));
        }

        [Test]
        public void Hand_HasNotFourOfAKind()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ace, CardSuit.Clubs));
            cards.Add(new Card(CardFace.Eight, CardSuit.Hearts));
            cards.Add(new Card(CardFace.Eight, CardSuit.Spades));
            cards.Add(new Card(CardFace.Ten, CardSuit.Spades));
            Hand hand = new Hand(cards);

            PokerHandsChecker checker = new PokerHandsChecker();

            Assert.IsFalse(checker.IsFourOfAKind(hand));
        }

        //[Test]
        //public void HighCard_IsReally_HighCard()
        //{
        //    IList<ICard> cards = new List<ICard>();
        //    cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
        //    cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
        //    cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
        //    cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
        //    cards.Add(new Card(CardFace.Ten, CardSuit.Spades));

        //    Hand hand = new Hand(cards);

        //    PokerHandsChecker checker = new PokerHandsChecker();

        //    Assert.IsTrue(checker.IsHighCard(hand));
        //}
    }
}
