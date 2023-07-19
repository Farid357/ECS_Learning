using Leopotam.EcsLite;
using UnityEngine;

namespace ECS_Learning
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Player _playerPrefab;

        private EcsWorld _world;
        private EcsSystems _systems;
        private EcsSystems _fixedSystems;

        private void Awake()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            _fixedSystems = new EcsSystems(_world);

            _systems
                .Add(new PlayerInitSystem(_playerPrefab))
                .Add(new PlayerInputSystem())
                .Add(new PlayerMoveSystem());
            
            _systems.Init();
            _fixedSystems.Init();
        }

        private void Update()
        {
            _systems.Run();
        }

        private void FixedUpdate()
        {
            _fixedSystems.Run();
        }

        private void OnDestroy()
        {
            _world.Destroy();
            _systems.Destroy();
            _fixedSystems.Destroy();
        }
    }
}