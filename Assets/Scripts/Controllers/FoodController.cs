using System;
using System.Collections.Generic;
using UnityEngine;

namespace TdgMvc
{
    public class FoodController : IDisposable
    {
        private const float _animationSpeed = 10;

        private LevelObjectView _characterView;
        private SpriteAnimatorController _spriteAnimator;
        private List<LevelObjectView> _foodWiews;

        public FoodController(LevelObjectView characterView, List<LevelObjectView> foodWiews, SpriteAnimatorController spriteAnimator)
        {
            _characterView = characterView;
            _foodWiews = foodWiews;
            _spriteAnimator = spriteAnimator;
            _characterView.OnLevelObjectContact += OnLevelObjectContact;

            foreach (var foodWiew in foodWiews)
            {
                spriteAnimator.StartAnimation(foodWiew._spriteRenderer, AnimState.Food, true, _animationSpeed);
            }
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_foodWiews.Contains(contactView))
            {
                _spriteAnimator.StopAnimation(contactView._spriteRenderer);
                GameObject.Destroy(contactView.gameObject);
            }
        }

        public void Dispose()
        {
            _characterView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}