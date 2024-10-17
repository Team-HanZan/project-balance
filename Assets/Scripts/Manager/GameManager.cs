using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singletons;
using System.IO;



public sealed class GameManager : Singleton<GameManager>
{
    public int sessionId;


    protected override void Awake()
    {
        base.Awake();
    }

}
