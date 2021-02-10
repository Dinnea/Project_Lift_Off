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

    private GameObject[] colliders;

    public PlayerRed() : base("circle2.png")
    {
        List<GameObject> setCollisions;
        setCollisions = new List<GameObject>();

        foreach (GameObject child in game.GetChildren(false))
        {
            if (child is Wall) setCollisions.Add(child);
        }
        colliders = setCollisions.ToArray();

        SetOrigin(width / 2f, height / 2f);

        this.x = game.width / 3;
        this.y = game.height / 3;

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

        MoveUntilCollision(xSpeed, ySpeed, colliders);
    }

    public void OnCollision(GameObject other)
    {

    }

}