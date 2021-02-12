using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

public class Level : GameObject
{
    private int _timeLoaded;
    private int _time;
    public int maxTime = 300;
    int Width = 0;
    int Height = 0;
    const int TileSize = 64;

    int[,] levelData = null;

    public Level()
    {
        BuildLevel();

        startMusic();

    }

    void startMusic()
    {
        //_music = new Sound("music.ogg", true, true);

    }

    void Update()
    {
        _time = ((Time.time) / 1000) - _timeLoaded;
    }


    public int GetTime()    // source of time for timer in the HUD
    {
        return (maxTime - _time);
    }
    //---------------------------------------------
    //                 Add tile types
    //---------------------------------------------

    private void AddTile(int column, int row, int id)
    {
        _time = 0;
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
        }

        if (newTile != null)
        {
            AddChild(newTile);
            newTile.x = column * TileSize;
            newTile.y = row * TileSize;
        }
    }

    //--------------------------------------------------
    //              Set layout of the game
    //---------------------------------------------------

    private void LoadLevel()
    {

        Height = 14;
        Width = 20;

        levelData = new int[,]  
        
                    //only add a single 3 and 4!!!
        {
                                                                     //6
            {0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 2, 0, 0, 1, 4, 0, 0, 0, 0, 0 },  //1
            {0, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 0 },  //2
            {2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },  //3
            {0, 1, 0, 5, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0 },  //4
            {0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 0, 0 },  //5
            {1, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1 },  //6
            {0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 5, 0, 1 },  //7
            {1, 0, 0, 0, 0, 1, 1, 0, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1 },  //8
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1 },  //9
            {0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1 },  //10
            {1, 1, 1, 1, 1, 1, 1, 2, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },  //11
            {1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },  //12
            {1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },  //13
            {1, 1, 1, 1, 1, 1, 1, 1, 3, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },  //14
        };
    }

    private void BuildLevel()
    {
        LoadLevel();
        _timeLoaded = (Time.time / 1000);  //makes sure that the timer wont start counting down before the level is loaded

        for (int row = 0; row < Height; row++)
        {

            for (int column = 0; column < Width; column++)
            {
                int id = levelData[row, column];
                AddTile(column, row, id);
            }

        }
    }
}