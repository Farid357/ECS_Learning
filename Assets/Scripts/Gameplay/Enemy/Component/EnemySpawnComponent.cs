using System;
using System.Collections.Generic;
using Scellecs.Morpeh;
using UnityEngine;

namespace Game
{
    [Serializable]
    public struct EnemySpawnComponent : IComponent
    {
        public float TimeBetweenSpawn;
        public List<Transform> SpawnPoints;
        public EnemyProvider EnemyPrefab;
    }
}