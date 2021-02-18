using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Text;

using GXPEngine;

public class HUD : Canvas  //Games HUD
{
    PrivateFontCollection fonts = new PrivateFontCollection();
    public Font font;
    public Font numberFont;

    private Level _level;

    public HUD( Level level ) : base( 1270, 85 )
    {
        _level = level;

        //fonts
        fonts.AddFontFile("Gingerbread_House.ttf");
        fonts.AddFontFile("hazel_grace.ttf");
        font = new Font(fonts.Families[0], 40);
        numberFont = new Font(fonts.Families[1], 50);
    }

    void Update()
    {
        graphics.Clear(Color.Empty);
        graphics.DrawString("There is only", font, Brushes.White, 0, 5); //How much time is left?
        graphics.DrawString(" " + _level.GetTime() + "  ", numberFont, Brushes.White, 200, 10);
        graphics.DrawString("seconds left", font, Brushes.White, 265, 5);
        graphics.DrawString(" . . .", numberFont, Brushes.White, 445, 10);
    }
}
