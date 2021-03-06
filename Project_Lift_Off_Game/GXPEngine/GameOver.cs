﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Text;
using GXPEngine;

public class GameOver : GameObject
{
    Sprite _player1;
    Sprite _player2;

    Sound _win1Sound;
    Sound _win2Sound;
    Sound _press;

    int _winner;
    int _soundCheck;

    Button _menuButton;
    Button _restartButton;
    Button _exitButton;
    Button _nextLevelButton;

    PrivateFontCollection fonts = new PrivateFontCollection();
    public Font font;
    public Font numberFont;

    private Canvas _text;

    public GameOver()
    {

        //fonts
        fonts.AddFontFile("Gingerbread_House.ttf");
        fonts.AddFontFile("hazel_grace.ttf");
        font = new Font(fonts.Families[0], 30);
        numberFont = new Font(fonts.Families[1], 50);

        _win1Sound = new Sound("winner.wav", false, false);
        _win2Sound = new Sound("Queen_laugh.wav", false, false);
        _press = new Sound("menu.wav");

        _winner = 0;
        _soundCheck = 0;

        //---------------------------------------------------------
        //                 Display players
        //----------------------------------------------------------

        if (Menu.playerID == 1 && _soundCheck == 0)  // If green player wins
        {
            _winner = 1;
            _win1Sound.Play();
            _soundCheck = 1;
        }
        else if (Menu.playerID == 2 && _soundCheck == 0) // If red player wins
        {
            _winner = 2;
            _win2Sound.Play();
            _soundCheck = 1;
        }

        //Player green big sprite
        _player1 = new Sprite("fluff_wins.png");
        AddChild(_player1);
        //_player1.SetScaleXY(1f, 0.95714285714f);
        _player1.visible = false;

        //Player red big sprite
        _player2 = new Sprite("queen_wins.png");
        AddChild(_player2);
        _player2.SetScaleXY(1f, 0.95714285714f);
        _player2.visible = false;

        //-------------------------------------------------
        //                    Buttons
        //-------------------------------------------------
        if (Menu.currentLevel != Menu.finalLevel)
        {
            _nextLevelButton = new Button();
            AddChild(_nextLevelButton);
            _nextLevelButton.SetScaleXY(0.5f, 0.60f);
            _nextLevelButton.x = (game.width / 2) - 480;
            _nextLevelButton.y = 253;
            _nextLevelButton.SetOrigin(_nextLevelButton.width / 2f, _nextLevelButton.height / 2f);
        }

        _restartButton = new Button();
        AddChild(_restartButton);
        _restartButton.SetScaleXY(0.5f, 0.60f);
        _restartButton.x = (game.width / 2) - 240;
        _restartButton.y = 253;
        _restartButton.SetOrigin(_restartButton.width / 2f, _restartButton.height / 2f);

        _menuButton = new Button();
        AddChild(_menuButton);
        _menuButton.SetScaleXY(0.5f, 0.60f);
        _menuButton.x = (game.width / 2);
        _menuButton.y = 253;
        _menuButton.SetOrigin(_menuButton.width / 2f, _menuButton.height / 2f);

        _exitButton = new Button();
        AddChild(_exitButton);
        _exitButton.SetScaleXY(0.5f, 0.60f);
        _exitButton.x = (game.width / 2) + 240;
        _exitButton.y = 253;
        _exitButton.SetOrigin(_exitButton.width / 2f, _exitButton.height / 2f);

        //TEXT
        _text = new Canvas(1280, 1005, false);
        AddChild(_text);

        if (Menu.currentLevel != Menu.finalLevel)
        {
            _text.graphics.DrawString("Next Level", font, Brushes.White, 131, 243);
        }
        _text.graphics.DrawString("Restart", font, Brushes.White, 390, 243);
        _text.graphics.DrawString("Menu", font, Brushes.White, 640, 243);
        _text.graphics.DrawString("Quit", font, Brushes.White, 882, 243);
        
    }

    void Update()
    {
        //---------------------------------------
        //       Check which player won
        //---------------------------------------

        if (_winner == 1 && _soundCheck == 1) //green
        {
            Menu.playerID = 0;
            _soundCheck = 0;
            _winner = 1;
            _player1.visible = true;
        }

        if (_winner == 2 && _soundCheck == 1) //red
        {
            Menu.playerID = 0;
            _soundCheck = 0;
            _winner = 2;
            _player2.visible = true;
        }

        //------------------------------------
        //        Button function
        //------------------------------------

        if (Input.GetMouseButtonUp(0))
        {
            if (Menu.currentLevel != Menu.finalLevel)
            {
                //Next level button
                if (_nextLevelButton.HitTestPoint(Input.mouseX, Input.mouseY))
                {
                    _nextLevelButton.LateDestroy();
                    _restartButton.LateDestroy();
                    _menuButton.LateDestroy();
                    _exitButton.LateDestroy();

                    Menu.switchMenu = 3 + Menu.currentLevel;
                    LateDestroy();
                }
            }

            //Restart button
            if (_restartButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                _nextLevelButton.LateDestroy();
                _restartButton.LateDestroy();
                _menuButton.LateDestroy();
                _exitButton.LateDestroy();

                Menu.switchMenu = 2 + Menu.currentLevel;
                LateDestroy();
            }


            // Menu button

            if (_menuButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                if (Menu.currentLevel != Menu.finalLevel)
                {
                    _nextLevelButton.LateDestroy();
                }

                _restartButton.LateDestroy();
                _menuButton.LateDestroy();
                _exitButton.LateDestroy();

                Menu.switchMenu = 2;
                LateDestroy();
            }

            // Exit button

            if (_exitButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                _press.Play();
                System.Environment.Exit(1);
            }
        }
    }
}

