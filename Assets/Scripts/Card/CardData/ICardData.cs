using System;
using UnityEngine;
using UnityEngine.Events;

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
        private string _description;

        [Space]
        [SerializeField]
        private UnityEvent _onUse;


        public string Name => _name;

        public int Cost => _cost;

        public string Description => _description;

        public UnityEvent OnUse => _onUse;

        public abstract void Initialize();

        public abstract void Clear();

        public abstract void Update();
    }
}
