using System;
using UnityEngine;

namespace TdgMvc
{
    [Serializable] public struct AIConfig
    {
        public float speed;
        public float minDistanceToTarget;
        public Transform[] waypoints;
    }
}