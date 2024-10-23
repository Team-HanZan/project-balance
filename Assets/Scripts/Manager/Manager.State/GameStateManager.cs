using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Utility;

namespace Manager.GameState
{
    public class GameStateManager : MonoBehaviour
    {

        private GameStateType _currentStateType;

        private IGameState _currentState;

        private bool _isInited;

        private FlagHolder _flagHolder;

        int _turnCount = 0;

        public GameStateType CurrentStateType
        {
            get
            {
                return _currentStateType;
            }

            set
            {
                if (_currentState != null)
                {
                    Debug.Log("정시온");
                    _currentState.Exit();
                }

                FlaggedCoroutine.Initialize();
                _flagHolder = FlaggedCoroutine.FlagHolder;

                IGameState newState = GetStateByType(value);

                newState.Enter();

                _currentStateType = value;
            }
        }

        private void Awake()
        {

        }

        private void Update()
        {
            if (_isInited)
            {
                if (_flagHolder.Done) 
                {
                    CurrentStateType = GetNextGameState();
                }
            }
        }

        public void Initialize()
        {
            Debug.Log("GameStateManager Initialized!");

            _isInited = false;
            CurrentStateType = GameStateType.RoundStart;
            _isInited = true;
        }


        private IGameState GetStateByType(GameStateType type)
        {
            return type switch
            {
                GameStateType.RoundStart => new RoundStartState(),
                GameStateType.TurnStart => new TurnStartState(),
                GameStateType.BeforeUseCard => new BeforeUseCardState(),
                GameStateType.AfterUseCard => new AfterUseCardState(),
                GameStateType.TurnEnd => new TurnEndState(),
                GameStateType.ApplyEmotion => new ApplyEmotionState(),
                GameStateType.RoundEnd => new RoundEndState(),
                _ => null
            };
        }

        public GameStateType GetNextGameState()
        {
            switch (CurrentStateType)
            {
                case GameStateType.RoundStart:
                    // RoundStart 후 TurnStart로 이동
                    _turnCount = 0;
                    return GameStateType.TurnStart;

                case GameStateType.TurnStart:
                    return GameStateType.BeforeUseCard;

                case GameStateType.BeforeUseCard:
                    return GameStateType.AfterUseCard;

                case GameStateType.AfterUseCard:
                    return GameStateType.ApplyEmotion;

                case GameStateType.ApplyEmotion:
                    return GameStateType.TurnEnd;

                case GameStateType.TurnEnd:
                    // TurnEnd가 끝난 후 TurnStart로 돌아가거나, 최대 횟수에 도달하면 RoundEnd로 이동
                    _turnCount++;
                    if (_turnCount < 3)
                    {
                        return GameStateType.TurnStart; // 다음 턴 시작
                    }
                    else
                    {
                        return GameStateType.RoundEnd; // 마지막 턴이 끝나면 RoundEnd로 이동
                    }

                case GameStateType.RoundEnd:
                    // RoundEnd 이후 필요에 따라 다시 RoundStart로 이동 (여기서는 예시로 루프)
                    return GameStateType.RoundStart;

                default:
                    throw new ArgumentOutOfRangeException(nameof(CurrentStateType), CurrentStateType, null);
            }
        }
    }

}