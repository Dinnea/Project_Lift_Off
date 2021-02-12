using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

public class Menu : GameObject
{
    Button _startButton;
    Button _exitButton;

    Sprite _player1;
    Sprite _player2;

    Sprite _player1Name;
    Sprite _player2Name;

    Sound _menuPress;
    Sound _menuBack;

    bool _hasStarted;
    bool _hasEnded;

    private GameOver _gameOver;
    private Level _level;
    private HUD _hud;
    private Menu _menu;

    public static int switchMenu = 0; // Restarts, and resets menu again. (0 = start) (1 = gameover) (2 = reset to start)
    public static int playerID = 0; // Winner in GameOver.cs
    public Menu()
    {
        _menuPress = new Sound("menu.wav", false, false);
        _menuBack = new Sound("menuBack.wav", false, false);

        _hasStarted = false;
        _hasEnded = false;
        //_menu = menu;

        ///////////////////////// Buttons ///////////////////////////////

        _startButton = new Button();
        AddChild(_startButton);
        _startButton.x = (game.width) / 2;
        _startButton.y = 500;
        _startButton.SetOrigin(_startButton.width / 2f, _startButton.height / 2f);

        _exitButton = new Button();
        AddChild(_exitButton);
        _exitButton.x = (game.width) / 2;
        _exitButton.y = 600;
        _exitButton.SetOrigin(_exitButton.width / 2f, _exitButton.height / 2f);

        ////////////////////////// Players //////////////////////////////

        _player1 = new Sprite("circle.png");
        AddChild(_player1);
        _player1.x = ((game.width / 5) * 1.5f);
        _player1.y = ((game.height / 5) * 3 - _player1.height);
        _player1.SetOrigin(_player1.width / 2f, _player1.height / 2f);
        _player1.SetScaleXY(1.5f, 1.5f);

        _player1Name = new Sprite("first_characters.png");
        AddChild(_player1Name);
        _player1Name.x = ((game.width / 5) * 1.5f);
        _player1Name.y = ((game.height / 5) * 3);
        _player1Name.SetOrigin(_player1Name.width / 2f, _player1Name.height / 2f);
        _player1Name.SetScaleXY(0.4f, 0.4f);

        _player2 = new Sprite("circle2.png");
        AddChild(_player2);
        _player2.x = ((game.width / 5) * 3.5f);
        _player2.y = ((game.height / 5) * 3 - _player2.height);
        _player2.SetOrigin(_player2.width / 2f, _player2.height / 2f);
        _player2.SetScaleXY(1.5f, 1.5f);

        _player2Name = new Sprite("first_characters2.png");
        AddChild(_player2Name);
        _player2Name.x = ((game.width / 5) * 3.5f);
        _player2Name.y = ((game.height / 5) * 3);
        _player2Name.SetOrigin(_player2Name.width / 1.8f, _player2Name.height / 2f);
        _player2Name.SetScaleXY(0.4f, 0.4f);
    }

    void Update()
    {
        if (switchMenu == 1)
        {
            _hasStarted = false;
            _hasEnded = true;
            _level.LateDestroy();
            _hud.LateDestroy();
            showGameOver();
        }
        if (switchMenu == 2)
        {
            showMenu();
            _gameOver.LateDestroy();
            _menuBack.Play();
            _hasEnded = false;
            switchMenu = 0;
            playerID = 0;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (_startButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                _hasStarted = true;
                startGame();
                hideMenu();
                _menuPress.Play();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (_exitButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                exitGame();
            }
        }
    }

    void hideMenu()
    {
        _startButton.visible = false;
        _exitButton.visible = false;
        _player1.visible = false;
        _player2.visible = false;
        _player1Name.visible = false;
        _player2Name.visible = false;
    }

    void showMenu()
    {
        _startButton.visible = true;
        _exitButton.visible = true;
        _player1.visible = true;
        _player2.visible = true;
        _player1Name.visible = true;
        _player2Name.visible = true;
    }

    void showGameOver()
    {
        if (_hasEnded == true && switchMenu == 1)
        {
            _gameOver = new GameOver();
            AddChild(_gameOver);
        }
    }

    void startGame()
    {
        if (_hasStarted == true && switchMenu == 0)
        {
            _level = new Level();
            AddChild(_level);

            _hud = new HUD(_level);
            AddChild(_hud);

            _hud.Translate(5, 900);
        }
        //uwu
    }

    void exitGame()
    {
        System.Environment.Exit(1);
    }
}
