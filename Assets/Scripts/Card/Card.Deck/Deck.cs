using System.Collections.Generic;
using UnityEngine;
using Card.Data;

namespace Card.Deck
{
    public sealed class Deck : MonoBehaviour
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
