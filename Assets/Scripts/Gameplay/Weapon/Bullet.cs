using Scellecs.Morpeh;
using UnityEngine;

namespace Game
{
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _throwForce = 10f;
        [SerializeField] private int _damage = 10;

        public void Throw(Vector3 direction)
        {
            _rigidbody.AddForce(direction * _throwForce, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out EnemyProvider enemy))
            {
                Entity enemyEntity = enemy.Entity;
                ref EnemyComponent enemyComponent = ref enemyEntity.GetComponent<EnemyComponent>();
                enemyComponent.Health -= _damage;
                Destroy(gameObject);
            }
        }
    }
}