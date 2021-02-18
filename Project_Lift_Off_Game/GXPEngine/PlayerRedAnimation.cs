using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;
public class PlayerRedAnimation : AnimationSprite
{
    int _frameAnimate;

    public PlayerRedAnimation() : base("queenD.png", 5, 4, -1, true, false)
    {
        //SetOrigin(102.4f, 102.4f);
        SetOrigin(128 / 2, 128 / 2);
        SetXY(64, 64);
    }

    void Update()
    {
        SetFrame(_frameAnimate);
        _frameAnimate += 1;
        if (_frameAnimate == 16)
        {
            _frameAnimate = 0;
        }
    }
}
