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

    private GameObject[] colliders;

    public PlayerGreen() : base("circle.png")
    {
        List<GameObject> setCollisions;
        setCollisions = new List<GameObject>();

        foreach (GameObject child in game.GetChildren(false))
        {
            if (child is Wall) setCollisions.Add(child);
        }
        colliders = setCollisions.ToArray();

        SetOrigin(width / 2f, height / 2f);

        this.x = game.width/2;
        this.y = game.height/2;

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

        MoveUntilCollision(xSpeed, ySpeed, colliders);
    }

    public void OnCollision(GameObject other)
    {
      
    }

 }

