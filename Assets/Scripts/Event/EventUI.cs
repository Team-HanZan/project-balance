using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Event
{
    public class EventUI : MonoBehaviour
    {
        GameObject _mainCanvas;
        //GameObject _resultCanvas;

        Image _eventImage;

        TextMeshProUGUI _eventText;

        GameObject[] _choiceButton = new GameObject[3];
        Button _choiceButton1;
        Button _choiceButton2;
        Button _choiceButton3;

        TextMeshProUGUI[] _choiceText = new TextMeshProUGUI[3];

        TextMeshProUGUI _choiceText1;
        TextMeshProUGUI _choiceText2;
        TextMeshProUGUI _choiceText3;


        private void Awake()
        {
            _mainCanvas = transform.Find("EventMain").gameObject;
            _eventImage = _mainCanvas.transform.Find("EventImage")
                .gameObject.GetComponent<Image>();

            _eventText = _mainCanvas.transform.Find("EventDescription")
                .gameObject.GetComponent<TextMeshProUGUI>();



            _choiceButton[0] = _mainCanvas.transform.Find("Choice1")
                .gameObject;
            _choiceButton[1] = _mainCanvas.transform.Find("Choice2")
               .gameObject;
            _choiceButton[2] = _mainCanvas.transform.Find("Choice3")
               .gameObject;

            _choiceText[0] = _choiceButton[0].GetComponentInChildren<TextMeshProUGUI>();
            _choiceText[1] = _choiceButton[1].GetComponentInChildren<TextMeshProUGUI>();
            _choiceText[2] = _choiceButton[2].GetComponentInChildren<TextMeshProUGUI>();
        }

        public void SetupUI(Sprite eventImage, string eventText)
        {
            _mainCanvas.SetActive(true);
            _eventImage.sprite = eventImage;
            _eventText.text = eventText;
            print("event ui start");

        }
        public void SetUpChoiceButton(int choiceNum, string[] choiceText)
        {
            for(int i = 0; i < choiceNum; i++)
            {
                _choiceButton[i].gameObject.SetActive(true);
                _choiceText[i].text = choiceText[i];
            }
        }
    }
}

