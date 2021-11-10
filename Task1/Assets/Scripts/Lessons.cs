using System.Collections;
using System.Collections.Generic;
using Roguelike;
using UnityEngine;

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
    [SerializeField] private SpriteAnimator _spriteAnimator;
    [SerializeField] private ParalaxManager _paralaxManager;
    [SerializeField] private  CharacterView _characterView;
    
    private void Start()
    {
    //SomeConfig config = Resources.Load("SomeConfig", typeof(SomeConfig))as SomeConfig;
    //load some configs here <3>
    //_someManager = new SomeManager(config);
    //create some logic managers here for tests <4>
    SpriteAnimationsConfig config =
        Resources.Load<SpriteAnimationsConfig>("SpriteAnimationsConfig");
    
    _spriteAnimator = new SpriteAnimator(config);
    }
    
    private void Update()
    {
        //_someManager.Update();
        ////update logic managers here <5>
        _paralaxManager = new ParalaxManager(_camera, _back);
        
        _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.sonic_walk, true, 10);

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
