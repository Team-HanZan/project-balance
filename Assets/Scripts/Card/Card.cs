using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singletons;

namespace Card
{
    public class CardData
    {
        public int Cost { get; set; }
        public string Name { get; set; }

        internal CardData()
        {
            Cost = -1;
            Name = null;
        }
    }
}