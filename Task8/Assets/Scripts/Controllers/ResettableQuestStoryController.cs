using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TdgMvc
{
    public class ResettableQuestStoryController : IQuestStory
    {
        private List<IQuest> _questCollection = new List<IQuest>();
        public bool IsDone => _questCollection.Any(value => value.IsCompleted);

        private int _currentIndex;


        public ResettableQuestStoryController(List<IQuest> questCollection)
        {
            _questCollection = questCollection;
            Subscribe();
            ResetQuest();
        }

        private void Subscribe()
        {
            foreach (IQuest quest in _questCollection)
            {
                quest.Completed += OnQuestCompleted;
            }
        }
        
        private void Unsubscribe()
        {
            foreach (IQuest quest in _questCollection)
            {
                quest.Completed -= OnQuestCompleted;
            }
        }

        private void OnQuestCompleted(object sender, IQuest quest)
        {
            int index = _questCollection.IndexOf(quest);
            if (_currentIndex == index)
            {
                _currentIndex++;
                if (IsDone)
                {
                    Debug.Log("Quest is done.");
                }
            }
            else
            {
                ResetQuest();
            }
        }

        private void ResetQuest()
        {
            _currentIndex = 0;
            foreach (IQuest quest in _questCollection)
            {
                quest.Reset();
            }
        }

        public void Dispose()
        {
            Unsubscribe();
            foreach (IQuest quest in _questCollection)
            {
                quest.Dispose();
            }
        }
    }
}