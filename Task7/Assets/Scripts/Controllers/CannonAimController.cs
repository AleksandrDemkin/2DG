using UnityEngine;

namespace TdgMvc
{
    public class CannonAimController
    {
        private Transform _barrelTransform;
        private Transform _targetTransform;

        private Vector3 _dir;
        private float _angle;
        private Vector3 _axis;

        public CannonAimController(Transform barrelTransform, Transform playerTransform)
        {
            _barrelTransform = barrelTransform;
            _targetTransform = playerTransform;
        }

        public void Update()
        {
            _dir = _targetTransform.position - _barrelTransform.position;
            _angle = Vector3.Angle(Vector3.down, _dir);

            _axis = Vector3.Cross(Vector3.down, _dir);
            _barrelTransform.rotation = Quaternion.AngleAxis(_angle, _axis);
        }
    }
}