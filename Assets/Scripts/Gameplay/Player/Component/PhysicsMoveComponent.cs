using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace Game
{
    [Serializable]
    public struct PhysicsMoveComponent : IComponent
    {
        public Rigidbody Rigidbody;
        public float Speed;
    }
}