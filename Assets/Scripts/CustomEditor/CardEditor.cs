#if UNITY_EDITOR
using Card.Action;
using Card.Data;
using UnityEditor;
using UnityEngine;

namespace Custom
{
    [CustomEditor(typeof(CardData))]
    public class ActionManagerEditor : Editor
    {
        private SerializedProperty actionsProperty;

        private void OnEnable()
        {
            actionsProperty = serializedObject.FindProperty("_actionData");
        }

        public override void OnInspectorGUI()
        {
            // 시작
            serializedObject.Update();

            SerializedProperty property = serializedObject.GetIterator();
            property.NextVisible(true);  // 첫 번째 필드로 이동 (스크립트 필드 제외)

            do
            {
                if (property.name != "_actionData")  // 리스트 필드인 "actions"만 제외
                {
                    EditorGUILayout.PropertyField(property, true);
                }
            }
            while (property.NextVisible(false));  // 나머지 필드를 그립니다

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            // 큰 제목 스타일 정의
            GUIStyle titleStyle = new GUIStyle(EditorStyles.boldLabel);
            titleStyle.alignment = TextAnchor.MiddleCenter;  // 가운데 정렬
            titleStyle.normal.textColor = Color.green;  // 글씨 색상 노란색
            titleStyle.fontSize = 14;  // 글씨 크기

            // 큰 제목 출력
            EditorGUILayout.LabelField("카드 효과 리스트", titleStyle);

            // 다시 구분선 추가
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            EditorGUILayout.Space();

            // 리스트 상단: Add, Delete 버튼 및 리스트 개수 표시
            EditorGUILayout.BeginHorizontal();

            Color originalBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = Color.green;

            // "Add Action" 버튼
            if (GUILayout.Button("추가", GUILayout.Height(30)))
            {
                actionsProperty.arraySize++;  // 리스트 항목을 하나 추가
            }

            GUI.backgroundColor = Color.red;

            // "Delete Last Action" 버튼
            if (GUILayout.Button("제거", GUILayout.Height(30)))
            {
                if (actionsProperty.arraySize > 0)
                {
                    actionsProperty.DeleteArrayElementAtIndex(actionsProperty.arraySize - 1);  // 마지막 항목 삭제
                }
            }

            GUI.backgroundColor = originalBackgroundColor;

            // 리스트 항목 수 표시
            string effectsCountText = $"{actionsProperty.arraySize}";

            GUIStyle centeredStyle = new GUIStyle(GUI.skin.box);
            centeredStyle.alignment = TextAnchor.MiddleCenter;  // 텍스트를 가운데 정렬


            GUILayout.Box(effectsCountText, centeredStyle, GUILayout.Height(30), GUILayout.ExpandWidth(true));

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();  // 공백 추가

            // 커스텀 테두리 스타일 생성
            GUIStyle boxStyleWithBorder = new GUIStyle(GUI.skin.box);
            boxStyleWithBorder.margin = new RectOffset(10, 10, 10, 10);  // 마진 설정
            boxStyleWithBorder.padding = new RectOffset(10, 10, 10, 10);  // 패딩 설정

            // 배경 색상 설정을 위해 텍스처 생성 (어두운 회색)
            Texture2D backgroundTexture = new Texture2D(1, 1);
            backgroundTexture.SetPixel(0, 0, new Color(0.2f, 0.2f, 0.2f));  // 어두운 회색
            backgroundTexture.Apply();

            boxStyleWithBorder.normal.background = backgroundTexture;  // 배경으로 설정
            boxStyleWithBorder.normal.textColor = Color.white;  // 텍스트 색상 흰색

            // 리스트 항목을 박스 형태로 출력
            for (int i = 0; i < actionsProperty.arraySize; i++)
            {
                SerializedProperty actionData = actionsProperty.GetArrayElementAtIndex(i);

                // 박스 스타일을 적용하여 출력 (레이아웃이 깨지지 않도록)
                EditorGUILayout.BeginVertical(boxStyleWithBorder);  // 테두리 및 배경을 포함한 박스 스타일

                EditorGUILayout.Space();

                SerializedProperty actionTypeProperty = actionData.FindPropertyRelative("actionType");
                EditorGUILayout.PropertyField(actionTypeProperty, new GUIContent($"효과 타입"));

                ActionType actionType = (ActionType)actionTypeProperty.enumValueIndex;

                string previewText = "";  // 미리보기 텍스트

                // ActionType에 따른 필드 및 미리보기 텍스트 처리
                if (actionType == ActionType.Assign)
                {
                    EditorGUILayout.Space();
                    SerializedProperty effectProperty = actionData.FindPropertyRelative("effect");
                    SerializedProperty valueProperty = actionData.FindPropertyRelative("value");

                    // A 아래 A1 표시: Effect 먼저, 그 아래 Value
                    EditorGUILayout.PropertyField(effectProperty, new GUIContent("효과"));
                    EditorGUILayout.Space();  // 간격 추가
                    EditorGUILayout.PropertyField(valueProperty, new GUIContent("값"));

                    // 미리보기 텍스트 생성
                    previewText = $"{effectProperty.enumNames[effectProperty.enumValueIndex]}을(를) {valueProperty.intValue} 부여합니다.";
                }
                else if (actionType == ActionType.Card)
                {
                    EditorGUILayout.Space();
                    SerializedProperty cardTargetProperty = actionData.FindPropertyRelative("cardTarget");
                    SerializedProperty cardActionProperty = actionData.FindPropertyRelative("cardAction");

                    // A 아래 A1 표시: Card Target 먼저, 그 아래 Card Action
                    EditorGUILayout.PropertyField(cardTargetProperty, new GUIContent("대상 카드"));
                    EditorGUILayout.Space();  // 간격 추가
                    EditorGUILayout.PropertyField(cardActionProperty, new GUIContent("효과"));

                    // 카드 관련 미리보기 텍스트
                    previewText = $"{cardTargetProperty.enumNames[cardTargetProperty.enumValueIndex]} 카드를 {cardActionProperty.enumNames[cardActionProperty.enumValueIndex]}합니다.";
                }

                // 미리보기 박스 출력
                GUIStyle previewStyle = new GUIStyle(EditorStyles.helpBox);
                previewStyle.alignment = TextAnchor.MiddleCenter;
                previewStyle.fontSize = 14;
                previewStyle.normal.textColor = Color.yellow;

                GUILayout.Space(10);  // 타겟/액션과 미리보기 텍스트 사이에 간격 추가
                GUILayout.Label(previewText, previewStyle, GUILayout.Height(30));

                EditorGUILayout.EndVertical();  // 박스 스타일 끝
                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);  // 구분선 추가
            }

            // 변경된 내용을 적용
            serializedObject.ApplyModifiedProperties();
        }
    }
}

#endif
