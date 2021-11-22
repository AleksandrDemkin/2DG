using UnityEngine;
using UnityEngine.PlayerLoop;

namespace TdgMvc
{
    public class PlayerController
    {
        private float _xAxisInput;
        private bool _isJump;

        private float _walkSpeed = 200f;
        private float _animationSpeed = 10f;
        private float _movingTreshold = 0.1f;
        
        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);

        private bool _isMoving;

        private float _jumpSpeed = 9f;
        private float _jumpTreshold = 1f;
        private float _xVelocity;
        
        private bool _isHit;

        private LevelObjectView _view;
        private SpriteAnimatorController _spriteAnimator;
        private readonly ContactPooler _contactPooler;

        public PlayerController(LevelObjectView player, SpriteAnimatorController animator)
        {
            _view = player;
            _spriteAnimator = animator;
            _spriteAnimator.StartAnimation(_view._spriteRenderer,AnimState.Idle, true, _animationSpeed);
            _contactPooler = new ContactPooler(_view._collider);
        }

        public void MoveTowards()
        {
            _xVelocity = Time.fixedDeltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1);
            _view._rigidbody.velocity = _view._rigidbody.velocity.Change(x: _xVelocity);
            _view._transform.localScale = (_xAxisInput < 0 ? _leftScale : _rightScale);
        }

        public void Update()
        {
            _spriteAnimator.Update();
            _xAxisInput = Input.GetAxis("Horizontal");
            _isJump = Input.GetAxis("Vertical") > 0;
            _isMoving = Mathf.Abs(_xAxisInput) > _movingTreshold;
            _isHit = Input.GetMouseButtonDown(0);
            _contactPooler.Update();

            if (_isMoving)
            {
                MoveTowards();
            }

            if (_isHit)
            {
                //apply damage
            }

            if (_contactPooler.IsGrounded)
            {
                _spriteAnimator.StartAnimation(_view._spriteRenderer, _isMoving ? AnimState.Run : AnimState.Idle, true,
                    _animationSpeed);

                if (_isJump && Mathf.Abs(_view._rigidbody.velocity.y) <= _jumpTreshold) 
                {
                    _view._rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
                }
            }
            else
            {
                if (Mathf.Abs(_view._rigidbody.velocity.y) > _jumpTreshold)
                {
                    _spriteAnimator.StartAnimation(_view._spriteRenderer, AnimState.Jump, true, _animationSpeed);
                }
            }
        }
    }
} 