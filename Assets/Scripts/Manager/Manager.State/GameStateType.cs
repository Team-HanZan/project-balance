using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager.GameState
{
    public enum GameStateType
    {
        RoundStart,
        TurnStart,
        BeforeUseCard,
        AfterUseCard,
        ApplyEmotion,
        TurnEnd,
        RoundEnd,
    }
}