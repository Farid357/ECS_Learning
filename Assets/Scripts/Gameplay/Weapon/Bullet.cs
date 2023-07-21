using System;
using Leopotam.EcsLite;
using UnityEngine;

namespace Game
{
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _throwForce = 10f;
        [SerializeField] private int _damage = 10;

        private EcsWorld _world;

        public void Init(EcsWorld world)
        {
            _world = world ?? throw new ArgumentNullException(nameof(world));
        }
        
        public void Throw(Vector3 direction)
        {
            _rigidbody.AddForce(direction * _throwForce, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out Enemy enemy))
            {
                EcsPool<EnemyComponent> pool = _world.GetPool<EnemyComponent>();
                EcsPackedEntity packedEntity = enemy.Entity;

                if (!packedEntity.Unpack(_world, out int entity))
                    return;
            
                if (!pool.Has(entity))
                    return;
                
                ref EnemyComponent enemyComponent = ref pool.Get(entity);
                enemyComponent.Health -= _damage;

                if (enemyComponent.Health <= 0)
                {
                    pool.Del(entity);
                    enemy.DestroySelf();
                }

                Destroy(gameObject);
            }
        }
    }
}