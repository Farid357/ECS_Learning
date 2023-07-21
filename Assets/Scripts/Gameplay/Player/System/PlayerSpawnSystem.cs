using Scellecs.Morpeh;
using Object = UnityEngine.Object;

namespace Game
{
    public class PlayerSpawnSystem : IInitializer
    {
        private Filter _filter;

        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<PlayerSpawnComponent>();
          
            foreach (Entity entity in _filter)
            {
                ref var spawnComponent = ref entity.GetComponent<PlayerSpawnComponent>();
                PlayerProvider player = Object.Instantiate(spawnComponent.PlayerPrefab, spawnComponent.SpawnPoint.position, spawnComponent.PlayerPrefab.transform.rotation);
                player.Entity.AddComponent<PlayerInputComponent>();
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}