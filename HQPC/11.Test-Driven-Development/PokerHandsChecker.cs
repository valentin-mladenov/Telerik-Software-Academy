// Din't have time to make it all work as i want.

namespace Poker
{
	using System;
	using System.Collections.Generic;

    public class PokerHandsChecker : IPokerHandsChecker
    {
		public const int ValidHandLength = 5;

		private static void SelectionSort(IList<ICard> hand)
		{
			int min;
			ICard inner;

			for (int i = 0; i < ValidHandLength - 1; i++)
			{
				min = i;

				for (int j = i + 1; j < ValidHandLength; j++)
				{
					if (hand[j].Face.CompareTo(hand[min].Face) < 0)
					{
						min = j;
					}
				}

				inner = hand[i];
				hand[i] = hand[min];
				hand[min] = inner;
			}
		}

		private int CheckHandPower(IHand hand)
		{
			int power = 0;
			if (IsStraightFlush(hand)==true)
			{
				power = 9;
			}
			else if (IsFourOfAKind(hand) == true)
			{
				power = 8;
			}
			else if (IsFullHouse(hand) == true)
			{
				power = 7;
			}
			else if (IsFlush(hand) == true)
			{
				power = 6;
			}
			else if (IsStraight(hand) == true)
			{
				power = 5;
			}
			else if (IsThreeOfAKind(hand) == true)
			{
				power = 4;
			}
			else if (IsTwoPair(hand) == true)
			{
				power = 3;
			}
			else if (IsOnePair(hand) == true)
			{
				power = 2;
			}
			else
			{
				power = 1;
			}
			return power;
		}

        public bool IsValidHand(IHand hand)
        {
			bool isValid = true;
			if (hand.Cards.Count != ValidHandLength)
			{
				return isValid = false;
			}
			for (int i = 0; i < ValidHandLength-1; i++)
			{
				for (int j = i+1; j < ValidHandLength; j++)
				{
					if (hand.Cards[i].ToString() == hand.Cards[j].ToString())
					{
						return isValid = false;
					}
				}
			}
			return isValid;
        }

        public bool IsStraightFlush(IHand hand)
        {
			bool isFlush = IsFlush(hand);
			bool isStraight = IsStraight(hand);

			bool isStraightFlush = isFlush && isStraight;
			return isStraightFlush;
        }

        public bool IsFourOfAKind(IHand hand)
        {
			bool isFourOfAKind = false;
			int count = 1;

			for (int i = 0; i < ValidHandLength-3; i++)
			{
				for (int j = i + 1; j < ValidHandLength; j++)
				{
					if (hand.Cards[i].Face == hand.Cards[j].Face)
					{
						count++;
					}

					if (j==ValidHandLength-1 && count==ValidHandLength-1)
					{
						return isFourOfAKind = true;
					}
				}
				count = 1;
			}
			return isFourOfAKind;
        }

