using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

namespace TdgMvc
{
    public class EnemiesConfigurator : MonoBehaviour
    {
        [Header("Simple AI")]
        [SerializeField] private AIConfig _simplePatrolAIConfig;
        [SerializeField] private LevelObjectView _simplePatrolAIView;
        
        [Header("Enemy AI")]
        [SerializeField] private AIConfig _enemyAIConfig;
        [SerializeField] private LevelObjectView _enemyAIView;
        [SerializeField] private Seeker _enemyAISeeker;
        [SerializeField] private Transform _enemyAITarget;
        
        [Header("Protector AI")]
        [SerializeField] private LevelObjectView _protectorAIView;
        [SerializeField] private AIDestinationSetter _protectorAIDestinationSetter;
        [SerializeField] private AIPatrolPath _protectorAIPatrolPath;
        [SerializeField] private LevelObjectTrigger _protectedZoneTrigger;
        [SerializeField] private Transform[] _protectorWaypoints;
        
        private SimplePatrolAI _simplePatrolAI;
        private EnemyAI _enemyAI;
        private ProtectorAI _protectorAI;
        private ProtectedZone _protectedZone;
        
        private void Start()
        {
            _simplePatrolAI = new SimplePatrolAI(_simplePatrolAIView, new
                SimplePatrolAIModel(_simplePatrolAIConfig));
            _enemyAI = new EnemyAI(_enemyAIView, new
                EnemyAIModel(_enemyAIConfig), _enemyAISeeker, _enemyAITarget);
            InvokeRepeating(nameof(RecalculateAIPath), 0.0f, 1.0f);
            _protectorAI = new ProtectorAI(_protectorAIView, new
                    PatrolAIModel(_protectorWaypoints), _protectorAIDestinationSetter,
                _protectorAIPatrolPath);
            _protectorAI.Init();
            _protectedZone = new ProtectedZone(_protectedZoneTrigger, new
                List<IProtector>{ _protectorAI });
            _protectedZone.Init();
        }
        private void FixedUpdate()
        {
            if (_simplePatrolAI != null) _simplePatrolAI.FixedUpdate();
            if (_enemyAI != null) _enemyAI.FixedUpdate();
        }
        
        private void OnDestroy()
        {
            _protectorAI.Deinit();
            _protectedZone.Deinit();
        }
        
        private void RecalculateAIPath()
        {
            _enemyAI.RecalculatePath();
        }
    }
}