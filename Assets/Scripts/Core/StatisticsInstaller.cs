using System;
using Scellecs.Morpeh;
using Zenject;

namespace Game.Core
{
    public class StatisticsInstaller : Installer<SystemsGroup, StatisticsInstaller>
    {
        private readonly SystemsGroup _systemsGroup;
        private readonly IScoreView _scoreView;

        public StatisticsInstaller(SystemsGroup systemsGroup)
        {
            _systemsGroup = systemsGroup ?? throw new ArgumentNullException(nameof(systemsGroup));
        }

        public override void InstallBindings()
        {
            _systemsGroup.AddInitializer(Container.Instantiate<ScoreCreateSystem>());
            _systemsGroup.AddSystem(Container.Instantiate<ScoreViewSystem>());
        }
    }
}