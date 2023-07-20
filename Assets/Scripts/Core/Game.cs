using Leopotam.EcsLite;
using UnityEngine;

namespace Game.Core
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Camera _camera;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private ScoreFactory _scoreFactory;
        [SerializeField] private EnemySpawnSystemData _enemySpawnData;

        private IEcsSystems _systems;
        private IEcsSystems _fixedSystems;
        private EcsWorld _world;

        private void Awake()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            _fixedSystems = new EcsSystems(_world);

            _scoreFactory.Create(_systems);

            _systems
                .Add(new PlayerInitSystem(_playerPrefab))
                .Add(new PlayerInputSystem())
                .Add(new PlayerRotationSystem(_camera))
                .Add(new PlayerAnimationSystem())
                .Add(new CameraFollowSystem(_camera))
                .Add(new WeaponInitSystem())
                .Add(new PlayerShootSystem(_bulletPrefab))
                .Add(new EnemyRewardSystem())
                .Add(new EnemySpawnSystem(_enemySpawnData));

            _fixedSystems
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