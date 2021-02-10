using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

public class Keys : Sprite
{
    public Keys() : base("triangle.png")
    {
        SetScaleXY(0.5f, 0.5f);
    }
    public void OnCollision(GameObject other)
    {
        if (other is PlayerGreen)
        {
            LateDestroy();
        }
    }
}