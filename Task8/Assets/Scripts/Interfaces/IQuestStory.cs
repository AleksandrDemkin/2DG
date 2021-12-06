using System;

namespace TdgMvc
{
    public interface IQuestStory : IDisposable
    {
        bool IsDone { get; }
    }

}