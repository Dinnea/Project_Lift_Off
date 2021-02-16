using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

class PlayerRed : Player
{
 
    public PlayerRed() : base( "circle2.png" )
    {

        this.speed = 0.7f;
        this.playerNumber = 2;

        SetScaleXY(0.7f, 0.7f);
        this.wallCrusher = false;
        this.hasPowerup = false;
    }

    void Update()
    {
        PlayerMovement();
    }
}