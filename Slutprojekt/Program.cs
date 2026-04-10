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
    // Raylib.DrawTexturePro(enemy.spritesheet, new(48, 880, 56, 96), new(enemy.pos, enemy.scale * 56, enemy.scale * 96), new(71 / 2, 770 / 2), 0, Color.White);
    // Raylib.DrawTexturePro(enemy.spritesheet, new(190, 528, 39, 110), new(enemy.pos, 39 * enemy.scale, 110 * enemy.scale), new(71 / 2, 770 / 2), 0, Color.White);


    // Raylib.DrawTexturePro(player.spritesheet, new(407 - 40, 80, -25, 76), new(player.pos, 25 * player.scale, 76 * player.scale), new(24 / 2, 76 / 2), 0, Color.White);


    round = Toolbox.Combat(enemyList[round], litleMac, round).Item3;

    // Raylib.DrawTexturePro(player.spritesheet,  new(88+38, 80+160, 28, 76), new(player.pos, 28 * player.scale, 76 * player.scale), new(28 / 2, 76 / 2), 0, Color.White);

    
    // Toolbox.DisplayMousePos();
    // Toolbox.DisplayHP(litleMac,glassJoe);

    Raylib.EndDrawing();
}