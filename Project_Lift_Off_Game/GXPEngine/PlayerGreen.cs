using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

class PlayerGreen : Sprite
{
    // SPEED VARIABLES
    private float _speed = 1.0f;
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
    private bool _canBeHit;
    private int _isItTime;

    private int storedKeys; // How many keys the player holds. 

    public PlayerGreen() : base("circle.png")
    {
        storedKeys = 0;
        _wallCrusher = false;
        _canBeHit = true;
        SetScaleXY(0.7f, 0.7f);

    }

    void Update()
    {
        //--------------------------------------------------
        //                   Movement
        //---------------------------------------------------

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

        Move(_xSpeed, _ySpeed);

        //
        // Power ups

        if (_hasPowerup)
        {
            poweredUp();
        }
    }

    public void OnCollision(GameObject other)
    {
        //pickup
        if (other is Keys)
        {
            storedKeys = storedKeys + 1; //pickup a key
        }

        //enviroment collision

        if (other is Wall && _wallCrusher == false || other is Border && _wallCrusher == true)
        {
            Move(-_xSpeed, -_ySpeed);
        }

        else if (other is Wall && _wallCrusher == true)
        {
            other.LateDestroy();
        }

        if (other is Exit && storedKeys == 3)
        {
            End();
            Menu.playerID = 1;
        }

        else if (other is Exit && storedKeys < 3)
        {
            Move(-_xSpeed, -_ySpeed);
        }

        //player collision
        if (other is PlayerRed && _canBeHit == true)
        {
            End();
            Menu.playerID = 2;
        }

        //Power up collision!
        if (other is PowerUp)
        {
            
            _isItTime = _rnd.Next(1, 5);

            if (_isItTime == 1) {
                Level.maxTime = Level.maxTime + 5;
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
    //-------------------------------------
    //              PowerUps
    //------------------------------------
    private void poweredUp()
    {
        _timer = (Time.time - _timePickedUp) / 1000;
        switch (_powerId) {
            case 1:
                _speed = 2.0f;
                break;
            case 2:
                _powerTime = 5;
                _canBeHit = false;
                break;
            case 3:
                _wallCrusher = true;
                break;
        }

        if (_timer >= _powerTime)
        {
            _powerTime = 2;
            _hasPowerup = false;
            _timer = 0;
            _speed = 1.0f;
            _wallCrusher = false;
            _canBeHit = true;
        }
        
        
    }

    public void End()
    {
        Menu.switchMenu = 1;
    }
}