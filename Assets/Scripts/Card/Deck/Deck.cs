using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singletons;

namespace Card.Deck
{
    public class Deck : MonoBehaviour
    {
        public List<CardData> Cards { get; private set; }


        public void Initialize()
        {
            Cards = new List<CardData>();
        }

    }
}
