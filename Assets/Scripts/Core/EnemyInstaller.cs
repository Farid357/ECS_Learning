using System;
using Scellecs.Morpeh;
using Zenject;

namespace Game.Core
{
    public class EnemyInstaller : Installer<SystemsGroup, EnemyInstaller>
    {
        private readonly SystemsGroup _systems;

        public EnemyInstaller(SystemsGroup systems)
        {
            _systems = systems ?? throw new ArgumentNullException(nameof(systems));
        }

        public override void InstallBindings()
        {
            _systems.AddSystem(new EnemyRewardSystem());
            _systems.AddSystem(new EnemySpawnSystem());
            _systems.AddSystem(new EnemyCleanupSystem());
        }
    }
}