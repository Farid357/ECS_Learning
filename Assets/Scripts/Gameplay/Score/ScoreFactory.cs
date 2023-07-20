using Leopotam.EcsLite;
using UnityEngine;

namespace Game
{
    public class ScoreFactory : MonoBehaviour
    {
        [SerializeField] private ScoreView _scoreView;

        public ref Score Create(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            int entity = world.NewEntity();
            EcsPool<Score> pool = world.GetPool<Score>();

            pool.Add(entity);
            systems.Add(new ScoreViewSystem(_scoreView));

            return ref pool.Get(entity);
        }
    }
}