using UnityEngine;

namespace TdgMvc
{
    public interface IQuestModel
    {
        bool TryComplete(GameObject activator);
    }
}