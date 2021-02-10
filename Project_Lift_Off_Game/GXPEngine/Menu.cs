using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

public class Menu : GameObject
{
    Button _startButton;
    bool _hasStarted;
    public Menu()
    {
        _hasStarted = false;
        _startButton = new Button();
        AddChild(_startButton);
        _startButton.x = (game.width - _startButton.width) / 2;
        _startButton.y = (game.height - _startButton.height) / 2;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (_startButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                startGame();
                hideMenu();
            }
        }
    }

    void hideMenu()
    {
        _startButton.visible = false;

    }

    void startGame()
    {
        if (_hasStarted == false){ 
            Level level = new Level();
            AddChild(level);
            _hasStarted = true;
        }
    }
}

