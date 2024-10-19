using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singletons;
using Card.Data;

namespace Card.Dictionary
{
    public class CardDictionary
    {

        public CardData this[int index]
        {
            get
            {
                return this[index]; 
            }
            
            set
            {
                this[index] = value;
            }
        }

        
    }
}