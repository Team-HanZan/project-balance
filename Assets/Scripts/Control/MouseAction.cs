using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using Singletons;
using Unity.VisualScripting;


namespace Control
{
    public sealed class MouseAction : SingletonBase<MouseAction>
    {
        private EventSystem _eventSystem;
        private GraphicRaycaster _raycaster;


        private GameObject _previousObject;
        private GameObject _currentObject;

        public GameObject CurrentObject => _currentObject;

        private bool _available;

        protected override void Awake()
        {
            base.Awake();
        }

        public void Initialize()
        {
            _previousObject = null;
            _currentObject = null;

            _available = false;

            _eventSystem = GameObject.FindObjectOfType<EventSystem>();

            _raycaster = GameObject.Find("MainCanvas").GetOrAddComponent<GraphicRaycaster>();  
        }

        #region 마우스 입력 처리
        private void Update()
        {
            if (!_available) return;

            CastCurrentMousePositionUI();

            DetectClickEveryFrame();
        }

        public void CastCurrentMousePositionUI()
        {
            PointerEventData pointerEventData = new PointerEventData(_eventSystem);
            pointerEventData.position = Input.mousePosition;


            List<RaycastResult> results = new List<RaycastResult>();

            _raycaster.Raycast(pointerEventData, results);


            if (results.Count > 0)
            {
                _currentObject = results[0].gameObject;
            }
            else
            {
                _currentObject = null;
            }

            HandleEnterExitEvents();
        }

        public void DetectClickEveryFrame()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_currentObject != null)
                {
                    OnClick(_currentObject);
                }
            }
        }

        private void HandleEnterExitEvents()
        {
            // 이전 프레임의 호버 오브젝트와 현재 호버 오브젝트가 다른 경우
            if (_previousObject != _currentObject)
            {
                // 이전 오브젝트에서 벗어남 (Exit)
                if (_previousObject != null)
                {
                    OnExit(_previousObject);
                }
                

                // 새로운 오브젝트에 진입 (Enter)
                if (_currentObject != null)
                {
                    OnEnter(_currentObject);
                }

                // 현재 오브젝트를 이전 오브젝트로 업데이트
                _previousObject = _currentObject;
            }
        }

        #endregion

        private void OnEnter(GameObject obj)
        {
            Debug.Log("Enter: " + obj.name);
            // 오브젝트에 진입 시 처리할 내용 추가 (예: 하이라이트)
        }

        private void OnExit(GameObject obj)
        {
            Debug.Log("Exit: " + obj.name);
            // 오브젝트에서 벗어날 때 처리할 내용 추가 (예: 하이라이트 제거)
        }

        private void OnClick(GameObject obj)
        {
            Debug.Log("Click: " + obj.name);
            // 클릭 시 처리할 내용 추가
        }
    }

}