using Leopotam.EcsLite;

namespace ECS_Learning
{
    public class WeaponInitSystem : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsPool<WeaponComponent> pool = world.GetPool<WeaponComponent>();
            int entity = world.NewEntity();
          
            pool.Add(entity);
            ref WeaponComponent weapon = ref pool.Get(entity);
         
            weapon.Bullets = 30;
            weapon.MaxBullets = 30;
        }
    }
}