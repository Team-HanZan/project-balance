using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Event
{
    [CreateAssetMenu(fileName = "NewEvent", menuName = "Event/EventNode")]
    public class EventNode : ScriptableObject, IEventNode
    {
        public EventType Type;
        public string Description; //text
        public Image EventImage;
        public int ChoiceNum;
        public string[] ChoiceText;
        public UnityEvent EventAction; 

        public void End()
        {
            throw new System.NotImplementedException();
        }

        public void Enroll()
        {
            throw new System.NotImplementedException();
        }

        public void Popup()
        {
            throw new System.NotImplementedException();
        }
    }
    public enum EventType
    {
        Rest,TresureBox,HelpFallenGuy,
        Sacrifice,Greed,Swear,
        FortuneTeller,Donation,Pray,
        NightDuty,Storm,BackStab,
        Desire,BeStolen,InsultEachOther,
        TakeTest,SpeakCandidly,MakeSacrifice,
        GiveUpFood,Predictor
    }
}

