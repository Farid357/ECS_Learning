using Scellecs.Morpeh;

namespace Game
{
    public class ScoreCreateSystem : IInitializer
    {
        public World World { get; set; }

        public void OnAwake()
        {
            Entity entity = World.CreateEntity();
            entity.AddComponent<ScoreComponent>();
        }

        public void Dispose()
        {
            
        }
    }
}