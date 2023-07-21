using System;
using Scellecs.Morpeh;
using Object = UnityEngine.Object;

namespace Game
{
    public class PlayerShootSystem : ISystem
    {
        private readonly Bullet _bulletPrefab;

        private Filter _weaponsFilter;
        private Filter _playerInputFilter;

        public PlayerShootSystem(Bullet bulletPrefab)
        {
            _bulletPrefab = bulletPrefab ? bulletPrefab : throw new ArgumentNullException(nameof(bulletPrefab));
        }

        public World World { get; set; }

        public void OnAwake()
        {
            _weaponsFilter = World.Filter.With<WeaponComponent>();
            _playerInputFilter = World.Filter.With<PlayerInputComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            bool isShooting = false;

            foreach (Entity entity in _playerInputFilter)
            {
                ref PlayerInputComponent playerInput = ref entity.GetComponent<PlayerInputComponent>();

                if (playerInput.IsShooting)
                {
                    isShooting = true;
                    break;
                }
            }

            if (!isShooting)
                return;

            foreach (Entity entity in _weaponsFilter)
            {
                ref WeaponComponent weapon = ref entity.GetComponent<WeaponComponent>();

                if (weapon.Bullets > 0)
                {
                    weapon.Bullets--;
                    Bullet bullet = Object.Instantiate(_bulletPrefab, weapon.BulletSpawnPoint.position, _bulletPrefab.transform.rotation);
                    bullet.Throw(weapon.BulletSpawnPoint.forward);
                }
                else
                {
                    //TODO Reload
                }
            }
        }

        public void Dispose()
        {
            _weaponsFilter = null;
            _playerInputFilter = null;
        }
    }
}