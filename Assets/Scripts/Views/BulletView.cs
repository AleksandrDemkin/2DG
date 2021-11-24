using UnityEngine;

namespace TdgMvc
{
    public class BulletView: LevelObjectView
    {
        [SerializeField] private TrailRenderer _trail;
        public Transform Transform;
        public Rigidbody2D Rigidbody2D;
        public SpriteRenderer SpriteRenderer;

        public void SetVisible(bool visible)
        {
            if (_trail) _trail.enabled = visible;
            if (_trail) _trail.Clear();
            SpriteRenderer.enabled = visible;
        }
    }
}