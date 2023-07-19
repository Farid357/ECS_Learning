using UnityEngine;

namespace ECS_Learning
{
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _throwForce = 10f;
        
        public void Throw(Vector3 direction)
        {
            _rigidbody.AddForce(direction * _throwForce, ForceMode.Impulse);
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out Enemy enemy))
            {
                //TODO Damage
                Destroy(gameObject);
            }
        }
    }
}