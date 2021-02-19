using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Text;

using GXPEngine;

public class Menu : GameObject
{
    PrivateFontCollection fonts = new PrivateFontCollection();
    public Font font;
    public Font numberFont;

    private Button _startButton;
    private Button _exitButton;

    private Sprite _menu;
    private Sprite _logo;

    Sound menuPress;
    private Sound _menuBack;

    bool _hasStarted;
    bool _hasEnded;

    private GameOver _gameOver;
    private FirstLevel _level1;
    private SecondLevel _level2;
    private ThirdLevel _level3;
    private HUD _hud;
    private Canvas _text;

    //private Menu _menu;

    public static int switchMenu = 0; // Restarts, and resets menu again. (0 = start) (1 = gameover) (2 = reset to menu)
    public static int playerID = 0; // Winner in GameOver.cs
    public static int currentLevel; //Checks which level it is
    public static int finalLevel = 3; //currently final level
    public Menu()
    {
        //fonts
        fonts.AddFontFile("Gingerbread_House.ttf");
        fonts.AddFontFile("hazel_grace.ttf");
        font = new Font(fonts.Families[0], 40);
        numberFont = new Font(fonts.Families[1], 50);

        menuPress = new Sound("menu.wav", false, false);
        _menuBack = new Sound("menuBack.wav", false, false);


        _hasStarted = false;
        _hasEnded = false;

        ////////////////////////// Menu Art //////////////////////////////

        _menu = new Sprite("menu_screen.png");
        AddChild(_menu);

        _logo = new Sprite("logo.png");
        AddChild(_logo);
        _logo.SetOrigin(_logo.width / 2f, _logo.height / 2f);
        //_logo.SetScaleXY(0.5f, 0.5f);
        _logo.x = (game.width) / 2;
        _logo.y = 110;

        ///////////////////////// Buttons ///////////////////////////////

        _startButton = new Button();
        AddChild(_startButton);
        _startButton.x = 356;
        _startButton.y = 880;
        _startButton.SetOrigin(_startButton.width / 2f, _startButton.height / 2f);

        _exitButton = new Button();
        AddChild(_exitButton);
        _exitButton.x = 915;
        _exitButton.y = 880;
        _exitButton.SetOrigin(_exitButton.width / 2f, _exitButton.height / 2f);

        ///////////////////////// Text ///////////////////////////////
 
        _text = new Canvas(1280, 1005);
        AddChild(_text);

        _text.graphics.DrawString("Start", font, Brushes.White, 310, 847);
        _text.graphics.DrawString("Quit", font, Brushes.White, 870, 847);



    }

    void Update()
    {
        switch (switchMenu)
        {
            case 1:
                _hasStarted = false;
                _hasEnded = true;
                switch (currentLevel)
                {
                    case 1:
                        _level1.LateDestroy();
                        break;
                    case 2:
                        _level2.LateDestroy();
                        break;
                    case 3:
                        _level3.LateDestroy();
                        break;
                }
                _hud.LateDestroy();
                showGameOver();
                break;

            case 2:
                showMenu();
                _gameOver.LateDestroy();
                _menuBack.Play();
                _hasEnded = false;
                switchMenu = 0;
                playerID = 0;
                break;
            case 3:
                _hasStarted = true;
                startLevel1();
                if (_hasEnded == true)
                {
                    _gameOver.LateDestroy();
                    _hasEnded = false;
                }
                break;
            case 4:
                _hasStarted = true;
                startLevel2();
                if (_hasEnded == true)
                {
                    _gameOver.LateDestroy();
                    _hasEnded = false;
                }
                break;
            case 5:
                _hasStarted = true;
                startLevel3();
                if (_hasEnded == true)
                {
                    _gameOver.LateDestroy();
                    _hasEnded = false;
                }
                break;

        }

            //-------------------------------------------------
            //              Button press check
            //--------------------------------------------------

            if (Input.GetMouseButtonUp(0))
        {
            if (_startButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                switchMenu = 3;
            }

            if (_exitButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                exitGame();
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            
        }
    }

    void hideMenu()
    {
        _startButton.visible = false;
        _exitButton.visible = false;
        _logo.visible = false;
        _menu.visible = false;
        _text.visible = false;
    }

    void showMenu()
    {
        _startButton.visible = true;
        _exitButton.visible = true;
        _logo.visible = true;
        _menu.visible = true;
        _text.visible = true;
    }

    void showGameOver()
    {
        if (_hasEnded == true && switchMenu == 1)
        { 
            _gameOver = new GameOver();
            AddChild(_gameOver);
        }
    }
//-----------------------------------------------------------------------------------
//                             Start the levels
//-----------------------------------------------------------------------------------
    void startLevel1()
    {
        if (_hasStarted == true)
        {
            hideMenu();
            menuPress.Play();
            switchMenu = 0;

            _level1 = new FirstLevel();
            _hud = new HUD(_level1);
            
            currentLevel = 1;

            AddChild(_hud);
            AddChild(_level1);            

            _level1.Translate(0, 100);
            _hud.Translate(5, 5);
        }
    }

    void startLevel2()
    {
        if (_hasStarted == true)
        {
            hideMenu();
            menuPress.Play();
            switchMenu = 0;

            currentLevel = 2;
            _level2 = new SecondLevel();
            AddChild(_level2);

            _hud = new HUD(_level2);
            AddChild(_hud);

            _level2.Translate(0, 100);
            _hud.Translate(5, 5);
        }
    }
    void startLevel3()
    {
        if (_hasStarted == true)
        {
            hideMenu();
            menuPress.Play();
            switchMenu = 0;

            currentLevel = 3;
            _level3 = new ThirdLevel();
            AddChild(_level3);

            _hud = new HUD(_level3);
            AddChild(_hud);

            _level3.Translate(0, 100);
            _hud.Translate(5, 5);
        }
    }

    void exitGame()
    {
        System.Environment.Exit(1);
    }
}
