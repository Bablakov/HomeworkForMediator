using System;
using UnityEngine;
using Zenject;

namespace Task2.PlayersComponent
{
    public class Level
    {
        public event Action<int> ChangedLevel;

        private const int DefaultLevel = 1;

        public Level()
            => CurrentLevel = DefaultLevel;

        public int CurrentLevel { get; private set; }
        
        public void RaiseLevel()
        {
            CurrentLevel++;
            ChangedLevel?.Invoke(CurrentLevel);
        }

        public void Reset()
        {
            CurrentLevel = DefaultLevel;
            ChangedLevel?.Invoke(CurrentLevel);
        }
    }
}