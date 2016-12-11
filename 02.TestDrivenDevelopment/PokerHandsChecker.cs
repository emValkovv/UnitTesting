using System;
using System.Linq;
using System.Collections.Generic;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5)
            {
                throw new ArgumentException("The hand must have exactly 5 cards!");
            }
            
            foreach (var card in hand.Cards)
            {
                int count = 0;
                foreach (var c in hand.Cards)
                {
                    if (card.ToString() != c.ToString())
                    {
                        count++;
                    }
                }
                if (count != 4)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
                foreach (var card in hand.Cards)
                {
                    int count = 0;
                    foreach (var c in hand.Cards)
                    {
                        if (card.Face == c.Face)
                        {
                            count++;
                        }
                    }
                    if (count == 4)
                    {
                        return true;
                    }
                }
            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            if (this.IsValidHand(hand))
            {
                foreach (var card in hand.Cards)
                {
                    int count = 0;
                    foreach (var c in hand.Cards)
                    {
                        if (card.Suit == c.Suit)
                        {
                            count++;
                        }
                    }
                    if (count == 5)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
