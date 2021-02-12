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

        public GameOver()
        {
            _win1Sound = new Sound("winner.wav", false, false);

            _winner = 0;
            _soundCheck = 0;

            if (Menu.playerID == 1 && _soundCheck == 0)
            {
                _winner = 1;
                _win1Sound.Play();
                _soundCheck = 1;
            }
            else if (Menu.playerID == 2 && _soundCheck == 0)
            {
                _winner = 2;
                _soundCheck = 1;
            }

            _player1 = new Sprite("circle.png");
            AddChild(_player1);
            _player1.x = (game.width / 2);
            _player1.y = (game.height / 2.5f);
            _player1.SetOrigin(_player1.width / 2f, _player1.height / 2f);
            _player1.SetScaleXY(2f, 2f);
            _player1.visible = false;

            _player2 = new Sprite("circle2.png");
            AddChild(_player2);
            _player2.x = (game.width / 2);
            _player2.y = (game.height / 2.5f);
            _player2.SetOrigin(_player2.width / 2f, _player2.height / 2f);
            _player2.SetScaleXY(2, 2f);
            _player2.visible = false;
        }

        void Update()
        {
            if (_winner == 1 && _soundCheck == 1)
            {
                Menu.playerID = 0;
                _soundCheck = 0;
                _winner = 1;
                _player1.visible = true;
            }

            if (_winner == 2 && _soundCheck == 1)
            {
                Menu.playerID = 0;
                _soundCheck = 0;
                _winner = 2;
                _player2.visible = true;
            }

            if (Input.GetKey(Key.ENTER))
            {
                if (_winner == 1)
                {
                    Menu.switchMenu = 2;
                    LateDestroy();
                }
                else if (_winner == 2)
                {
                    Menu.switchMenu = 2;
                    LateDestroy();
                }

            }
        }
    }
}
