using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public class FlagHolder
    {
        private int _flagCount;

        public bool Done => _flagCount == 0;

        public int Count => _flagCount;

        public FlagHolder()
        {
            _flagCount = 0;
        }

        public void AddFlag()
        {
            _flagCount++;
        }

        public void Check()
        {
            _flagCount--;
        }
    }
}