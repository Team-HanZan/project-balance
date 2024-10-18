using UnityEngine;
using Card.Data;

namespace Card
{
    public sealed class Card
    {
        private CardData _data;

        public CardData Data => _data;


        public void Initialize()
        {
            _data = new CardData();
            _data.Initialize();
        }
    }

   
}