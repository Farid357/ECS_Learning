using Scellecs.Morpeh;

namespace Game
{
    public class EnemyRewardSystem : ISystem
    {
        private Filter _enemyFilter;
        private Filter _scoreFilter;
        
        public World World { get; set; }

        public void OnAwake()
        {
            _enemyFilter = World.Filter.With<EnemyComponent>();
            _scoreFilter = World.Filter.With<ScoreComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _enemyFilter)
            {
                ref EnemyComponent enemy = ref entity.GetComponent<EnemyComponent>();

                if (enemy.Health <= 0)
                {
                    foreach (Entity scoreEntity in _scoreFilter)
                    {
                        ref ScoreComponent score = ref scoreEntity.GetComponent<ScoreComponent>();
                        score.Count += enemy.Score;
                    }
                }
            }
        }

        public void Dispose()
        {
            _enemyFilter = null;
            _scoreFilter = null;
        }
    }
}