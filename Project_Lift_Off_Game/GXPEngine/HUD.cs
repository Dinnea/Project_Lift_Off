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
    private Font _font;
    private Font _numberFont;

    private Level _level;

    public HUD( Level level ) : base( 1270, 85 )
    {
        _level = level;

        fonts.AddFontFile("Gingerbread_House.ttf");
        fonts.AddFontFile("hazel_grace.ttf");
        _font = new Font(fonts.Families[0], 40);
        _numberFont = new Font(fonts.Families[1], 50);

    }

    void Update()
    {
        graphics.Clear(Color.White);
        graphics.DrawString("There is only", _font, Brushes.Black, 0, 5); //How much time is left?
        graphics.DrawString(" " + _level.GetTime() + "  ", _numberFont, Brushes.Black, 200, 10);
        graphics.DrawString("seconds left", _font, Brushes.Black, 265, 5);
        graphics.DrawString(" . . .", _numberFont, Brushes.Black, 445, 10);
    }
}
