using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TdgMvc
{
    public class Lessons : MonoBehaviour
    {
        /*[SerializeField] private Camera _camera;
        [SerializeField] private SpriteRenderer _back;*/
        [SerializeField] private Transform _camera;

        [SerializeField] private Transform _back;

        /*[SerializeField] private SomeView _someView;
        add links to test views <1>
        private SomeManager _someManager;
        add links to some logic managers <2>*/
        [SerializeField] private SpriteAnimatorController _spriteAnimator;
        [SerializeField] private ParalaxManager _paralaxManager;
        [SerializeField] private CharacterView _characterView;
        [SerializeField] private PlayerController _playerController;

        #region Magnitude

        [SerializeField] private Vector2 vector2D;
        [SerializeField] private Vector3 vector3D;

        #endregion

        #region sqrMagnitude

        [SerializeField] private Vector3 p1, p2;
        [SerializeField] private float distance;

        #endregion

        #region Transform

        [SerializeField] private int speed = 1;

        #endregion

        #region MoveTowards

        [SerializeField] private Transform target;

        #endregion

        #region Quaternion

        [SerializeField] private Transform from;
        [SerializeField] private Transform to;

        #endregion


        private void Start()
        {
            //SomeConfig config = Resources.Load("SomeConfig", typeof(SomeConfig))as SomeConfig;
            //load some configs here <3>
            //_someManager = new SomeManager(config);
            //create some logic managers here for tests <4>
            SpriteAnimationsConfig config =
                Resources.Load<SpriteAnimationsConfig>("SpriteAnimationsConfig");

            _spriteAnimator = new SpriteAnimatorController(config);

            #region Magnitude

            print(vector2D.magnitude);
            print(vector3D.magnitude);

            #endregion

            #region sqrMagnitude

            distance = Vector3.Distance(p1, p2);
            print(distance);
            distance = (p1 - p2).magnitude;
            print(distance);
            distance = Mathf.Sqrt((p1 - p2).sqrMagnitude);
            print(distance);

            #endregion

            #region DotProduct

            print(Vector3.Dot(p1, p2));

            #endregion

            #region CrossProduct

            print(Vector3.Cross(p1, p2));

            #endregion

            #region Quaternion

            transform.rotation = Quaternion.identity;

            transform.rotation = Quaternion.FromToRotation(Vector3.up, Vector3.right);

            #endregion
        }

        private void Update()
        {
            //_someManager.Update();
            ////update logic managers here <5>
            _paralaxManager = new ParalaxManager(_camera, _back);

            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, AnimState.Run, true, 10);

            #region Transform

            transform.position += new Vector3(Time.deltaTime, 0, 0);

            transform.Translate(Vector3.forward * Time.deltaTime);
            transform.Translate(Vector3.forward * Time.deltaTime, Space.World);
            transform.Translate(0, 0, Time.deltaTime);
            transform.Translate(Vector3.forward * Time.deltaTime, Camera.main.transform);

            #endregion

            #region MoveTowards

            transform.position = Vector3.MoveTowards(transform.position,
                target.position, speed * Time.deltaTime);

            #endregion

            #region Quaternion

            Vector3 relativePos = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            var transform1 = transform;
            transform1.rotation = rotation;

            float angle = Quaternion.Angle(transform.rotation, target.rotation);

            transform.rotation = Quaternion.Euler(0, 30, 0);

            transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, Time.time);

            #endregion
        }

        private void FixedUpdate()
        {
            //_someManager.FixedUpdate();
            ////update logic managers here <6>

        }

        private void OnDestroy()
        {
            //_someManager.Dispose();
            ////dispose logic managers here <7>
        }
    }
}
