namespace Santase.Logic.Cards.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class DeckTest
    {
        [Test]
        public void CardDeckMustBe24CardsAtBegining()
        {
            Deck deck = new Deck();

            Assert.AreEqual(24, deck.CardsLeft);
        }

        [Test]
        public void CanDrawNewCardWhenDeckIsEmpty()
        {
            Deck deck = new Deck();
            for (int i = 0; i < 24; i++)
            {
                var card = deck.GetNextCard();
            }

            Assert.Throws<InternalGameException>(() => deck.GetNextCard());
        }

        [Test]
        public void ChangeCardWithTrumCard()
        {
            Deck deck = new Deck();
            var card = new Card(CardSuit.Spade, CardType.King);

            deck.ChangeTrumpCard(card);

            Assert.AreEqual(card, deck.TrumpCard);
        }

        [TestCase(CardSuit.Club, CardType.Nine)]
        [TestCase(CardSuit.Spade, CardType.King)]
        public void ChangeTrumCardWithNullCard(CardSuit a, CardType b)
        {
            Deck deck = new Deck();
            var card = new Card(a, b);

            deck.ChangeTrumpCard(card);

            Assert.AreEqual(card, deck.TrumpCard);
        }

        [Test]
        public void NextCardCantBeNull()
        {
            Deck deck = new Deck();
            var card = deck.GetNextCard();

            Assert.AreNotEqual(null, card);
        }
    }
}
