using System.Numerics;
using System.Runtime.InteropServices;
using Raylib_cs;
public class Enemy
{

    public int dmg;
    public int hp;
    public List<string> moveset;

    public Texture2D spritesheet;

    public bool isAttacking;

    public int animState;

    public int move;

    public int cooldown;

    public Enemy()
    {
        spritesheet = Raylib.LoadTexture(@"PunchOutGlassJoe.gif");
        dmg = 5;
        hp = 150;
        moveset = ["Right hook", "Viva la france"];
        isAttacking = false;
        animState = 0;
    }

    public static Enemy Attack(Enemy enemy)
    {
        if (enemy.isAttacking == false)
        {
            enemy.move = Random.Shared.Next(enemy.moveset.Count);
            enemy.isAttacking = true;
        }
        

        if (enemy.moveset[enemy.move] == "Right hook")
        {
            enemy = RightHook(enemy);
        }
        else if (enemy.moveset[enemy.move] == "Viva la france")
        {
            enemy = VivaLaFrance(enemy);
        }
        return enemy;
    }

    public static Enemy RightHook(Enemy enemy)
    {
        Vector2 pos = new(450, 600);
        int scale = 5;

        if (enemy.animState <= 20)
        {
            Raylib.DrawTexturePro(enemy.spritesheet, new(71, 770, 35, 89), new(pos, 35 * scale, 89 * scale), new(71 / 2, 770 / 2), 0, Color.White);
        }
        else if (enemy.animState > 20 && enemy.animState <= 40)
        {
            Raylib.DrawTexturePro(enemy.spritesheet, new(135, 770, 35, 89), new(pos, 35 * scale, 89 * scale), new(71 / 2, 770 / 2), 0, Color.White);
        }
        else if (enemy.animState > 40 && enemy.animState <= 60)
        {
            Raylib.DrawTexturePro(enemy.spritesheet, new(202, 766, 39, 93), new(pos, 39 * scale, 93 * scale), new(71 / 2, 770 / 2), 0, Color.White);
        }

        if (enemy.animState < 60)
        {

            enemy.animState++;
            enemy.isAttacking=true;
            
        }
        else if (enemy.animState >= 60)
        {
            enemy.animState = 0;
            enemy.isAttacking=false;
        }
        return enemy;
    }

    public static Enemy VivaLaFrance(Enemy enemy)
    {
        Vector2 pos = new(450, 600);
        int scale = 5;
        

        
        if (enemy.animState <= 20)
        {
            Raylib.DrawTexturePro(enemy.spritesheet, new(71, 656, 40, 100), new(pos, 40 * scale, 100 * scale), new(71 / 2, 770 / 2), 0, Color.White);
        }
        else if (enemy.animState > 20 && enemy.animState <= 40)
        {
            Raylib.DrawTexturePro(enemy.spritesheet, new(130, 656, 40, 100), new(pos, 40 * scale, 100 * scale), new(71 / 2, 770 / 2), 0, Color.White);
        }
        else if (enemy.animState > 40 && enemy.animState <= 60)
        {
            Raylib.DrawTexturePro(enemy.spritesheet, new(190, 656, 39, 100), new(pos, 39 * scale, 100 * scale), new(71 / 2, 770 / 2), 0, Color.White);
        }
        
        if (enemy.animState < 60)
        {

            enemy.animState++;
            enemy.isAttacking=true;
            
        }
        else if (enemy.animState >= 60)
        {
            enemy.animState = 0;
            enemy.isAttacking=false;
        }
        return enemy;
    }

    public static Enemy Idle(Enemy enemy)
    {
        return enemy;
    }
}
