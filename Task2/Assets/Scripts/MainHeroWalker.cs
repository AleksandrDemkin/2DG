using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roguelike
{
    private float xAxisInput = 0;
    private bool doJump = false;
    
    private LevelObjectView _view;
    private SpriteAnimator _spriteAnimator;
    
    public MainHeroWalker(LevelObjectView view, SpriteAnimator spriteAnimator)
    {
    _view = view;
    _spriteAnimator = spriteAnimator;
    }
    
    public void Update()
    {
    doJump = Input.GetAxis("Vertical") > 0;
    xAxisInput = Input.GetAxis("Horizontal");
//add behavior logic here
    }
}
