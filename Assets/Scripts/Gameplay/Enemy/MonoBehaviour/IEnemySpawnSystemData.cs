using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public interface IEnemySpawnSystemData
    {
        Enemy EnemyPrefab { get; }
        
        List<Transform> SpawnPoints { get; }
        
        float TimeBetweenSpawn { get; }
    }
}