using System;
using Leopotam.EcsLite;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game
{
    public class PlayerShootSystem : IEcsRunSystem
    {
        private readonly Bullet _bulletPrefab;

        public PlayerShootSystem(Bullet bulletPrefab)
        {
            _bulletPrefab = bulletPrefab ? bulletPrefab : throw new ArgumentNullException(nameof(bulletPrefab));
        }

        public void Run(IEcsSystems systems)
        {
            EcsWorld world = systems.GetWorld();
            EcsFilter weaponsFilter = world.Filter<WeaponComponent>().End();
            EcsPool<WeaponComponent> weaponsPool = world.GetPool<WeaponComponent>();
            
            foreach (int entity in weaponsFilter)
            {
                ref WeaponComponent weapon = ref weaponsPool.Get(entity);

                if (Input.GetMouseButtonDown(0))
                {
                    if (weapon.Bullets > 0)
                    {
                        weapon.Bullets--;
                        Bullet bullet = Object.Instantiate(_bulletPrefab, weapon.BulletSpawnPoint.position, Quaternion.identity);
                        bullet.Throw(weapon.BulletSpawnPoint.forward);
                    }
                    else
                    {
                        //TODO Reload
                    }
                }
            }
        }
    }
}