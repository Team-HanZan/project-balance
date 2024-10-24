using Singletons;
using UnityEngine;
using Event;
using System;

namespace Manager
{
    public sealed class EventManager : SingletonBase<GameManager>
    {
        private EventNode[] _events; // all event SO
        private EventNode _NowEvent; // excute Event
        private EventUI _eventUI;
        protected override void Awake()
        {
            base.Awake();
            _events = Resources.LoadAll<EventNode>("Events");
            _eventUI = GameObject.Find("EventCanvase").GetComponent<EventUI>();
            Array.Sort( _events ,(a,b)=> a.Name.CompareTo(b.Name));

            InvokeEvent(EventName.Rest);
        }

        public void InvokeEvent(EventName eventName)
        {
            _NowEvent = GetEventByType(eventName);
            //print(_NowEvent.Description);
            _NowEvent.Popup(_eventUI);
            //_NowEvent.Enroll();

        }
        public EventNode GetEventByType(EventName eventName)
        {
            EventNode eventNode = null;
            eventNode = _events[(int)eventName];
            return eventNode;
        }
    }
}

