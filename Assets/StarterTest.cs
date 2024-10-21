using UnityEngine;
using Control;
using Manager;

public class StarterTest : MonoBehaviour
{
    void Start()
    {
        MouseAction.Instance.Initialize();
        GameManager.Instance.Initialize();
    }

}
