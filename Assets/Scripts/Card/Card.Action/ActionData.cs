using System;

namespace Card.Action
{
    [System.Serializable]
    public class ActionData : ICloneable
    {
        public ActionType actionType;

        public GrantType effect;
        public int value;

        // ī�� ���� �ʵ�
        public CardActionTarget cardTarget;
        public CardActionType cardAction;

        public object Clone()
        {
            // ���� ����: ��� ���� ���ο� ��ü�� �����Ͽ� ��ȯ
            return new ActionData
            {
                actionType = this.actionType,
                effect = this.effect,
                value = this.value,
                cardTarget = this.cardTarget,
                cardAction = this.cardAction
            };
        }
    }

}