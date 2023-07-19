using System;
using Leopotam.EcsLite;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ECS_Learning
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        private readonly Player _playerPrefab;

        public PlayerInitSystem(Player playerPrefab)
        {
            _playerPrefab = playerPrefab ? playerPrefab : throw new ArgumentNullException(nameof(playerPrefab));
        }

        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            int entity = world.NewEntity();
            EcsPool<PlayerComponent> pool = world.GetPool<PlayerComponent>();
            EcsPool<PlayerInput> inputPool = world.GetPool<PlayerInput>();

            pool.Add(entity);
            inputPool.Add(entity);

            Vector3 position = Vector3.zero + new Vector3(0, 1, 0);
            Player player = Object.Instantiate(_playerPrefab, position, Quaternion.identity);

            ref PlayerComponent playerComponent = ref pool.Get(entity);

            playerComponent.Rigidbody = player.Rigidbody;
            playerComponent.Speed = player.Speed;
        }
    }
}