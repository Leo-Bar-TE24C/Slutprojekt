using System.Runtime.Intrinsics.X86;
using Raylib_cs;

Raylib.InitWindow(1000,1000, "Punch Out");
Raylib.SetTargetFPS(60);

Texture2D ring = Raylib.LoadTexture(@"PunchOutRing.png");

Enemy glassJoe = new Enemy();
Player litleMac = new Player();
Enemy vonKaizer = new VonKaizer();
int round = 0;

// enemies for different rounds
List<Enemy> enemyList = [glassJoe, vonKaizer];



while(Raylib.WindowShouldClose() == false)
{

    // Toolbox.Combat();
    

    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.Gray);

    Raylib.DrawTextureEx(ring,new(0,0),0,4.45f,Color.White);

    // Player.Idle(litleMac.spritesheet);
    // glassJoe.animState=Enemy.RightHook(glassJoe.spritesheet, glassJoe.animState);
    // Enemy.Idle(glassJoe);
    // Player.HitRight(litleMac);
    // Player.HighHitLeft(litleMac);
    
    // Raylib.DrawTexturePro(player.spritesheet, new(407 - 40, 80, -25, 76), new(player.pos, 25 * player.scale, 76 * player.scale), new(24 / 2, 76 / 2), 0, Color.White);


    Toolbox.Combat(enemyList[round], litleMac);

    (round, litleMac)= Toolbox.Win(round, litleMac);
    // Toolbox.DisplayMousePos();
    // Toolbox.DisplayHP(litleMac,glassJoe);

    Raylib.EndDrawing();
}