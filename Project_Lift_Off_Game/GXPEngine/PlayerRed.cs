using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

class PlayerRed : Sprite
{
    private float speed = 0.5f;
    private float xSpeed;
    private float ySpeed;

    

    public PlayerRed() : base("circle2.png")
    {
        this.x = 500;
        this.y = 600;
        SetScaleXY(0.7f, 0.7f);

    }


    void Update()
    {
        //movement

        xSpeed = 0;
        ySpeed = 0;

        if (Input.GetKey(Key.A))
        {
            xSpeed = -speed;
        }

        if (Input.GetKey(Key.D))
        {
            xSpeed = speed;
        }

        if (Input.GetKey(Key.W))
        {
            ySpeed = -speed;
        }

        if (Input.GetKey(Key.S))
        {
            ySpeed = speed;
        }

        Move(xSpeed, ySpeed);
    }

    public void OnCollision(GameObject other)
    {
        if (other is Wall)
        {
            Move(-xSpeed, -ySpeed);
        }
    }

}