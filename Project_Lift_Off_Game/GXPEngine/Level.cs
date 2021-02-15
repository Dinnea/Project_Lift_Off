using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

public class Level : GameObject
{
    //Timer related variables
    private int _timeLoaded;
    private int _time;
    public int timeLeft;
    public int maxTime = 180;

    //Power up spawn variables
    private int _timeLeftToPower;
    private int _powerTimed;
    private int _h;
    private int _w;
    private int _powerUpCount = 0;
    private Random _rnd = new Random();
    private List<PowerUp> _powerUps = new List<PowerUp>();

    //Tile related variables
    private int _width = 0;
    private int _height = 0;
    private const int _tileSize = 64;
    int[,] _levelData = null;


    public Level()
    {
        buildLevel();
        startMusic();
    }

    void startMusic()
    {
        //_music = new Sound("music.ogg", true, true);

    }

    void Update()
    {
        _time = ((Time.time) / 1000) - _timeLoaded;
        timeLeft = (maxTime - _time); //counts down the time left till the level is over

        if (timeLeft <= 0)
        {
            end();
        }

        _timeLeftToPower = ((Time.time - _powerTimed)/1000); //countdown to spawn power

        if (_timeLeftToPower == 10)
        {
            _w = _rnd.Next(1, 20) * 64;
            _h = _rnd.Next(1, 14) * 64;
            spawnPower(_w, _h, _powerUpCount);
        }
    }


    public int GetTime()    // source of time for timer in the HUD
    {
        return (timeLeft);
    }
    //---------------------------------------------
    //                 Tile type "dictionary"
    //---------------------------------------------

    private void addTile(int column, int row, int id)
    {
        Sprite newTile = null;
        switch (id)
        {
            case 1:
                newTile = new Wall();
                break;
            case 2:
                newTile = new Keys();
                break;
            case 3:
                newTile = new PlayerGreen();
                break;
            case 4:
                newTile = new PlayerRed();
                break;
            case 5:
                newTile = new PowerUp();
                break;
            case 6:
                newTile = new Exit();
                break;
            case 7:
                newTile = new Border();
                break;
        }

        if (newTile != null)
        {
            AddChild(newTile);
            newTile.x = column * _tileSize;
            newTile.y = row * _tileSize;
        }
    }

    //--------------------------------------------------
    //              Level layout in ID numbers
    //---------------------------------------------------

    private void loadLevel()
    {

        _height = 16;
        _width = 22;

        _levelData = new int[,]  
        
                    //only add a single 3 and 4!!!
                    //Must add a single 6!!!
                    //never remove 7s!
        {
            {7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7 },  //border                                                    
            {7, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 2, 0, 0, 1, 4, 0, 0, 0, 0, 6, 7 },  //1
            {7, 0, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 7 },  //2
            {7, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 7 },  //3
            {7, 0, 1, 0, 5, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 7 },  //4
            {7, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0, 7 },  //5
            {7, 1, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 7 },  //6
            {7, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 5, 0, 1, 7 },  //7
            {7, 1, 0, 0, 0, 0, 1, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 7 },  //8
            {7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 7 },  //9
            {7, 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1, 7 },  //10
            {7, 1, 1, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7 },  //11
            {7, 5, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 7 },  //12
            {7, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 1, 0, 0, 1, 2, 0, 7 },  //13
            {7, 1, 1, 0, 1, 3, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 7 },  //14
            {7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7 },  // border
        };
    }


    //-----------------------------------------------------------------------------------
    //              Level builder - interprets the array to create the correct tiles
    //-----------------------------------------------------------------------------------


    private void buildLevel()
    {
        loadLevel();
        _timeLoaded = (Time.time / 1000);  //makes sure that the timer wont start counting down before the level is loaded
        _powerTimed = (Time.time);  //when did last power up appear

        for (int row = 0; row < _height; row++) //assign X coordinates
        {
            for (int column = 0; column < _width; column++) //assign Y coordinates
            {
                int id = _levelData[row, column];
                addTile(column -1 , row -1 , id);
            }

        }
    }
    //-------------------------------------------------------
    //                  New power spawn
    //-------------------------------------------------------

    private void spawnPower(int w, int h, int i)
    {
        _powerUps.Add(new PowerUp { x = w, y = h } );
        AddChild(_powerUps[i]);
        _powerTimed = Time.time; //when did the lasy
        _powerUpCount++; //how many powers have spawned?
    }
   //---------------------------------------------------------
   //            End the game if time reaches 0 (red wins)
   //---------------------------------------------------------
   private void end()
    {
        Menu.switchMenu = 1;
        Menu.playerID = 2; //if the level is over, the red player wins
    }
}