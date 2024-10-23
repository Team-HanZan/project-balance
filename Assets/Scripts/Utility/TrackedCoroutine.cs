using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{

    public class FlaggedCoroutine : MonoBehaviour
    {
        private static MonoBehaviour _coroutineOwner;

        private static FlagHolder _flagHolder;

        public static FlagHolder FlagHolder => _flagHolder;

        public static void Reset()
        {
            _flagHolder = new FlagHolder();
        }

        public static void Initialize()
        {
            _flagHolder = new FlagHolder();
        }

        public static void EnterCoroutine(string coroutineName)
        {
            _flagHolder.AddFlag();
            Debug.Log($"등록된 Flag: {_flagHolder.Count}");
        }

        public static void ExitCoroutine(string coroutineName)
        {
            _flagHolder.Check();

            Debug.Log($"남은 Flag: {_flagHolder.Count}");
        }

        public static Coroutine Run(MonoBehaviour owner, IEnumerator coroutine)
        {
            _coroutineOwner = owner;
            return owner.StartCoroutine(RunCoroutine(coroutine));
        }

        private static IEnumerator RunCoroutine(IEnumerator coroutine)
        {
            EnterCoroutine(coroutine.ToString());

            yield return coroutine;

            ExitCoroutine(coroutine.ToString());
        }
    }

}