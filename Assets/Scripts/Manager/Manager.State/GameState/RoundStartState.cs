using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Manager.GameState
{
    public class RoundEndState : GameStateBase
    {
        public override void Enter()
        {
            base.Enter();

            FlaggedCoroutine.Run(GameManager.Instance, WaitNTime(1));
        }

        public override void Exit()
        {
            base.Exit();
        }

    }
}
