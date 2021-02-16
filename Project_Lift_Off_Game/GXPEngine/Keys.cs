using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

public class Keys : Sprite //Keys that need to be picked up by pgreen
{
    //Sound _keySound;

    public Keys() : base( "triangle.png" )
    {
        SetScaleXY( 0.5f, 0.5f );
    }

    public void OnCollision( GameObject other )
    {
        if (other is PlayerGreen)
        {
            playerInteraction();
        }
    }

    public void playerInteraction() //Pick up
    {
        this.LateDestroy();
        //_keySound;
    }
}