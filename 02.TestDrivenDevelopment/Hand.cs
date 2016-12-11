using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            if (cards.Count != 5)
            {
                throw new ArgumentException("The hand must have 5 cards!");
            }
            else if (cards == null)
            {
                throw new ArgumentNullException("dada");
            }
            else
            {
                this.Cards = cards;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            for (int i = 0; i < 5; i++)
            {
                result.Append(Cards[i].ToString() + " ");
            }

            return result.ToString().Trim();

        }
    }
}
