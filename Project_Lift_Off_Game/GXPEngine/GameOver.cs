using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;
  public class GameOver : GameObject
{
    Sprite _player1;
    Sprite _player2;

    int _winner;

    public GameOver()
    {
        _winner = 0;

        if (Menu.playerID == 1)
        {
            _player1 = new Sprite("circle.png");
            AddChild(_player1);
            _player1.x = (game.width / 2);
            _player1.y = (game.height / 2.5f);
            _player1.SetOrigin(_player1.width / 2f, _player1.height / 2f);
            _player1.SetScaleXY(2f, 2f);
            _winner = 1;
        }

        if (Menu.playerID == 2)
        {
            _player2 = new Sprite("circle2.png");
            AddChild(_player2);
            _player2.x = (game.width / 2);
            _player2.y = (game.height / 2.5f);
            _player2.SetOrigin(_player2.width / 2f, _player2.height / 2f);
            _player2.SetScaleXY(2, 2f);
            _winner = 2;
        }
    }

    void Update()
    {
        if (Input.GetKey(Key.ENTER))
        {

            if (_winner == 1)
            {
                _player1.LateDestroy();
                Menu.switchMenu = 2;
            }
            else if (_winner == 2)
            {
                _player2.LateDestroy();
                Menu.switchMenu = 2;
            }

        }
    }
}