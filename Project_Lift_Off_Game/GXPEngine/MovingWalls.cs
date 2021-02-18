using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

public class MovingWall : Wall
{
    private int _blockId;

    public MovingWall()
    {
        
    }

    void Update()
    {
        switch ( _blockId )
        {
            case 1:
                x++;
                break;
            case 2:
                x--;
                break;
            case 3:
                y++;
                break;
            case 4:
                y--;
                break;
        }

        if  ( x < -32 )
        {
            x = 1302;
        }

        if ( x > 1302 )
        {
            x = -32;
        }

        if  ( y < 68 )
        {
            y = 1032;
        }

        if ( y > 1032 )
        {
            y = 68;
        }
    }

} 