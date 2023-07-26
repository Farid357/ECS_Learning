using System;
using Scellecs.Morpeh;
using UnityEngine;
using Zenject;

namespace Game.Core
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private ScoreView _scoreView;

        private SystemsGroup _systems;
        private World _world;

        public override void InstallBindings()
        {
            _world = World.Default;
            _systems = _world.CreateSystemsGroup();
            
            Container.BindInstance(_systems).AsSingle();
            Container.BindInstance(_bulletPrefab).AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreView>().FromInstance(_scoreView).AsSingle();
            
            PlayerInstaller.Install(Container, _systems);
            StatisticsInstaller.Install(Container, _systems);
            EnemyInstaller.Install(Container, _systems);

        }

        public override void Start()
        {
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