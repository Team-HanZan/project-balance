using Singletons;
using UnityEngine;
using Event;

namespace Manager
{
    public sealed class EventManager : SingletonBase<GameManager>
    {
        protected override void Awake()
        {
            base.Awake();
        }

        public EventNode GetEventByType()
        {

            return new EventNode();
        }
    }
}

