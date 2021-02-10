using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;

public class Level : GameObject
{



    int Width = 0;
    int Height = 0;
    const int TileSize = 64;

    int[,] levelData = null;

    public Level()
    {
        BuildLevel();
    }
    //-------------------------------------------
    //                 Add tile types
    //-------------------------------------------

    private void AddTile(int column, int row, int id)
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
        Height = 10;
        Width = 6;

        levelData = new int[,]  
        
                    //only add a single 3 and 4!!!
        {
            {1, 0, 0, 0, 0, 0 },  //1
            {1, 0, 0, 0, 0, 0 },  //2
            {1, 0, 0, 0, 1, 0 },  //3
            {2, 0, 0, 0, 2, 0 },  //4
            {2, 0, 0, 0, 1, 0 },  //5
            {2, 0, 0, 0, 2, 0 },  //6
            {1, 0, 0, 0, 1, 0 },  //7
            {0, 0, 0, 0, 0, 0 },  //8
            {0, 0, 0, 0, 0, 0 },  //9
            {0, 0, 3, 4, 0, 0 }   //10
        };
    }

    private void BuildLevel()
    {
        LoadLevel();

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

