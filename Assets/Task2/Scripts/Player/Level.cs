using System;
using UnityEngine;

namespace Task2
{
    public class Level
    {
        public event Action<int> ChangedLevel;

        private int _level;

        public Level()
        {
            _level = 0;
        }
        
        public void RaiseLevel()
        {
            Debug.Log($"RaiseLevel {_level}");
            _level++;
            ChangedLevel?.Invoke(_level);
        }
    }
}