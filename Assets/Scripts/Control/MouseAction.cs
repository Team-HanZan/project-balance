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

        #region ���콺 �Է� ó��
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
            // ���� �������� ȣ�� ������Ʈ�� ���� ȣ�� ������Ʈ�� �ٸ� ���
            if (_previousObject != _currentObject)
            {
                // ���� ������Ʈ���� ��� (Exit)
                if (_previousObject != null)
                {
                    OnExit(_previousObject);
                }
                

                // ���ο� ������Ʈ�� ���� (Enter)
                if (_currentObject != null)
                {
                    OnEnter(_currentObject);
                }

                // ���� ������Ʈ�� ���� ������Ʈ�� ������Ʈ
                _previousObject = _currentObject;
            }
        }

        #endregion

        private void OnEnter(GameObject obj)
        {
            Debug.Log("Enter: " + obj.name);
            // ������Ʈ�� ���� �� ó���� ���� �߰� (��: ���̶���Ʈ)
        }

        private void OnExit(GameObject obj)
        {
            Debug.Log("Exit: " + obj.name);
            // ������Ʈ���� ��� �� ó���� ���� �߰� (��: ���̶���Ʈ ����)
        }

        private void OnClick(GameObject obj)
        {
            Debug.Log("Click: " + obj.name);
            // Ŭ�� �� ó���� ���� �߰�
        }
    }

}