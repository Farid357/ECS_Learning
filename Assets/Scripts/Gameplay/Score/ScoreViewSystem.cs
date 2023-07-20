using System;
using Leopotam.EcsLite;

namespace Game
{
    public class ScoreViewSystem : IEcsRunSystem
    {
        private readonly IScoreView _view;

        public ScoreViewSystem(IScoreView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public void Run(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsPool<Score> pool = world.GetPool<Score>();
            EcsFilter filter = world.Filter<Score>().End();
        
            foreach (int entity in filter)
            {
                ref Score score = ref pool.Get(entity);
                _view.Visualize(score);
            }
        }
    }
}