        public bool IsFullHouse(IHand hand)
        {
			SelectionSort(hand.Cards);
			bool isThreeOfAKind = IsThreeOfAKind(hand);

			if (!isThreeOfAKind)
			{
				return false;
			}
			else
			{
				if (hand.Cards[2].Face == hand.Cards[1].Face)
				{
					if ((hand.Cards[3].Face == hand.Cards[4].Face)
						&&(hand.Cards[3].Face != hand.Cards[2].Face))
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else if (hand.Cards[2].Face == hand.Cards[3].Face)
				{
					if ((hand.Cards[0].Face == hand.Cards[1].Face)
						&&(hand.Cards[1].Face != hand.Cards[2].Face))
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					return false;
				}

			}
        }

        public bool IsFlush(IHand hand)
        {
			bool isFlush = false;
			CardSuit firstCardSuit = hand.Cards[0].Suit;
			int count = 1;

			for (int i = 1; i < ValidHandLength; i++)
			{
				if (firstCardSuit != hand.Cards[i].Suit)
				{
					break;
				}
				count++;
				if (count==ValidHandLength)
				{
					isFlush = true;
				}
			}
			return isFlush;
        }

		public bool IsStraight(IHand hand)
		{
			SelectionSort(hand.Cards);

			bool isStraight = false;
			int count = 1;

			for (int i = 0; i < ValidHandLength - 1; i++)
			{
				if ((hand.Cards[i].Face + 1) == hand.Cards[i + 1].Face)
				{
					count++;
				}
				else
				{
					break;
				}

				if (count == ValidHandLength)
				{
					isStraight = true;
				}
			}
			return isStraight;
		}

        public bool IsThreeOfAKind(IHand hand)
        {
			bool isThreeOfAKind = false;
			int count = 1;

			for (int i = 0; i < ValidHandLength - 2; i++)
			{
				for (int j = i + 1; j < ValidHandLength; j++)
				{
					if (hand.Cards[i].Face == hand.Cards[j].Face)
					{
						count++;
					}

					if (j == ValidHandLength - 1 && count == ValidHandLength - 2)
					{
						return isThreeOfAKind = true;
					}
				}
				count = 1;
			}
			return isThreeOfAKind;
        }

		public bool IsTwoPair(IHand hand)
		{
			SelectionSort(hand.Cards);

			bool isTwoPair = false;
			bool firstPair = false;
			bool secondPair = false;
			int count = 0;

			for (int i = 0; i < ValidHandLength - 1; i++)
			{
				for (int j = i + 1; j < ValidHandLength; j++)
				{
					if (hand.Cards[i].Face == hand.Cards[j].Face)
					{
						firstPair= true;
						count = j;
						break;
					}
				}
				if (firstPair)
				{
					break;
				}
			}


			for (int i = count + 1; i < ValidHandLength - 1; i++)
			{
				for (int j = i + 1; j < ValidHandLength; j++)
				{
					if (hand.Cards[i].Face == hand.Cards[j].Face)
					{
						secondPair = true;
						break;
					}
				}
				if (secondPair)
				{
					break;
				}
			}

			if ((firstPair && secondPair) && ((hand.Cards[count].Face != hand.Cards[count+2].Face)))
			{
				return isTwoPair = true;
			}

			return isTwoPair;
		}

        public bool IsOnePair(IHand hand)
        {
			bool isOnePair = false;
			int count = 1;

			for (int i = 0; i < ValidHandLength - 1; i++)
			{
				for (int j = i + 1; j < ValidHandLength; j++)
				{
					if (hand.Cards[i].Face == hand.Cards[j].Face)
					{
						count++;
					}

					if (j == ValidHandLength - 1 && count == ValidHandLength - 3)
					{
						return isOnePair = true;
					}
				}
			}
			return isOnePair;
        }

		// IsHighCard check is pointless, coz it is the last posible option.
		// I din't remove it any way.
        public bool IsHighCard(IHand hand)
        {
			if (IsOnePair(hand)
				||IsTwoPair(hand)
				||IsThreeOfAKind(hand)
				||IsStraight(hand)
				||IsFlush(hand)
				||IsFullHouse(hand)
				||IsFourOfAKind(hand)
				||IsStraightFlush(hand))
			{
				return false;
			}
			else
			{
				return true;
			}
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
			if (!this.IsValidHand(firstHand))
			{
				throw new ArgumentOutOfRangeException("The first hand must have exactly 5 cards");
			}
			if (!this.IsValidHand(secondHand))
			{
				throw new ArgumentOutOfRangeException("The second hand must have exactly 5 cards");
			}

			int result = 0;
			int firsthandPower = CheckHandPower(firstHand);
			int secondHandPower = CheckHandPower(secondHand);

			if (firsthandPower>secondHandPower)
			{
				return 1;
			}
			else if (firsthandPower<secondHandPower)
			{
				return -1;
			}
			else
			{
				return 0;
			}
        }
    }
}
