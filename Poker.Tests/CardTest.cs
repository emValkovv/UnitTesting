using System;
using NUnit.Framework;
using Poker;

namespace Poker.Tests
{
    [TestFixture]
    public class CardTest
    {
        [TestCase(CardFace.Eight, CardSuit.Diamonds)]
        [TestCase(CardFace.Five, CardSuit.Spades)]
        public void Card_ShouldBeCreatedCorrectly(CardFace a, CardSuit b)
        {
            Card card = new Card(a, b);
            string cardFaceAndSuit = a + " " + b;
            Assert.AreEqual(cardFaceAndSuit, card.ToString());
        }
    }
}
