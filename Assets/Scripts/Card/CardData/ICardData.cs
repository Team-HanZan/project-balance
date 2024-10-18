using System;
using UnityEngine;

namespace Card
{
    public abstract class ICardData : ScriptableObject
    {
        [SerializeField]
        private string _name;

        [Space]
        [SerializeField]
        private int _cost;

        [Space]
        [SerializeField]
        private Tier _tier;

        [Space]
        [SerializeField]
        [TextArea(4, 6)]
        private string _description;


        public string Name => _name;

        public int Cost => _cost;

        public Tier Tier => _tier;

        public string Description => _description;

        public abstract void Initialize();

        public abstract void Clear();

        public abstract void Update();
    }
}
