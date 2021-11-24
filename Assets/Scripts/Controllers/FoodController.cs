using System;
using System.Collections.Generic;
using UnityEngine;

namespace TdgMvc
{
    public class FoodController : IDisposable
    {
        private const float _animationSpeed = 10;

        private LevelObjectView _characterView;
        private SpriteAnimatorController _foodAnimator;
        private List<LevelObjectView> _foodWiews;

        public FoodController(LevelObjectView characterView, List<LevelObjectView> foodWiews, SpriteAnimatorController foodAnimator)
        {
            _characterView = characterView;
            _foodWiews = foodWiews;
            _foodAnimator = foodAnimator;
            _characterView.OnLevelObjectContact += OnLevelObjectContact;

            foreach (LevelObjectView foodWiew in _foodWiews)
            {
                foodAnimator.StartAnimation(foodWiew._spriteRenderer, AnimState.Food, true, _animationSpeed);
            }
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_foodWiews.Contains(contactView))
            {
                _foodAnimator.StopAnimation(contactView._spriteRenderer);
                GameObject.Destroy(contactView.gameObject);
            }
        }

        public void Dispose()
        {
            _characterView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}