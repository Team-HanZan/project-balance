using Card.Dictionary;
using Singletons;
using UnityEngine;

namespace Manager
{

    public sealed class GameManager : SingletonBase<GameManager>
    {
        private CardDictionary cardDictionary;


        protected override void Awake()
        {
            base.Awake();

        }

        public void Initialize()
        {
            cardDictionary = new CardDictionary();
            cardDictionary.Initialize();

            Debug.Log(cardDictionary.RandomCard.Name);
            Debug.Log(cardDictionary.RandomCard.Name);
            Debug.Log(cardDictionary.RandomCard.Name);
        }

    }

}