using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

class PlayerRed : Player
{
 
    public PlayerRed() : base( "circle2.png" )
    {

        this.speed = 1.4f;
        this.playerNumber = 2;

        this.wallCrusher = false;
        this.hasPowerup = false;
    }

    void Update()
    {
        PlayerMovement();
        //Check for power up!
        if (hasPowerup)
        {
            PoweredUp();
        }

        //check for bad

        if (hasBad)
        {
            Trap();
        }
    }
}