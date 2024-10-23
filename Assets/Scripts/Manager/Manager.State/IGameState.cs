using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager.GameState 
{
    public interface IGameState
    {
        void Enter();

        void Exit();
    }
}
