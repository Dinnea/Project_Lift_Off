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
    public int bonusTime = 0;

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


    }

    public void OnCollision(GameObject other)
    {
     
        if (other is Wall && _wallCrusher == false)
        {
            Move(-_xSpeed, -_ySpeed);
        }

        else if (other is Wall && _wallCrusher == true)
        {
            other.LateDestroy();
        }
         
        if (other is PowerUp)
        {
            _hasPowerup = true;
            _timePickedUp = Time.time;
            _powerId = _rnd.Next(1, 4);
            other.LateDestroy();
            //Console.WriteLine(_timePickedUp);

        }
    }
    private void poweredUp()
    {
        _timer = (Time.time - _timePickedUp) / 1000;
        switch (_powerId)
        {
            case 1:
                //_wallCrusher = true;
                _speed =_speed * 2;
                break;
            case 2:
                _speed = _speed * (1.5f);

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
            
            Console.WriteLine("POWER SPENT");

        }


    }
}