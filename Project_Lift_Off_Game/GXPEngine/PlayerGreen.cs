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

    public int storedKeys; // Howmany keys the player holds. 

    public PlayerGreen() : base("circle.png")
    {
        storedKeys = 0;

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

        MoveUntilCollision(xSpeed, ySpeed, colliders);
    }

    public void OnCollision(GameObject other)
    {
        if(other is Keys)
        {
            storedKeys = storedKeys + 1; //needs to be associated with the key..
        }
    }

 }

