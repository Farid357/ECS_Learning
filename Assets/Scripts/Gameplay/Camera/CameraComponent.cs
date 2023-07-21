using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace Game
{
    [Serializable]
    public struct CameraComponent : IComponent
    {
        public Camera Camera;
        public Vector3 FollowOffset;
        public float FollowSpeed;
    }
}