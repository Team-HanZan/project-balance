using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Event
{
    public class EventUI : MonoBehaviour
    {
        GameObject _mainCanvas;
        //GameObject _resultCanvas;

        Image _eventImage;

        TextMeshProUGUI _eventText;

        //meObject[] _choiceButton = new GameObject[3];
        Button[] _choiceButton = new Button[3];
     
        TextMeshProUGUI[] _choiceText = new TextMeshProUGUI[3];

        private void Awake()
        {
            _mainCanvas = transform.Find("EventMain").gameObject;
            _eventImage = _mainCanvas.transform.Find("EventImage")
                .gameObject.GetComponent<Image>();

            _eventText = _mainCanvas.transform.Find("EventDescription")
                .gameObject.GetComponent<TextMeshProUGUI>();

            //_choiceButton[1] = _mainCanvas.transform.Find("Choice2")
            //   .gameObject;

            _choiceButton[0] = _mainCanvas.transform.Find("Choice1")
                .GetComponent<Button>();
            _choiceButton[1] = _mainCanvas.transform.Find("Choice2")
               .GetComponent<Button>();
            _choiceButton[2] = _mainCanvas.transform.Find("Choice3")
               .GetComponent<Button>();

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
        public void EnrollEvent(int choiceNum, List<UnityEvent> unityEvents)
        {

            print(choiceNum);
            for (int i = 0; i < choiceNum; i++)
            {
                Debug.Log(_choiceButton[i]);
                Debug.Log(unityEvents[i]);
                var _event = unityEvents[i];
                _choiceButton[i].onClick.AddListener(() => { Debug.Log(i); _event?.Invoke(); });
                
            }
        }

    }
}

