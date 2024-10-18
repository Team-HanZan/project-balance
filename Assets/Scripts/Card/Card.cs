using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Card
{
    public class Card : CardBase
    {
        private CardData _data;

        public CardData Data => _data;


        public void Initialize()
        {
            _data = new CardData();
            _data.Initialize();
        }

        public override void MouseClick()
        {
            Debug.Log("Test Click Method");
        }

        public override void MouseEnter()
        {
            throw new System.NotImplementedException();
        }

        public override void MouseExit()
        {
            throw new System.NotImplementedException();
        }
    }
}