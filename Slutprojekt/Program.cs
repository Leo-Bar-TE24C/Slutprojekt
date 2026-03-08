using Raylib_cs;

Raylib.InitWindow(1000,1000, "Punch Out");
Raylib.SetTargetFPS(60);

Texture2D ring = Raylib.LoadTexture(@"PunchOutRing.png");

Enemy glassJoe = new Enemy();
Player litleMac = new Player();

List<Enemy> enemyList = [glassJoe, ];

while(Raylib.WindowShouldClose() == false)
{

    // Toolbox.Combat();
    

    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.Gray);

    Raylib.DrawTextureEx(ring,new(0,0),0,4.45f,Color.White);

    Player.Idle(litleMac.spritesheet);

    Toolbox.Combat(glassJoe, litleMac);

    Raylib.EndDrawing();
}