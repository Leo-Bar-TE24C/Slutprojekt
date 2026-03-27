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

    public int maxHealth;

    public bool stunned;

    public int stunTime;



    public Enemy()
    {
        spritesheet = Raylib.LoadTexture(@"PunchOutGlassJoe.gif");
        dmg = 5;
        hp = 150;
        moveset = ["Right hook", "Viva la france"];
        isAttacking = false;
        animState = 0;
        animIdle = 0;
        cooldown = 60;
        maxHealth = hp;
        stunned = false;
        stunTime = 0;
    }

    public static (Enemy, Player) Attack(Enemy enemy, Player player)
    {
        if (enemy.isAttacking == false)
        {
            enemy.move = Random.Shared.Next(enemy.moveset.Count);
            enemy.isAttacking = true;
        }
        

        if (enemy.moveset[enemy.move] == "Right hook")
        {
            (enemy, player) = RightHook(enemy, player);
        }
        else if (enemy.moveset[enemy.move] == "Viva la france")
        {
            (enemy, player) = VivaLaFrance(enemy, player);
        }
        return (enemy, player);
    }

    public static (Enemy, Player) RightHook(Enemy enemy, Player player)
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
            player = Enemy.DealDMG(enemy,player);
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
        return (enemy, player);
    }

    public static (Enemy, Player) VivaLaFrance(Enemy enemy, Player player)
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
            player = Enemy.DealDMG(enemy,player);
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
        return (enemy, player);
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

    public static Player DealDMG(Enemy enemy, Player player)
    {
        if((player.isDodgeingL || player.isDodgeingR || player.stunned)==false)
        {
            player.hp -= enemy.dmg;
            player.stunTime = 20;
        }
        return player;
    }

    public static Enemy StunCheck(Enemy enemy)
    {
        if (enemy.stunTime!=0)
        {
            enemy.stunTime--;
            enemy.stunned = true;
        }
        else
        {
            enemy.stunned = false;
        }
        return enemy;
    }
}