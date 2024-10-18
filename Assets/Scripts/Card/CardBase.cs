using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Card
{
    public abstract class CardBase : MonoBehaviour
    {
        public abstract void MouseEnter();

        public abstract void MouseExit();

        public abstract void MouseClick();

        public void OnPointerEnter(PointerEventData eventData)
        {
            MouseEnter();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            MouseExit();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            MouseClick();
        }
    }

}