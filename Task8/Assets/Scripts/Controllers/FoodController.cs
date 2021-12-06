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
        private List<LevelObjectView> _foodViews;

        public FoodController(LevelObjectView characterView, List<LevelObjectView> foodViews, SpriteAnimatorController foodAnimator)
        {
            _characterView = characterView;
            _foodViews = foodViews;
            _foodAnimator = foodAnimator;
            _characterView.OnLevelObjectContact += OnLevelObjectContact;

            foreach (LevelObjectView foodView in _foodViews)
            {
                foodAnimator.StartAnimation(foodView._spriteRenderer, AnimState.Food, true, _animationSpeed);
            }
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_foodViews.Contains(contactView))
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