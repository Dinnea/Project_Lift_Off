using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;
public class PowerUp : Sprite
{
    private Random _rnd = new Random();

    public PowerUp() : base("triangle2.png")
    {

    }

    void OnCollision(GameObject other)
    {
        if (other is Wall)
        {
            this.x = _rnd.Next(1, 22) * 64;
            this.y = _rnd.Next(1, 16) * 64;
        }
    }
}

