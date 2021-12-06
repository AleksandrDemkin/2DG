using System;
using Pathfinding;
using UnityEngine;

namespace TdgMvc
{
    public class EnemyAI
    {
        private readonly LevelObjectView _view;
        private readonly EnemyAIModel _model;
        private readonly Seeker _seeker;
        private readonly Transform _target;
        
        public EnemyAI(LevelObjectView view, EnemyAIModel model, Seeker seeker,
            Transform target)
        {
            _view = view != null ? view : throw new 
                ArgumentNullException(nameof(view));
            _model = model != null ? model : throw new
                ArgumentNullException(nameof(model));
            _seeker = seeker != null ? seeker : throw new
                ArgumentNullException(nameof(seeker));
            _target = target != null ? target : throw new
                ArgumentNullException(nameof(target));
        }
        
        public void FixedUpdate()
        {
            var newVelocity = _model.CalculateVelocity(_view._transform.position) *
                              Time.fixedDeltaTime;
            _view._rigidbody.velocity = newVelocity;
        }
        
        public void RecalculatePath()
        {
            if (_seeker.IsDone())
            {
                _seeker.StartPath(_view._rigidbody.position, _target.position,
                    OnPathComplete);
            }
        }
        
        private void OnPathComplete(Path p)
        {
            if (p.error) return;
            _model.UpdatePath(p);
        }
    }
}