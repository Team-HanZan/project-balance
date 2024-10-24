using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Event
{
    [CreateAssetMenu(fileName = "NewEvent", menuName = "Event/EventNode")]
    public class EventNode : ScriptableObject, IEventNode
    {
        public EventName Name;
        public string Description; //text
        public Image EventImage;
        public int ChoiceNum;
        public string[] ChoiceText;
        public UnityEvent EventAction; 

        public void End()
        {
            //event end
            throw new System.NotImplementedException();
        }

        public void Enroll()
        {
            // enroll method to button
            throw new System.NotImplementedException();
        }

        public void Popup()
        {
            // ui open and show event data
            throw new System.NotImplementedException();
        }
    }
    public enum EventName
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

