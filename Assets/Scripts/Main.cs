using UnityEngine;

namespace TdgMvc
{
    public class Main : MonoBehaviour
    {

        [SerializeField] private SpriteAnimationsConfig _playerConfig;
        [SerializeField] private int _animationSpeed = 10;
        [SerializeField] private LevelObjectView _playerView;

        private SpriteAnimatorController _playerAnimator;
        private CameraController _cameraController;
        private PlayerController _playerController;

        private void Start()
        {
            _playerConfig = Resources.Load<SpriteAnimationsConfig>("PlayerAnimCfg");
            if (_playerConfig)
            {
                _playerAnimator = new SpriteAnimatorController(_playerConfig);
            }
            
            _playerAnimator.StartAnimation(_playerView._spriteRenderer, AnimState.Run, true, _animationSpeed);

            _playerController = new PlayerController(_playerView, _playerAnimator);

            _cameraController = new CameraController(_playerView._transform, Camera.main.transform);
        }

        private void Update()
        {
            _playerController.Update();
            _cameraController.Update();
        }
    }
}
