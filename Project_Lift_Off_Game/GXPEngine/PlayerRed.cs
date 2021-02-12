using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

class PlayerRed : Sprite
{
    private float _speed = 0.5f;
    private float _xSpeed;
    private float _ySpeed;

    public PlayerRed() : base("circle2.png")
    {
        SetOrigin(width / 2f, height / 2f);
        SetScaleXY(0.5f, 0.5f);
    }

    void Update()
    {
        //movement

        _xSpeed = 0;
        _ySpeed = 0;

        if (Input.GetKey(Key.A))
        {
            _xSpeed = -_speed;
        }

        if (Input.GetKey(Key.D))
        {
            _xSpeed = _speed;
        }

        if (Input.GetKey(Key.W))
        {
            _ySpeed = -_speed;
        }

        if (Input.GetKey(Key.S))
        {
            _ySpeed = _speed;
        }

        Move(_xSpeed, _ySpeed);
    }

    public void OnCollision(GameObject other)
    {
        if (other is Wall)
        {
            Move(-_xSpeed, -_ySpeed);
        }

        if (other is PlayerGreen)
        {
            //SetScaleXY(1.7f, 1.7f);
        }
    }

}