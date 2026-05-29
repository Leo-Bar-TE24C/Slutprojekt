using System.ComponentModel;
using System.ComponentModel.Design;
using System.Runtime.Intrinsics.X86;
using Raylib_cs;

Raylib.InitWindow(1000, 1000, "Punch Out");
Raylib.SetTargetFPS(60);

Texture2D ring = Raylib.LoadTexture(@"PunchOutRing.png");


Enemy glassJoe = new Enemy();
Player litleMac = new Player();
Enemy vonKaizer = new VonKaizer();
int round = 0;

// variables for menu

Rectangle start = new(400, 500, 220, 50);
bool menu = true;

Rectangle controls = new(400, 600, 220, 50);
Rectangle back = new(400, 800, 220, 50);
bool showControls = false;

Texture2D keybinds = Raylib.LoadTexture(@"punchOutKeys.png");
// enemies for different rounds
List<Enemy> enemyList = [glassJoe, vonKaizer];



while (Raylib.WindowShouldClose() == false)
{

    // Toolbox.Combat();


    Raylib.BeginDrawing();

    if (showControls == true)
    {
        Raylib.ClearBackground(Color.Blue);
        Raylib.DrawTextureEx(keybinds, new(150,300), 0, 3,Color.White);
        Raylib.DrawText("Dodge",60,450,35,Color.White);
        Raylib.DrawText("Dodge",460,450,35,Color.White);
        Raylib.DrawText("Aim up",260,300,35,Color.White);
        Raylib.DrawText("Block",260,550,35,Color.White);
        Raylib.DrawText("Punch left",600,340,35,Color.White);
        Raylib.DrawText("Punch right",630,550,35,Color.White);
        showControls = Toolbox.Button(showControls, back, "Back", 450, 800, 50);
    }
    else if (menu == true)
    {
        Raylib.ClearBackground(Color.Blue);
        Raylib.DrawTexturePro(glassJoe.spritesheet, new(128, 0, 56, 56), new(500, 300, 280, 280), new(280 / 2, 280 / 2), 0, Color.White);
        menu = Toolbox.Button(menu, start, "Start", 450, 500, 50);
        showControls = Toolbox.Button(showControls, controls, "Controls", 410, 600, 50);

    }
    else if (round < enemyList.Count)
    {
        Raylib.DrawTextureEx(ring, new(0, 0), 0, 4.45f, Color.White);
        round = Toolbox.Combat(enemyList[round], litleMac, round).Item3;
    }
    else
    {
        Raylib.ClearBackground(Color.Blue);
        Raylib.DrawTexturePro(glassJoe.spritesheet, new(128, 0, 56, 56), new(500, 500, 280, 280), new(280 / 2, 280 / 2), 0, Color.White);
        Raylib.DrawText("A WINNER IS YOU!", 30, 300, 100, Color.Yellow);
    }

    // Toolbox.DisplayMousePos();
    // Toolbox.Display(menu);

    Raylib.EndDrawing();
}