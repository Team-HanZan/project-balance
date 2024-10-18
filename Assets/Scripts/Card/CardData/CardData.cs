
using UnityEngine;
using UnityEngine.Events;

namespace Card.Data
{
    [CreateAssetMenu(fileName = "new Card", menuName = "Scriptable Objects/Card", order = int.MaxValue)]
    public class CardData : ICardData
    {

        private UnityEvent<object> _onUse;

        public UnityEvent<object> OnUse => _onUse;

        public override void Clear()
        {
            throw new System.NotImplementedException();
        }

        public override void Initialize()
        {
            // TODO: ī�� ȿ�� �޾ƿͼ� ȿ�� ���� ����� �߰�
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }
    }

}