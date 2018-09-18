using System;
using System.Collections.Generic;

namespace Cards
{
    public class Player 
    {
        public string Name;

        public Deck d;

        public Player (string name) 
        {
            // Deck = d;
            Name = name;
        }

        public List<string> Hand = new List<string>();


        public void Draw (List<string> Cards) 
        {
            string card = d.DealCard(Cards);
        }

        public void Discard (List<string> Cards, int index)
        {
            Cards.RemoveAt(index);
        }
    }
}