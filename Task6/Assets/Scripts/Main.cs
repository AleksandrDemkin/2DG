using System.Collections.Generic;
using UnityEngine;

namespace TdgMvc
{
    public class Main : MonoBehaviour
    {

        [SerializeField] private SpriteAnimationsConfig _playerConfig;
        [SerializeField] private SpriteAnimationsConfig _foodConfig;
        [SerializeField] private int _animationSpeed = 10;
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private CannonView _cannonView;
        [SerializeField] private List<LevelObjectView> _foodViews;

        private SpriteAnimatorController _playerAnimator;
        private SpriteAnimatorController _foodAnimator;
        private CameraController _cameraController;
        private PlayerController _playerController;
        private EmitterController _emitterController;
        private CannonAimController _cannonAimController;
        private FoodController _foodController;

        private void Start()
        {
            _playerConfig = Resources.Load<SpriteAnimationsConfig>("PlayerAnimCfg");
            _foodConfig = Resources.Load<SpriteAnimationsConfig>("FoodAnimCfg");
            if (_playerConfig)
            {
                _playerAnimator = new SpriteAnimatorController(_playerConfig);
            }
            if (_foodConfig)
            {
                _foodAnimator = new SpriteAnimatorController(_foodConfig);
            }
            
            _playerAnimator.StartAnimation(_playerView._spriteRenderer, AnimState.Run, true, _animationSpeed);

            _playerController = new PlayerController(_playerView, _playerAnimator);

            _foodController = new FoodController(_playerView, _foodViews, _foodAnimator);

            _cameraController = new CameraController(_playerView._transform, Camera.main.transform);

            _cannonAimController = new CannonAimController(_cannonView._barrelTransform, _playerView._transform);
            _emitterController = new EmitterController(_cannonView._bullets, _cannonView._emitterTransform);
        }

        private void Update()
        { 
            _playerController.Update();
            _cameraController.Update();
            _cannonAimController.Update();
            _emitterController.Update();
            _foodAnimator.Update();
        }
    }
}
