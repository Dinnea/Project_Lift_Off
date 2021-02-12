using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

class PlayerGreen : Sprite
{
    private float _speed = 1.0f;
    private float _xSpeed;
    private float _ySpeed;


    private int storedKeys; // How many keys the player holds. 

    public PlayerGreen() : base("circle.png")
    {
        storedKeys = 0;

        SetOrigin(width / 2f, height / 2f);
        SetScaleXY(0.5f, 0.5f);

    }

    void Update()
    {
        //movement
        _xSpeed = 0;
        _ySpeed = 0;


        if (Input.GetKey(Key.LEFT))
        {
            _xSpeed = -_speed;
            //SetFrame(5);
            //this.scaleX = -1;
        }

        if (Input.GetKey(Key.RIGHT))
        {
            _xSpeed = _speed;
            //SetFrame(2);
            //this.scaleX = 1;
        }

        if (Input.GetKey(Key.UP))
        {
            _ySpeed = -_speed;
            //this.scaleY = 1;
            //SetCycle(7,7,30,false);
        }

        if (Input.GetKey(Key.DOWN))
        {
            _ySpeed = _speed;
            //this.scaleY = -1;
        }

        if (storedKeys == 3)
        {
            End();
            Menu.playerID = 1;
        }

        Move(_xSpeed, _ySpeed);
    }

    public void OnCollision(GameObject other)
    {
        if (other is Keys)
        {
            storedKeys = storedKeys + 1; //pickup a key
        }

        if (other is Wall)
        {
            Move(-_xSpeed, -_ySpeed);
        }

        if (other is PlayerRed)
        {
            End();
            Menu.playerID = 2;
        }
    }

    public void End()
    {
        Menu.switchMenu = 1;
    }
}