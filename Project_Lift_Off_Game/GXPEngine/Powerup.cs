using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;
public class PowerUp : Sprite
{
    private Random _rnd = new Random();

    public PowerUp() : base("powerup.png")
    {

    }

    void OnCollision(GameObject other)
    {
        if (other is Wall || other is Keys || other is Exit)
        {
            this.x = _rnd.Next(2, 21) * 64;
            this.y = 100 + _rnd.Next(2, 15) * 64;
        }
    }
}

