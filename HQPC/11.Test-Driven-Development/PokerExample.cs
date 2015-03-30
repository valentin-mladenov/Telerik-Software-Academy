using System;
using System.Collections.Generic;

namespace Poker
{
    class PokerExample
    {
        static void Main()
        {
			ICard card = new Card(CardFace.Ace, CardSuit.Clubs);
			ICard card1 = new Card(CardFace.King, CardSuit.Clubs);
			Console.WriteLine(card.Face - (card1.Face + 1));

			IHand hand = new Hand(new List<ICard>() { 
				new Card(CardFace.Ace, CardSuit.Clubs),	
				new Card(CardFace.Ace, CardSuit.Diamonds),
				new Card(CardFace.King, CardSuit.Hearts),
				new Card(CardFace.King, CardSuit.Spades),
				new Card(CardFace.Seven, CardSuit.Diamonds),
			});
			Console.WriteLine(hand);

			IPokerHandsChecker checker = new PokerHandsChecker();
			Console.WriteLine(checker.IsValidHand(hand));
			Console.WriteLine(checker.IsOnePair(hand));
			Console.WriteLine(checker.IsTwoPair(hand));


			//IHand handtest = new Hand(new List<ICard>() { 
			//	new Card(CardFace.Ace, CardSuit.Clubs),	
			//	new Card(CardFace.Three, CardSuit.Spades),
			//	new Card(CardFace.Ace, CardSuit.Hearts),
			//	new Card(CardFace.Ace, CardSuit.Spades),
			//	new Card(CardFace.Three, CardSuit.Diamonds)
			//});
			//IPokerHandsChecker checkertest = new PokerHandsChecker();


			//Console.WriteLine(checkertest.IsFullHouse(hand));

			//foreach (var cardtest in handtest.Cards)
			//{
			//	Console.WriteLine(cardtest.ToString());
			//}
        }
    }
}
