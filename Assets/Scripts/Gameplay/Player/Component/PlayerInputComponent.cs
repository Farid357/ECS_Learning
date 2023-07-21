using Scellecs.Morpeh;
using UnityEngine;

namespace Game
{
    public struct PlayerInputComponent : IComponent
    {
        public Vector3 MoveDirection { get; set; }
        
        public bool IsShooting { get; set; }
    }
}