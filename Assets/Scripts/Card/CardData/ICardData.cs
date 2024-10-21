using Card.Action;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Card
{
    public abstract class ICardData : ScriptableObject, ICloneable
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
        private CharacterType _target;

        [Space]
        [SerializeField]
        private List<ActionData> _actionData;


        public string Name => _name;

        public int Cost => _cost;

        public Tier Tier => _tier;

        public CharacterType Target => _target;

        public List<ActionData> ActionData => _actionData;

        public abstract void Initialize();

        public abstract void Clear();

        public abstract void Update();

        public object Clone()
        {
            // ���� ����: �� ��ü�� �����ϰ�, ��� �ʵ� ���� ����
            var clonedCard = Instantiate(this); // ScriptableObject�� �ν��Ͻ��� ����

            // ���� Ÿ���� ActionData ����Ʈ�� ���� ����
            clonedCard._actionData = new List<ActionData>(_actionData.Count);
            foreach (var action in _actionData)
            {
                clonedCard._actionData.Add(action.Clone() as ActionData); // ActionData�� ICloneable�� �����Ѵٰ� ����
            }

            return clonedCard;
        }
    }
}
