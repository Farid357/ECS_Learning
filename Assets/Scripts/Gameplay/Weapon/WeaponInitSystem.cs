using Leopotam.EcsLite;

namespace Game
{
    public class WeaponInitSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsPool<WeaponComponent> enemyPool = world.GetPool<WeaponComponent>();
            EcsPool<PlayerComponent> playerPool = world.GetPool<PlayerComponent>();
            EcsFilter filter = world.Filter<PlayerComponent>().End();
            int entity = world.NewEntity();
          
            enemyPool.Add(entity);
            ref WeaponComponent weapon = ref enemyPool.Get(entity);
         
            weapon.Bullets = 30;
            weapon.MaxBullets = 30;
            
            foreach (int playerEntity in filter)
            {
                PlayerComponent player = playerPool.Get(playerEntity);
                weapon.BulletSpawnPoint = player.BulletSpawnPoint;
            }
        }
    }
}