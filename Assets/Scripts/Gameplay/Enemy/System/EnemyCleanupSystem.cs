using Scellecs.Morpeh;

namespace Game
{
    public sealed class EnemyCleanupSystem : ILateSystem
    {
        private Filter _filter;

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<EnemyComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                EnemyComponent enemy = entity.GetComponent<EnemyComponent>();

                if (enemy.Health <= 0)
                    entity.RemoveComponent<EnemyComponent>();
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}