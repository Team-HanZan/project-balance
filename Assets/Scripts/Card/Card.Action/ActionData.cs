using System;

namespace Card.Action
{
    [System.Serializable]
    public class ActionData : ICloneable
    {
        public ActionType actionType;

        public GrantType effect;
        public int value;

        // 카드 관련 필드
        public CardActionTarget cardTarget;
        public CardActionType cardAction;

        public object Clone()
        {
            // 깊은 복사: 모든 값을 새로운 객체로 복사하여 반환
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