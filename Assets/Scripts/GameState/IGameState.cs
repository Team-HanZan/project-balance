using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameState
{
    public interface IGameState
    {
        void Enter();

        void Exit();

        bool IsComplete();
    }
}
