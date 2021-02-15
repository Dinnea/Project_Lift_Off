using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

class Player : Sprite
{
    // SPEED VARIABLES
    float _speed;
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

    public Player(String filename) : base(filename)
    {
        
        _wallCrusher = false;
        _hasPowerup = false;
    }

    void Update()
    {
        //movement

        _xSpeed = 0;
        _ySpeed = 0;

        Move(_xSpeed, _ySpeed);

        if (_hasPowerup)
        {
            poweredUp();
        }
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
        }
    }
    private void poweredUp()
    {
        _timer = (Time.time - _timePickedUp) / 1000;
        switch (_powerId)
        {
            case 1:
                _speed = _speed * 2;
                break;
            case 2:
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
