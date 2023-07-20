using Leopotam.EcsLite;

namespace Game
{
    public class EnemyRewardSystem : IEcsRunSystem
    {
        public void Run(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsPool<EnemyComponent> enemyPool = world.GetPool<EnemyComponent>();
            EcsFilter filter = world.Filter<EnemyComponent>().End();

            foreach (int entity in filter)
            {
                EnemyComponent enemy = enemyPool.Get(entity);

                if (enemy.Health <= 0)
                {
                    EcsPool<Score> scorePool = world.GetPool<Score>();
                    EcsFilter scoreFilter = world.Filter<Score>().End();

                    foreach (int scoreEntity in scoreFilter)
                    {
                        ref Score score = ref scorePool.Get(scoreEntity);
                        score.Count += enemy.Score;
                    }
                }
            }
        }
    }
}