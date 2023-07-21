using System;
using Leopotam.EcsLite;
using Tools;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game
{
    public class EnemySpawnSystem : IEcsRunSystem
    {
        private readonly IEnemySpawnSystemData _data;
        
        private float _timer;

        public EnemySpawnSystem(IEnemySpawnSystemData data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
            _timer = _data.TimeBetweenSpawn;
        }
        
        public void Run(IEcsSystems systems)
        {
            _timer += Time.deltaTime;

            if (_timer >= _data.TimeBetweenSpawn)
            {
                EcsWorld world = systems.GetWorld();
                Vector3 position = _data.SpawnPoints.GetRandom().position;
                Enemy enemy = Object.Instantiate(_data.EnemyPrefab, position, Quaternion.identity);
              
                int entity = world.NewEntity();
                EcsPool<EnemyComponent> pool = world.GetPool<EnemyComponent>();
             
                pool.Add(entity);
                enemy.Init(world.PackEntity(entity));
                ref EnemyComponent enemyComponent = ref pool.Get(entity);
                enemyComponent.Health = enemy.Health;
                enemyComponent.Score = enemy.Score;
                
                _timer = 0;
            }
        }
    }
}