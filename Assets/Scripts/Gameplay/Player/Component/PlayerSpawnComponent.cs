using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace Game
{
    [Serializable]
    public struct PlayerSpawnComponent : IComponent
    {
        public PlayerProvider PlayerPrefab;
        public Transform SpawnPoint;
    }
}