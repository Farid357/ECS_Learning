using UnityEngine;

namespace Game
{
    public struct WeaponComponent
    {
        public int Bullets { get; set; }
        
        public int MaxBullets { get; set; }
        
        public Transform BulletSpawnPoint { get; set; }
    }
}