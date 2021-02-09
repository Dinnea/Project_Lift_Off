using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;


public class Wall : Sprite
{


    public Wall() : base("square.png")
    {
        SetOrigin(this.width / 2f, this.height / 2f);

        this.x = 200;
        this.y = 300;
    }
}

