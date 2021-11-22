using System;
using UnityEngine;

namespace TdgMvc
{
    public class LevelObjectView : MonoBehaviour
    {
        public Transform _transform;
        public SpriteRenderer _spriteRenderer;
        public Collider2D _collider;
        public Rigidbody2D _rigidbody;

        public Action<LevelObjectView> OnLevelObjectContact { get; set; }

        private void OnTriggerEnter(Collider2D _collider)
        {
            var levelObject = _collider.gameObject.GetComponent<LevelObjectView>();
            OnLevelObjectContact?.Invoke(levelObject);
        }
    }
}
