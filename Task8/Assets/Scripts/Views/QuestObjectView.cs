using TMPro;
using UnityEngine;

namespace TdgMvc
{
    public class QuestObjectView : LevelObjectView
    {
        public int Id
        {
            get => _id;
            set => _id = value;
        }
        
        [SerializeField] private Color _completedColor;
        [SerializeField] private int _id;
        [SerializeField] private Color _defaultColor;
        
        private void Awake()
        {
            _defaultColor = _spriteRenderer.color;
        }
        
        public void ProcessComplete()
        {
            _spriteRenderer.color = _completedColor;
        }
        
        public void ProcessActivate()
        {
            _spriteRenderer.color = _defaultColor;
        }
    }
}