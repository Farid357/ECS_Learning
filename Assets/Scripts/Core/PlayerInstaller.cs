using System;
using Scellecs.Morpeh;
using Zenject;

namespace Game.Core
{
    public class PlayerInstaller : Installer<SystemsGroup, PlayerInstaller>
    {
        private readonly SystemsGroup _systemsGroup;

        public PlayerInstaller(SystemsGroup systemsGroup)
        {
            _systemsGroup = systemsGroup ?? throw new ArgumentNullException(nameof(systemsGroup));
        }

        public override void InstallBindings()
        {
            _systemsGroup.AddInitializer(Container.Instantiate<PlayerSpawnSystem>());

            _systemsGroup.AddSystem(Container.Instantiate<PlayerInputSystem>());
            _systemsGroup.AddSystem(Container.Instantiate<CameraFollowSystem>());
            _systemsGroup.AddSystem(Container.Instantiate<PlayerMoveSystem>());
            _systemsGroup.AddSystem(Container.Instantiate<PlayerRotationSystem>());
            _systemsGroup.AddSystem(Container.Instantiate<PlayerMoveAnimationSystem>());
            _systemsGroup.AddSystem(Container.Instantiate<PlayerShootSystem>());
            _systemsGroup.AddSystem(Container.Instantiate<PlayerMoveAnimationSystem>());
            _systemsGroup.AddSystem(Container.Instantiate<PlayerShootAnimationSystem>());
        }
    }
}