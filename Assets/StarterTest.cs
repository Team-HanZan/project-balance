using UnityEngine;
using Control;

public class StarterTest : MonoBehaviour
{
    void Start()
    {
        MouseAction.Instance.Initialize();
        GameManager.Instance.Initialize();
    }

}
