using Card.Dictionary;
using Singletons;
using UnityEngine;
using Manager.GameState;
using Unity.VisualScripting;


namespace Manager
{
    public sealed class GameManager : SingletonBase<GameManager>
    {
        private CardDictionary _cardDictionary;

        private GameStateManager _gameStateManager;

        protected override void Awake()
        {
            base.Awake();
        }

        public void Initialize()
        {
            _cardDictionary = new CardDictionary();
            _cardDictionary.Initialize();

            Debug.Log(_cardDictionary.RandomCard.Name);
            Debug.Log(_cardDictionary.RandomCard.Name);
            Debug.Log(_cardDictionary.RandomCard.Name);

            GenerateGameStateManager();
        }


        private void GenerateGameStateManager()
        {
            var obj = new GameObject("GameStateManager");

            obj.transform.SetParent(this.transform, false);

            _gameStateManager = obj.GetOrAddComponent<GameStateManager>();

            _gameStateManager.Initialize();
        }
    }

}