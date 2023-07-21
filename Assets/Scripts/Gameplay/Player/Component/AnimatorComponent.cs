using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace Game
{
    [Serializable]
    public struct AnimatorComponent : IComponent
    {
        public Animator Animator;
    }
}