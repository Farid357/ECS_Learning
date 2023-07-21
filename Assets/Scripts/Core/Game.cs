using Scellecs.Morpeh;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Core
{
    public class Game : SerializedMonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private IScoreView _scoreView;

        private SystemsGroup _systems;
        private World _world;

        private void Awake()
        {
            _world = World.Default;
            _systems = _world.CreateSystemsGroup();
            
            _systems.AddInitializer(new PlayerSpawnSystem());
            _systems.AddInitializer(new ScoreCreateSystem());
        
            _systems.AddSystem(new PlayerInputSystem());
            _systems.AddSystem(new PlayerMoveSystem());
            _systems.AddSystem(new PlayerRotationSystem());
            _systems.AddSystem(new PlayerMoveAnimationSystem());
            _systems.AddSystem(new PlayerShootSystem(_bulletPrefab));
            _systems.AddSystem(new PlayerMoveAnimationSystem());
            _systems.AddSystem(new PlayerShootAnimationSystem());
            
            _systems.AddSystem(new CameraFollowSystem());

            _systems.AddSystem(new ScoreViewSystem(_scoreView));
            _systems.AddSystem(new EnemyRewardSystem());
            _systems.AddSystem(new EnemySpawnSystem());

            _systems.AddSystem(new EnemyCleanupSystem());
            
            _systems.Initialize();
        }

        private void Update()
        {
            _systems.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _systems.FixedUpdate(Time.fixedDeltaTime);
        }

        private void LateUpdate()
        {
            _systems.LateUpdate(Time.deltaTime);
        }

        private void OnDestroy()
        {
            _systems.Dispose();
            _world.Dispose();
        }
    }
}