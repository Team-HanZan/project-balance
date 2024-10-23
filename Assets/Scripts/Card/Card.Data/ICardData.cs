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
            // 깊은 복사: 새 객체를 생성하고, 모든 필드 값을 복사
            var clonedCard = Instantiate(this); // ScriptableObject의 인스턴스를 복사

            // 참조 타입인 ActionData 리스트를 깊은 복사
            clonedCard._actionData = new List<ActionData>(_actionData.Count);
            foreach (var action in _actionData)
            {
                clonedCard._actionData.Add(action.Clone() as ActionData); // ActionData가 ICloneable을 구현한다고 가정
            }

            return clonedCard;
        }
    }
}
