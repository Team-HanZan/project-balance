using UnityEngine;
using UnityEngine.Events;

namespace Card.Data
{
    [CreateAssetMenu(fileName = "new Card", menuName = "Scriptable Objects/Card", order = int.MaxValue)]
    public sealed class CardData : ICardData
    {

        private UnityEvent<object> _onUse;

        public UnityEvent<object> OnUse => _onUse;

        public override void Clear()
        {
            throw new System.NotImplementedException();
        }

        public override void Initialize()
        {
            // TODO: 카드 효과 받아와서 효과 적용 페이즈에 추가

            throw new System.NotFiniteNumberException();
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }
    }

}