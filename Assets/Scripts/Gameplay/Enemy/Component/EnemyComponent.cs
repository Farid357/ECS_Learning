using System;
using Scellecs.Morpeh;

namespace Game
{
    [Serializable]
    public struct EnemyComponent : IComponent
    {
        public int Health;
        public int Score;
    }
}