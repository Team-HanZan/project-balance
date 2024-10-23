using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Manager.GameState
{
    public class GameStateBase : IGameState
    {
        public virtual void Enter()
        {
            Debug.Log($"Enter {this.GetType().Name}");

            FlaggedCoroutine.Run(GameManager.Instance, WaitNTime(1));
        }

        public virtual void Exit()
        {
            Debug.Log($"Exit {this.GetType().Name}");
        }

        public IEnumerator WaitNTime(float time)
        {
            yield return new WaitForSeconds(time);
        }
    }
}