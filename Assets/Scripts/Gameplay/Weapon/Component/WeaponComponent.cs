using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace Game
{
    [Serializable]
    public struct WeaponComponent : IComponent
    {
        public int Bullets;
        public int MaxBullets;
        public Transform BulletSpawnPoint;
    }
}