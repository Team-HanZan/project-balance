using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Card.Action
{
    public enum GrantActionTarget
    {
        Sion,
        King,
        All
    }

    public enum CardActionTarget
    {
        AllCardsInDeck,
        AllCardsInHand,
        AllCardsInUsed,
        AllCardsInUnUsed,
        RandomCardsInHand,
        SpecificCards,
    }

}