using System;
using System.Collections.Generic;
using UnityEngine;

namespace TdgMvc
{
    public class DrinkController : IDisposable
    {
        private const float _animationSpeed = 10;

        private LevelObjectView _characterView;
        private SpriteAnimatorController _spriteAnimator;
        private List<LevelObjectView> _drinkWiews;

        public DrinkController(LevelObjectView characterView, List<LevelObjectView> drinkWiews, SpriteAnimatorController spriteAnimator)
        {
            _characterView = characterView;
            _drinkWiews = drinkWiews;
            _spriteAnimator = spriteAnimator;
            _characterView.OnLevelObjectContact += OnLevelObjectContact;

            foreach (var drinkWiew in drinkWiews)
            {
                spriteAnimator.StartAnimation(drinkWiew._spriteRenderer, AnimState.Drink, true, _animationSpeed);
            }
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_drinkWiews.Contains(contactView))
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