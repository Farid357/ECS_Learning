using Scellecs.Morpeh;
using Tools;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game
{
    public class EnemySpawnSystem : ISystem
    {
        private Filter _filter;
        private float _timer = 10;
       
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<EnemySpawnComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            _timer += deltaTime;

            foreach (Entity entity in _filter)
            {
                EnemySpawnComponent spawnComponent = entity.GetComponent<EnemySpawnComponent>();
                
                if (_timer >= spawnComponent.TimeBetweenSpawn)
                {
                    Vector3 position = spawnComponent.SpawnPoints.GetRandom().position;
                    Object.Instantiate(spawnComponent.EnemyPrefab, position, Quaternion.identity);
                    _timer = 0;
                }
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}