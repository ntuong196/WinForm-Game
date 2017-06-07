using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Low_Level_Objects_Library {
    /// <summary>
    /// Hand class consists of lists of cards and methods 
    /// Include add, remove, and sort cards
    /// </summary>
    public class Hand : IEnumerable {
        private List<Card> hand = new List<Card>();
        // creates an empty hand (object)
        public Hand() {
        }
        // creates hand from a list of cards passed as the parameter
        public Hand(List<Card> cards) {
            foreach (Card card in cards) {
                hand.Add(card);
            }
        }
        // returns the number of cards in the hand
        public int GetCount() {
            return hand.Count();
        }
        // returns the card at specified position (index) but does not remove that card from the hand
        
        public Card GetCard(int index) {
            return hand[index];
        }

        // adds a card to the hand
        public void Add(Card card) {
            hand.Add(card);
        }
        // returns true if hand contain the specified card

        //public bool Contains(Card card) {
        //    return hand.Contains(card);
        //}
        public bool Contains(Card card) {
            for (int i = 0; i < hand.Count; i++) {
                if ((hand[i].GetFaceValue() == card.GetFaceValue()) && (hand[i].GetSuit() == card.GetSuit())) {
                    return true;
                }
            }
            return false;
        }
        // removes a specified card from the hand is the card is in the hand

        //public bool Remove(Card card) {
        //    return hand.Remove(card);
        //}
        public bool Remove(Card card) {
            for (int i = 0; i < hand.Count; i++) {
                if (Contains(card) == true) {
                    hand.Remove(card);
                    return true;
                }
            }
            return false;
        }
        // removes the card at the specified position in the hand where index is zero-based index value.

        public void RemoveAt(int index) {
            hand.RemoveAt(index);
        }
        // sorts the cards in the hand

        public void Sort() {
            hand.Sort();
        }

        // Method to allow access to the IEnumerator class
        public IEnumerator GetEnumerator() {
            return hand.GetEnumerator();
        }
    }
}
