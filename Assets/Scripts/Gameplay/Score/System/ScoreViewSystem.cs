using System;
using Scellecs.Morpeh;

namespace Game
{
    public class ScoreViewSystem : ISystem
    {
        private readonly IScoreView _view;
       
        private Filter _filter;

        public ScoreViewSystem(IScoreView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }
        
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<ScoreComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ref ScoreComponent score = ref entity.GetComponent<ScoreComponent>();
                _view.Visualize(score);
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}