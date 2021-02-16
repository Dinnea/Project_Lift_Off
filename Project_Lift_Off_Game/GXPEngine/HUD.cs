using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using GXPEngine;

public class HUD : Canvas  //Games HUD
{
    private Level _level;

    public HUD( Level level ) : base( 1270, 200 )
    {
        _level = level;
    }

    void Update()
    {
        graphics.Clear( Color.White );
        graphics.DrawString( "Time: " + _level.GetTime(), SystemFonts.DefaultFont, Brushes.Black, 0, 0 ); //How much time is left?
    }
}
