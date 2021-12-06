using  System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace TdgMvc
{
    public class QuestConfiguratorController
    {
        private QuestObjectView _singleQuestView;
        private QuestController _singleQuest;
        private QuestModel _model;

        private QuestStoryConfig[] _questStoryConfigs;
        private QuestObjectView[] _questObjects;

        private List<IQuestStory> _questStories;

        public QuestConfiguratorController(QuestView questView)
        {
            _singleQuestView = questView._singleQuest;
            _model = new QuestModel();

            _questStoryConfigs = questView._questStoryConfigs;
            _questObjects = questView._questsObjects;
        }
        
        private readonly Dictionary<QuestType, Func<IQuestModel>> _questFactories = new
            Dictionary<QuestType, Func<IQuestModel>>(1);
        
        private readonly Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>> _questStoryFactories = new
            Dictionary<QuestStoryType, Func<List<IQuest>, IQuestStory>>(2);

        public void Init()
        {
            _singleQuest = new QuestController(_singleQuestView, _model);
            _singleQuest.Reset();
            
            _questStoryFactories.Add(QuestStoryType.Common, questCollection => new QuestStoryController(questCollection));
            _questStoryFactories.Add(QuestStoryType.Resettable, questCollection => new ResettableQuestStory(questCollection));
            
            _questFactories.Add(QuestType.Food, () => new QuestModel());

            _questStories = new List<IQuestStory>();
            foreach (QuestStoryConfig questStoryConfig in _questStoryConfigs)
            {
                _questStories.Add(CreateQuestStory(questStoryConfig));
            }
        }

        private IQuestStory CreateQuestStory(QuestStoryConfig cfg)
        {
            List<IQuest> quests = new List<IQuest>();
            foreach (QuestConfig questConfig in cfg.quests)
            {
                IQuest quest = CreateQuest(questConfig);
                if (quest == null) continue;
                quests.Add(quest);
                Debug.Log("Add quest");
            }

            return _questStoryFactories[cfg.questStoryType].Invoke(quests);
        }

        private IQuest CreateQuest(QuestConfig config)
        {
            int questID = config.id;
            QuestObjectView questView = _questObjects.FirstOrDefault(value => value.Id == config.id);
            if (questView == null)
            {
                Debug.Log("No views");
                return null;
            }

            if (_questFactories.TryGetValue(config.questType, out var factory))
            {
                IQuestModel questModel = factory.Invoke();
                return new QuestController(questView, questModel);
            }
            
            Debug.Log("No model");
            return null;
        }
    }
}  