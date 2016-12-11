using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestFixture]
    public class HandTest
    {

        [Test]
        public void Hand_ShouldBeShowedCorrecty()
        {
            IList<ICard> cards = new List<ICard>();
            cards.Add(new Card(CardFace.Eight, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Five, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.King, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Seven, CardSuit.Diamonds));
            cards.Add(new Card(CardFace.Ten, CardSuit.Diamonds));
            Hand hand = new Hand(cards);

            string handString = cards[0] + " " + 
                                cards[1].ToString() + " " + 
                                cards[2].ToString() + " " + 
                                cards[3].ToString() + " " + 
                                cards[4].ToString();

            Assert.AreEqual(handString, hand.ToString());
        }
    }
}
