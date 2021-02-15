using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

class PlayerRed : Sprite
{
    // SPEED VARIABLES
    private float _speed = 0.7f;
    private float _xSpeed;
    private float _ySpeed;

    // POWERUP VARIABLES
    private bool _hasPowerup;
    private int _powerId;
    private Random _rnd = new Random();
    private int _powerTime = 2;
    private int _timePickedUp;
    private int _timer;
    private bool _wallCrusher;
    private int _isItTime;

    public PlayerRed() : base("circle2.png")
    {
        SetScaleXY(0.7f, 0.7f);
        _wallCrusher = false;
        _hasPowerup = false;
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

        if (_hasPowerup)
        {
            poweredUp();
        }
    }

    public void OnCollision(GameObject other)
    {
     //enviroment collisions

        if (other is Wall && _wallCrusher == false || other is Border && _wallCrusher == true)
        {
            Move(-_xSpeed, -_ySpeed);
        }

        else if (other is Wall && _wallCrusher == true)
        {
            other.LateDestroy();
        }

        //Power up collision!
        if (other is PowerUp)
        {

            _isItTime = _rnd.Next(1, 5);

            if (_isItTime == 1)
            {
                Level.maxTime = Level.maxTime - 5;
                other.LateDestroy();
            }
            else
            {
                _hasPowerup = true;
                _timePickedUp = Time.time;
                _powerId = _rnd.Next(1, 4);
                other.LateDestroy();
            }
        }


    }
    private void poweredUp()
    {
        _timer = (Time.time - _timePickedUp) / 1000;
        switch (_powerId)
        {
            case 1:
                _speed = 1.7f;
                break;
            case 2:
                _speed = 1.05f;
                break;
            case 3:
                _wallCrusher = true;
                break;
        }

        if (_timer >= _powerTime)
        {
            _hasPowerup = false;
            _timer = 0;
            _speed = 0.7f;
            _wallCrusher = false;
         }
    }
}