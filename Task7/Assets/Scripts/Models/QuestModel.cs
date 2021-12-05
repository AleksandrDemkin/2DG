using System;
using UnityEngine;

namespace TdgMvc
{
    public sealed class QuestModel : IQuestModel
    {

        private const string TargetTag = "Player";

        public bool TryComplete(GameObject activator)
        {
            return activator.CompareTag(TargetTag);
        }
    }
}