using UnityEngine;

namespace Event
{
    public interface IEventNode
    {

        void Popup(EventUI eventUI);
        void Enroll();
        void End();
        bool Excute();
    }
}

