using System;
using UnityEngine;

namespace Client
{
    [Serializable]
    public struct ZigzagMovementComponent
    {
        public Transform Transform;
        public bool MoveRightSite;
        public float ZigzagAmplitude;
        public float MovingProgress;
        public float Speed;
    }
}