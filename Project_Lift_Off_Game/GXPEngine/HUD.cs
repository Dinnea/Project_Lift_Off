using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using GXPEngine;

public class HUD : Canvas  //Games HUD
{
    private Level _level1;
    private Level _level2;

    public HUD( Level level ) : base( 1270, 85 )
    {
        switch (Menu.currentLevel)
        {
            //_level = level;
            case 1:
                _level1 = level;
                break;
            case 2:
                _level2 = level;
                break;
        }
       
    }

    void Update()
    {
        switch (Menu.currentLevel)
        {
            case 1:
                graphics.Clear(Color.White);
                graphics.DrawString("Time: " + _level1.GetTime(), SystemFonts.DefaultFont, Brushes.Black, 0, 0); //How much time is left?
                break;
            case 2:
                graphics.Clear(Color.White);
                graphics.DrawString("Time: " + _level2.GetTime(), SystemFonts.DefaultFont, Brushes.Black, 0, 0); //How much time is left?
                break;
        }
    }
}
