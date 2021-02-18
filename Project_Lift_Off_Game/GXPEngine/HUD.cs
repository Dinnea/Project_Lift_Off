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
    private Sprite _bckg;

    private Canvas _HUD;

    public HUD( Level level ) : base( 1270, 85 )
    {
        _level = level;

        _bckg = new Sprite("HUD3.png");
        AddChild(_bckg);
        _bckg.SetScaleXY(1f, 0.95f);

        _HUD = new Canvas(1270, 85);
        AddChild(_HUD);

        //fonts
        fonts.AddFontFile("Gingerbread_House.ttf");
        fonts.AddFontFile("hazel_grace.ttf");
        font = new Font(fonts.Families[0], 40);
        numberFont = new Font(fonts.Families[1], 50);
    }

    void Update()
    {
        _HUD.graphics.Clear(Color.Empty);
        _HUD.graphics.DrawString("There is only", font, Brushes.White, 0, 5); //How much time is left?
        _HUD.graphics.DrawString(" " + _level.GetTime() + "  ", numberFont, Brushes.White, 200, 10);
        _HUD.graphics.DrawString("seconds left", font, Brushes.White, 265, 5);
        _HUD.graphics.DrawString(" . . .", numberFont, Brushes.White, 445, 10);
    }
}
