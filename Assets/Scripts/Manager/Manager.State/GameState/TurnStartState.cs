using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Manager.GameState
{

    public class TurnStartState : GameStateBase
    {
        public override void Enter()
        {
            base.Enter();

            FlaggedCoroutine.Run(GameManager.Instance, WaitNTime(1));
            FlaggedCoroutine.Run(GameManager.Instance, WaitNTime(2));
        }

        public override void Exit()
        {
            base.Exit();
        }

    }
}