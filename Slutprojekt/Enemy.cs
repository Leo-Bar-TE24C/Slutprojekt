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

    public int timeSince;

    public int animIdle;

    public Enemy()
    {
        spritesheet = Raylib.LoadTexture(@"PunchOutGlassJoe.gif");
        dmg = 5;
        hp = 150;
        moveset = ["Right hook", "Viva la france"];
        isAttacking = false;
        animState = 0;
        animIdle = 0;
        cooldown = 120;
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
            enemy.timeSince=0;
            enemy.cooldown = Random.Shared.Next(120,721);
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
            enemy.timeSince=0;
            enemy.cooldown = Random.Shared.Next(120,721);
        }
        return enemy;
    }

    public static Enemy Idle(Enemy enemy)
    {

        Vector2 pos = new(450, 600);
        int scale = 5;

        if (enemy.animIdle <= 20)
        {
            Raylib.DrawTexturePro(enemy.spritesheet, new(71, 528, 40, 110), new(pos, 40 * scale, 110 * scale), new(71 / 2, 770 / 2), 0, Color.White);
        }
        else if (enemy.animIdle > 20 && enemy.animIdle <= 40)
        {
            Raylib.DrawTexturePro(enemy.spritesheet, new(130, 528, 40, 110), new(pos, 40 * scale, 110 * scale), new(71 / 2, 770 / 2), 0, Color.White);
        }
        else if (enemy.animIdle > 40 && enemy.animIdle <= 60)
        {
            Raylib.DrawTexturePro(enemy.spritesheet, new(190, 528, 39, 110), new(pos, 39 * scale, 110 * scale), new(71 / 2, 770 / 2), 0, Color.White);
        }

        if (enemy.animIdle>=60)
        {
            enemy.animIdle = 0;
        }
        else
        {
            enemy.animIdle++;
        }

        return enemy;
    }
}
