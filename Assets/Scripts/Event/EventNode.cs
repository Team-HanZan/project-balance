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
        Rest,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,
    }
}

