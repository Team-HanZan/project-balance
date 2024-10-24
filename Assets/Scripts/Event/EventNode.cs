using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Event
{
    [CreateAssetMenu(fileName = "NewEvent", menuName = "Event/EventNode")]
    public class EventNode : ScriptableObject, IEventNode
    {
        public EventName Name;
        public string Description; //text
        public Sprite EventImage;
        public int ChoiceNum;
        public string[] ChoiceText;
        //public UnityEvent EventAction;

        public List<UnityEvent> EventAction;

        public void End()
        {
            //event end
            throw new System.NotImplementedException();
        }

        public void Enroll()
        {
            // enroll method to button
            
        }

        public void Popup(EventUI eventUI)
        {
            eventUI.SetupUI(EventImage, Description);
            eventUI.SetUpChoiceButton(ChoiceNum, ChoiceText);
            eventUI.EnrollEvent(ChoiceNum, EventAction);
        }
        public bool Excute()
        {
            return false;
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

