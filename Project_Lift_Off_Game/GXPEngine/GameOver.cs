using System;
namespace GXPEngine
{
    public class GameOver : GameObject
    {
        Sprite _player1;
        Sprite _player2;

        Sound _win1Sound;
        Sound _win2Sound;
        Sound _winnerSound;

        int _winner;
        int _soundCheck;

        Button _menuButton;
        Button _restartButton;
        Button _exitButton;

        public GameOver()
        {
            _win1Sound = new Sound("winner.wav", false, false);

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
                _soundCheck = 1;
            }

            //Player green big sprite
            _player1 = new Sprite("circle.png");
            AddChild(_player1);
            _player1.x = (game.width / 2);
            _player1.y = (game.height / 2.5f);
            _player1.SetOrigin(_player1.width / 2f, _player1.height / 2f);
            _player1.SetScaleXY(5f, 5f);
            _player1.visible = false;

            //Player red big sprite
            _player2 = new Sprite("circle2.png");
            AddChild(_player2);
            _player2.x = (game.width / 2);
            _player2.y = (game.height / 2.5f);
            _player2.SetOrigin(_player2.width / 2f, _player2.height / 2f);
            _player2.SetScaleXY(5f, 5f);
            _player2.visible = false;

            //-------------------------------------------------
            //                    Buttons
            //-------------------------------------------------

            _restartButton = new Button();
            AddChild(_restartButton);
            _restartButton.x = ((game.width / 2) - 100);
            _restartButton.y = 700;
            _restartButton.SetOrigin(_restartButton.width / 2f, _restartButton.height / 2f);

            _menuButton = new Button();
            AddChild(_menuButton);
            _menuButton.x = (game.width / 2);
            _menuButton.y = 700;
            _menuButton.SetOrigin(_menuButton.width / 2f, _menuButton.height / 2f);

            _exitButton = new Button();
            AddChild(_exitButton);
            _exitButton.x = ((game.width / 2) + 100);
            _exitButton.y = 700;
            _exitButton.SetOrigin(_exitButton.width / 2f, _exitButton.height / 2f);
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
                //Restart button
                if (_restartButton.HitTestPoint(Input.mouseX, Input.mouseY))
                {
                    _restartButton.LateDestroy();
                    _menuButton.LateDestroy();
                    _exitButton.LateDestroy();

                    Menu.switchMenu = 3;
                    LateDestroy();
                }
                

                // Menu button

                if (_menuButton.HitTestPoint(Input.mouseX, Input.mouseY))
                {
                    _restartButton.LateDestroy();
                    _menuButton.LateDestroy();
                    _exitButton.LateDestroy();

                    Menu.switchMenu = 2;
                    LateDestroy();
                }

                // Exit button

                if (_exitButton.HitTestPoint(Input.mouseX, Input.mouseY))
                {
                    System.Environment.Exit(1);
                }
            }
        }                
    }
}
