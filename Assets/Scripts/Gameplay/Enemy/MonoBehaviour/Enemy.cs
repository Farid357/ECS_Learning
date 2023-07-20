using UnityEngine;

namespace Game
{
    public class Enemy : MonoBehaviour
    {
        public int Entity { get; private set; }
        
        [field: SerializeField] public int Health { get; private set; }
     
        [field: SerializeField] public int Score { get; set; }

        public void Init(int entity)
        {
            Entity = entity;
        }

        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}