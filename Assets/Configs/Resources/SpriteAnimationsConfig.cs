using System;
using System.Collections.Generic;
using UnityEngine;

namespace TdgMvc
{
    public enum AnimState
    {
        Idle = 0,
        Run = 1,
        Jump = 2,
        Hit = 3,
        Food = 4,
        Drink = 5
    }

    [CreateAssetMenu(fileName = "SpriteAnimatitorCfg", menuName =
        "Configs/SpriteAnimatitorCfg", order = 1)]
    public class SpriteAnimationsConfig : ScriptableObject
    {
        [Serializable]
        public sealed class SpritesSequence
        {
            public AnimState Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }

        public List<SpritesSequence> Sequences = new List<SpritesSequence>();

    }
} 
