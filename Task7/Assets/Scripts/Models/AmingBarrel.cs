using UnityEngine;

namespace TdgMvc
{
    public class AmingBarrel
    {
        private Transform _barrelTransform;
        private Transform _aimTransform;

        public AmingBarrel(Transform barrelTransform, Transform aimTransform)
        {
            _barrelTransform = barrelTransform;
            _aimTransform = aimTransform;
        }

        public void Update()
        {
            var dir = _aimTransform.position - _barrelTransform.position;
            var angle = Vector3.Angle(Vector3.down, dir);
            var axis = Vector3.Cross(Vector3.down, dir);
            _barrelTransform.rotation = Quaternion.AngleAxis(angle, axis);
        }
    }
}