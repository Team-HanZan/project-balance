using Card.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Card.Dictionary
{
    public sealed class CardDictionary
    {

        Dictionary<Tier, Dictionary<CharacterType, List<ICardData>>> cardDataDictionary;

        public ICardData RandomCard
        {
            get
            {
                // 모든 Tier와 CharacterType에 해당하는 카드 리스트를 모은다
                var allCards = cardDataDictionary
                    .SelectMany(tier => tier.Value.SelectMany(characterType => characterType.Value))
                    .ToList();

                // 카드가 없을 경우 null을 반환한다
                if (allCards.Count == 0)
                    return null;

                // 무작위로 카드를 선택한다
                var random = new System.Random();
                var selectedCard = allCards[random.Next(allCards.Count)];

                // 선택된 카드의 복사본을 반환한다 (카피를 위한 ICloneable 인터페이스 사용 가정)
                return (ICardData)selectedCard.Clone();
            }
        }

        public void Initialize()
        {
            cardDataDictionary = new Dictionary<Tier, Dictionary<CharacterType, List<ICardData>>>();

            LoadAllCards();
            PrintAllCards();

        }

        public List<ICardData> this[Tier tier]
        {
            get
            {
                if (cardDataDictionary.ContainsKey(tier))
                {
                    Dictionary<CharacterType, List<ICardData>> dict = cardDataDictionary[tier];

                    List<ICardData> tierCardList = new List<ICardData>();

                    foreach (var list in dict)
                    {
                        tierCardList.AddRange(list.Value);
                    }

                    return tierCardList.ToList();
                }

                return new List<ICardData>();
            }


        }

        public void AddCard(ICardData card)
        {
            if (!cardDataDictionary.ContainsKey(card.Tier))
            {
                cardDataDictionary[card.Tier] = new Dictionary<CharacterType, List<ICardData>>();
            }

            if (!cardDataDictionary[card.Tier].ContainsKey(card.Target))
            {
                cardDataDictionary[card.Tier][card.Target] = new List<ICardData>();
            }

            cardDataDictionary[card.Tier][card.Target].Add(card);
        }

        private void LoadAllCards()
        {
            ICardData[] cards = Resources.LoadAll<ICardData>("Cards");

            foreach (ICardData card in cards)
            {
                AddCard(card);
            }
        }

        private void ClearAllCards()
        {
            cardDataDictionary.Clear();
        }

        private void PrintAllCards()
        {
            foreach (var tierEntry in cardDataDictionary)
            {
                Tier tier = tierEntry.Key;
                Dictionary<CharacterType, List<ICardData>> characterTypeDict = tierEntry.Value;

                foreach (var characterTypeEntry in characterTypeDict)
                {
                    CharacterType characterType = characterTypeEntry.Key;
                    List<ICardData> cardDataList = characterTypeEntry.Value;

                    foreach (var cardData in cardDataList)
                    {
                        Debug.Log(cardData.Name);
                    }
                }
            }
        }
    }
}