using Singletons;
using UnityEngine;


public sealed class GameManager : SingletonBase<GameManager>
{
    public int sessionId;


    protected override void Awake()
    {
        base.Awake();

    }

}
