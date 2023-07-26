using Scellecs.Morpeh;
using UnityEngine;

namespace Game
{
    public sealed class EnemyMoveSystem : IFixedSystem
    {
        private Filter _enemyFilter;
        private Filter _playerFilter;
    
        public World World { get; set; }

        public void OnAwake()
        {
            _enemyFilter = World.Filter.With<PhysicsMoveComponent>().With<EnemyComponent>();
            _playerFilter = World.Filter.With<PlayerComponent>().With<PhysicsMoveComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity enemyEntity in _enemyFilter)
            {
                ref PhysicsMoveComponent enemyMoveComponent = ref enemyEntity.GetComponent<PhysicsMoveComponent>();

                foreach (Entity playerEntity in _playerFilter)
                {
                    ref PhysicsMoveComponent playerMoveComponent = ref playerEntity.GetComponent<PhysicsMoveComponent>();

                    Rigidbody enemyRigidbody = enemyMoveComponent.Rigidbody;
                    Vector3 enemyPosition = enemyRigidbody.position;
                    Vector3 direction = (playerMoveComponent.Rigidbody.position - enemyPosition).normalized;
                    enemyRigidbody.transform.LookAt(playerMoveComponent.Rigidbody.transform);
                    enemyRigidbody.MovePosition(enemyPosition + direction * deltaTime * enemyMoveComponent.Speed);
                }
            }
        }

        public void Dispose()
        {
            _enemyFilter = null;
        }
    }
}