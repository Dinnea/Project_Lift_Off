using System;									// System contains a lot of default C# libraries 
using System.Drawing;                           // System.Drawing contains a library used for canvas drawing below
using GXPEngine;								// GXPEngine contains the engine

public class MyGame : Game
{
	PlayerGreen player1;
	PlayerRed player2;
	Wall wall;
	Keys key;
	Level level;


	public MyGame() : base(1500, 800, false)		// Create a window that's 800x600 and NOT fullscreen
	{
		/*wall = new Wall();
		AddChild(wall);*/

		level = new Level();
		AddChild(level);

		player1 = new PlayerGreen();
		AddChild(player1);

		player2 = new PlayerRed();
		AddChild(player2);

		/*key = new Keys();
		AddChild(key);*/

	}


	void Update()
	{

	}


	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();					// Create a "MyGame" and start it
	}

}