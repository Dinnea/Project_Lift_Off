using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

public class Keys : Sprite //Keys that need to be picked up by pgreen
{
    //Sound _keySound;
    private Random _rnd = new Random();
    private int _time;
    private int _relocTimed;
    private int _timeLeftToReloc;

    public Keys() : base("triangle.png")
    {
        SetScaleXY(0.5f, 0.5f);
    }

    void Update()
    {
        _time = (Time.time);
        _timeLeftToReloc = ((_time - _relocTimed) / 1000);

        if (_timeLeftToReloc >= 10)
        {
            this.x = _rnd.Next(1, 22) * 64;
            this.y = _rnd.Next(1, 16) * 64;
            _relocTimed = Time.time;
        }
    }

    public void OnCollision(GameObject other)
    {
        if (other is PlayerGreen)
        {
            playerInteraction();
        }

        if (other is Wall || other is PowerUp || other is Keys || other is Exit )
        {
            this.x = _rnd.Next(2, 20) * 64;
            this.y = 100 + _rnd.Next(2, 14) * 64;
        }
    }

    public void playerInteraction() //Pick up
    {
        this.LateDestroy();
        //_keySound;
    }
}