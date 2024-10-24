using Singletons;
using UnityEngine;
using Event;
using System.Collections.Generic;
using System;

namespace Manager
{
    public sealed class EventManager : SingletonBase<GameManager>
    {
        private EventNode[] _events; // all event SO
        private EventNode _NowEvent; // excute Event
        protected override void Awake()
        {
            base.Awake();
            _events = Resources.LoadAll<EventNode>("Events");
            
            Array.Sort( _events ,(a,b)=> a.Name.CompareTo(b.Name));
        }

        public void InvokeEvent(EventName eventName)
        {
            _NowEvent = GetEventByType(eventName);
            //print(_NowEvent.Description);
        }

        public EventNode GetEventByType(EventName eventName)
        {
            EventNode eventNode = null;
            eventNode = _events[(int)eventName];
            return eventNode;
        }
    }
}

