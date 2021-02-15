﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

public class Level : GameObject
{
    private int _timeLoaded;
    private int _time;
    public int timeLeft;
    public int maxTime = 300;

    private int _timeLeftToPower = 5;
    private int _powerTimed;
    private int _h;
    private int _w;
    private int _powerUpCount = 0;
    private Random _rnd = new Random();
    private List<PowerUp> _powerUps = new List<PowerUp>();

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
        timeLeft = (maxTime - _time);

        if (timeLeft <= 0)
        {
            end();
        }

        //countdown to spawn power
        _timeLeftToPower = ((Time.time - _powerTimed)/1000);

        if (_timeLeftToPower == 5)
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
            newTile.x = column * TileSize;
            newTile.y = row * TileSize;
        }
    }

    //--------------------------------------------------
    //              Level layout in ID numbers
    //---------------------------------------------------

    private void LoadLevel()
    {

        Height = 16;
        Width = 22;

        levelData = new int[,]  
        
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


    private void BuildLevel()
    {
        LoadLevel();
        _timeLoaded = (Time.time / 1000);  //makes sure that the timer wont start counting down before the level is loaded
        _powerTimed = _timeLoaded;

        for (int row = 0; row < Height; row++)
        {

            for (int column = 0; column < Width; column++)
            {
                int id = levelData[row, column];
                AddTile(column -1 , row -1 , id);
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
        _powerTimed = Time.time;
        _powerUpCount++;
   

    }

   /* private void spawnPower(int _w, int _h)//, Sprite newTile)
    {
        
            //if ((powerUp.x == newTile.x) && (powerUp.y == newTile.y) && newTile is null)
            //{
                AddChild(powerUps);
                powerUps.x = _w;
                powerUps.y = _h;
            //}
       
    }*/

   //---------------------------------------------------------
   //            End the game if time reaches 0 (red wins)
   //---------------------------------------------------------
   private void end()
    {
        Menu.switchMenu = 1;
        Menu.playerID = 2;
    }
}