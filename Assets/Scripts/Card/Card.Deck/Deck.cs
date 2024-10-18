using System.Collections.Generic;
using UnityEngine;

namespace Card.Deck
{
    public class Deck : MonoBehaviour
    {
        public List<CardData> Cards { get; private set; }


        public void Initialize()
        {
            Cards = new List<CardData>();
        }

        public void LoadCardData()
        {

        }

    }
}
