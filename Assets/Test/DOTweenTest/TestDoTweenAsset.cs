using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDoTweenAsset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        // ���콺 ��ġ�� ���� ��ǥ�� ��ȯ
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // z���� 0���� �����Ͽ� 2D ��鿡�� �̵�

    }
}
