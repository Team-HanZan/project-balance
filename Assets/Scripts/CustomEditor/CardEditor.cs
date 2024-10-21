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
            // ����
            serializedObject.Update();

            SerializedProperty property = serializedObject.GetIterator();
            property.NextVisible(true);  // ù ��° �ʵ�� �̵� (��ũ��Ʈ �ʵ� ����)

            do
            {
                if (property.name != "_actionData")  // ����Ʈ �ʵ��� "actions"�� ����
                {
                    EditorGUILayout.PropertyField(property, true);
                }
            }
            while (property.NextVisible(false));  // ������ �ʵ带 �׸��ϴ�

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            // ū ���� ��Ÿ�� ����
            GUIStyle titleStyle = new GUIStyle(EditorStyles.boldLabel);
            titleStyle.alignment = TextAnchor.MiddleCenter;  // ��� ����
            titleStyle.normal.textColor = Color.green;  // �۾� ���� �����
            titleStyle.fontSize = 14;  // �۾� ũ��

            // ū ���� ���
            EditorGUILayout.LabelField("ī�� ȿ�� ����Ʈ", titleStyle);

            // �ٽ� ���м� �߰�
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

            EditorGUILayout.Space();

            // ����Ʈ ���: Add, Delete ��ư �� ����Ʈ ���� ǥ��
            EditorGUILayout.BeginHorizontal();

            Color originalBackgroundColor = GUI.backgroundColor;
            GUI.backgroundColor = Color.green;

            // "Add Action" ��ư
            if (GUILayout.Button("�߰�", GUILayout.Height(30)))
            {
                actionsProperty.arraySize++;  // ����Ʈ �׸��� �ϳ� �߰�
            }

            GUI.backgroundColor = Color.red;

            // "Delete Last Action" ��ư
            if (GUILayout.Button("����", GUILayout.Height(30)))
            {
                if (actionsProperty.arraySize > 0)
                {
                    actionsProperty.DeleteArrayElementAtIndex(actionsProperty.arraySize - 1);  // ������ �׸� ����
                }
            }

            GUI.backgroundColor = originalBackgroundColor;

            // ����Ʈ �׸� �� ǥ��
            string effectsCountText = $"{actionsProperty.arraySize}";

            GUIStyle centeredStyle = new GUIStyle(GUI.skin.box);
            centeredStyle.alignment = TextAnchor.MiddleCenter;  // �ؽ�Ʈ�� ��� ����


            GUILayout.Box(effectsCountText, centeredStyle, GUILayout.Height(30), GUILayout.ExpandWidth(true));

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();  // ���� �߰�

            // Ŀ���� �׵θ� ��Ÿ�� ����
            GUIStyle boxStyleWithBorder = new GUIStyle(GUI.skin.box);
            boxStyleWithBorder.margin = new RectOffset(10, 10, 10, 10);  // ���� ����
            boxStyleWithBorder.padding = new RectOffset(10, 10, 10, 10);  // �е� ����

            // ��� ���� ������ ���� �ؽ�ó ���� (��ο� ȸ��)
            Texture2D backgroundTexture = new Texture2D(1, 1);
            backgroundTexture.SetPixel(0, 0, new Color(0.2f, 0.2f, 0.2f));  // ��ο� ȸ��
            backgroundTexture.Apply();

            boxStyleWithBorder.normal.background = backgroundTexture;  // ������� ����
            boxStyleWithBorder.normal.textColor = Color.white;  // �ؽ�Ʈ ���� ���

            // ����Ʈ �׸��� �ڽ� ���·� ���
            for (int i = 0; i < actionsProperty.arraySize; i++)
            {
                SerializedProperty actionData = actionsProperty.GetArrayElementAtIndex(i);

                // �ڽ� ��Ÿ���� �����Ͽ� ��� (���̾ƿ��� ������ �ʵ���)
                EditorGUILayout.BeginVertical(boxStyleWithBorder);  // �׵θ� �� ����� ������ �ڽ� ��Ÿ��

                EditorGUILayout.Space();

                SerializedProperty actionTypeProperty = actionData.FindPropertyRelative("actionType");
                EditorGUILayout.PropertyField(actionTypeProperty, new GUIContent($"ȿ�� Ÿ��"));

                ActionType actionType = (ActionType)actionTypeProperty.enumValueIndex;

                string previewText = "";  // �̸����� �ؽ�Ʈ

                // ActionType�� ���� �ʵ� �� �̸����� �ؽ�Ʈ ó��
                if (actionType == ActionType.Assign)
                {
                    EditorGUILayout.Space();
                    SerializedProperty effectProperty = actionData.FindPropertyRelative("effect");
                    SerializedProperty valueProperty = actionData.FindPropertyRelative("value");

                    // A �Ʒ� A1 ǥ��: Effect ����, �� �Ʒ� Value
                    EditorGUILayout.PropertyField(effectProperty, new GUIContent("ȿ��"));
                    EditorGUILayout.Space();  // ���� �߰�
                    EditorGUILayout.PropertyField(valueProperty, new GUIContent("��"));

                    // �̸����� �ؽ�Ʈ ����
                    previewText = $"{effectProperty.enumNames[effectProperty.enumValueIndex]}��(��) {valueProperty.intValue} �ο��մϴ�.";
                }
                else if (actionType == ActionType.Card)
                {
                    EditorGUILayout.Space();
                    SerializedProperty cardTargetProperty = actionData.FindPropertyRelative("cardTarget");
                    SerializedProperty cardActionProperty = actionData.FindPropertyRelative("cardAction");

                    // A �Ʒ� A1 ǥ��: Card Target ����, �� �Ʒ� Card Action
                    EditorGUILayout.PropertyField(cardTargetProperty, new GUIContent("��� ī��"));
                    EditorGUILayout.Space();  // ���� �߰�
                    EditorGUILayout.PropertyField(cardActionProperty, new GUIContent("ȿ��"));

                    // ī�� ���� �̸����� �ؽ�Ʈ
                    previewText = $"{cardTargetProperty.enumNames[cardTargetProperty.enumValueIndex]} ī�带 {cardActionProperty.enumNames[cardActionProperty.enumValueIndex]}�մϴ�.";
                }

                // �̸����� �ڽ� ���
                GUIStyle previewStyle = new GUIStyle(EditorStyles.helpBox);
                previewStyle.alignment = TextAnchor.MiddleCenter;
                previewStyle.fontSize = 14;
                previewStyle.normal.textColor = Color.yellow;

                GUILayout.Space(10);  // Ÿ��/�׼ǰ� �̸����� �ؽ�Ʈ ���̿� ���� �߰�
                GUILayout.Label(previewText, previewStyle, GUILayout.Height(30));

                EditorGUILayout.EndVertical();  // �ڽ� ��Ÿ�� ��
                EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);  // ���м� �߰�
            }

            // ����� ������ ����
            serializedObject.ApplyModifiedProperties();
        }
    }
}

#endif
