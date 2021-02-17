﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GXPEngine;


//-------------------------------------------------------------------
//                         Level1
//-------------------------------------------------------------------
public class FirstLevel : Level
{
    public FirstLevel()
    {
        
    }
    void Update()
    {
        LevelRuntime();
    }

    //--------------------------------------------------
    //                      Level layout
    //---------------------------------------------------
    //
    //only change between levels is this section.
    public override void LoadLevel()
    {
        height = 16;
        width = 22;

        levelData = new int[,]  
        
                    //only add a single 3 and 4!!!
                    //Must add a single 6!!!
                    //never remove 7s!
        {
            {7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7 },  //border                                                    
            {7, 4, 0, 0, 0, 0, 0, 0, 1, 1, 0, 2, 0, 0, 1, 0, 0, 0, 0, 0, 6, 7 },  //1
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
}
//-------------------------------------------------------------------
//                         Level2
//-------------------------------------------------------------------
public class SecondLevel : Level
{
    public SecondLevel()
    {

    }
    void Update()
    {
        LevelRuntime();
    }

    //--------------------------------------------------
    //                      Level layout
    //---------------------------------------------------
    //
    //only change between levels is this section.
    public override void LoadLevel()
    {
        height = 16;
        width = 22;

        levelData = new int[,]  
        
                    //only add a single 3 and 4!!!
                    //Must add a single 6!!!
                    //never remove 7s!
        {
            {7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7 },  //border                                                    
            {7, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 2, 0, 0, 1, 4, 0, 0, 0, 0, 6, 7 },  //1
            {7, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 2, 0, 0, 1, 4, 0, 0, 0, 0, 6, 7 },  //2
            {7, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 2, 0, 0, 1, 4, 0, 0, 0, 0, 6, 7 },  //3
            {7, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 2, 0, 0, 1, 4, 0, 0, 0, 0, 6, 7 },  //4
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
}
