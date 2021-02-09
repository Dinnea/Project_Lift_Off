using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

class Player1 : Sprite
 {
    private float speed = 1.0f;

    public Player1() : base("cirlcle.png")
    {
        SetOrigin(width / 2f, height / 2f);

        this.x = game.width/2;
        this.y = game.height/2;

    }


    void Update()
    {
        //movement
        if (Input.GetKey(Key.LEFT))
        {
            x = x - speed;
        }

        if (Input.GetKey(Key.RIGHT))
        {
            x = x + speed;
        }

        if (Input.GetKey(Key.UP))
        {
            y = y - speed;
        }

        if (Input.GetKey(Key.DOWN))
        {
            y = y + speed;
        }

    }

    public void OnCollision(GameObject other)
    {
      
    }

 }

