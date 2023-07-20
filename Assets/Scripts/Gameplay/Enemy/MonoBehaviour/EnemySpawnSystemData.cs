using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EnemySpawnSystemData : MonoBehaviour, IEnemySpawnSystemData
    {
        [field: SerializeField] public Enemy EnemyPrefab { get; private set; }
        
        [field: SerializeField] public List<Transform> SpawnPoints { get; private set; }
    
        [field: SerializeField] public float TimeBetweenSpawn { get; private set; }

    }
}