using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;


public class Wall : Sprite
{


    public Wall() : base( "square.png" )
    {
        SetOrigin( this.x/2, this.y/2 );
    }
}

