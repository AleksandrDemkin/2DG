using System;
using System.Collections.Generic;
using UnityEngine;

namespace TdgMvc
{
    public class LevelCompleteManager : IDisposable
    {
        private Vector3 _startPosition;
        private LevelObjectView _characterView;
        private List<LevelObjectView> _deathZones;
        private List<LevelObjectView> _winZones;
        
        
        public LevelCompleteManager(LevelObjectView characterView,
            List<LevelObjectView> deathZones, List<LevelObjectView> winZones)
        {
            _startPosition = characterView._transform.position;
            characterView.OnLevelObjectContact += OnLevelObjectContact;
            _characterView = characterView;
            _deathZones = deathZones;
            _winZones = winZones;
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_deathZones.Contains(contactView))
            {
                _characterView._transform.position = _startPosition;
            }
        }

        public void Dispose()
        {
            _characterView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}