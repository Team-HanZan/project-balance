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
        // 마우스 위치를 월드 좌표로 변환
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // z값을 0으로 고정하여 2D 평면에서 이동

    }
}
