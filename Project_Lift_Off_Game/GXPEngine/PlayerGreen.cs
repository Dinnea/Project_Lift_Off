using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

class PlayerGreen : Sprite
{
    private float speed = 1.0f;
    private float xSpeed;
    private float ySpeed;

    public int storedKeys; // How many keys the player holds. 

    public PlayerGreen() : base("circle.png")
    {
        storedKeys = 0;


        SetOrigin(width / 2f, height / 2f);

        this.x = game.width / 2;
        this.y = game.height / 2;

        SetScaleXY(0.7f, 0.7f);

    }


    void Update()
    {
        //movement

        xSpeed = 0;
        ySpeed = 0;

        if (Input.GetKey(Key.LEFT))
        {
            xSpeed = -speed;
        }

        if (Input.GetKey(Key.RIGHT))
        {
            xSpeed = speed;
        }

        if (Input.GetKey(Key.UP))
        {
            ySpeed = -speed;
        }

        if (Input.GetKey(Key.DOWN))
        {
            ySpeed = speed;
        }

        //Keys (testing)
        if (storedKeys == 3)
        {
            SetScaleXY(2.9f, 2.9f);
        }

        Move(xSpeed, ySpeed);
    }

    public void OnCollision(GameObject other)
    {
        if (other is Keys)
        {
            storedKeys = storedKeys + 1; //pickup a key
        }

        if (other is Wall)
        {
            Move(-xSpeed, -ySpeed);
        }
    }
}