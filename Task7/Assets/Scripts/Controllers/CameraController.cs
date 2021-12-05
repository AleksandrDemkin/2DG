using UnityEngine;

namespace TdgMvc
{
        public class CameraController
        {
                private float X;
                private float Y;

                private float offsetX;
                private float offsetY;

                private int _canSpeed = 300;

                private Transform _playerTransform;
                private Transform _camersTransform;

                public CameraController(Transform player, Transform camera)
                {
                        _playerTransform = player;
                        _camersTransform = camera;
                }

                public void Update()
                {
                        Y = _playerTransform.transform.position.y;
                        X = _playerTransform.transform.position.x;

                        _camersTransform.transform.position = Vector3.Lerp(_camersTransform.position, new Vector3(X + offsetX, Y+ offsetY, _camersTransform.position.z), Time.deltaTime * _canSpeed);
                }
        }
}