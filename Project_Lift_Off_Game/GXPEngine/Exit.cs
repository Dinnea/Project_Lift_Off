using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

public class Exit : Sprite   // Green player uses this to exit
{
    public Exit() : base( "square1.png" )
    {
        SetOrigin( this.x / 2, this.y / 2 );
    }
}
