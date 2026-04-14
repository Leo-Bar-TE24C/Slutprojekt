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

    public Vector2 pos;

    public int scale;

    public Enemy()
    {
        spritesheet = Raylib.LoadTexture(@"PunchOutGlassJoe.gif");
        dmg = 20;
        hp = 150;
        moveset = ["Right hook", "Viva la france"];
        isAttacking = false;
        animState = 0;
        animIdle = 0;
        cooldown = 40;
        maxHealth = hp;
        stunned = false;
        stunTime = 0;
        pos = new(450, 600);
        scale = 5;
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



        if (enemy.animState <= 20)
        {
            Raylib.DrawTexturePro(enemy.spritesheet, new(71, 770, 35, 89), new(enemy.pos, 35 * enemy.scale, 89 * enemy.scale), new(71 / 2, 770 / 2), 0, Color.White);
        }
        else if (enemy.animState > 20 && enemy.animState <= 40)
        {
            Raylib.DrawTexturePro(enemy.spritesheet, new(135, 770, 35, 89), new(enemy.pos, 35 * enemy.scale, 89 * enemy.scale), new(71 / 2, 770 / 2), 0, Color.White);
            player = Enemy.DealDMG(enemy, player);
        }
        else if (enemy.animState > 40 && enemy.animState <= 60)
        {
            Raylib.DrawTexturePro(enemy.spritesheet, new(202, 766, 39, 93), new(enemy.pos, 39 * enemy.scale, 93 * enemy.scale), new(71 / 2, 770 / 2), 0, Color.White);
        }

        if (enemy.animState < 60)
        {

            enemy.animState++;
            enemy.isAttacking = true;

        }
        else if (enemy.animState >= 60)
        {
            enemy.animState = 0;
            enemy.isAttacking = false;
            enemy.timeSince = 0;
            enemy.cooldown = Random.Shared.Next(120, 721);
        }
        return (enemy, player);
    }

    public static (Enemy, Player) VivaLaFrance(Enemy enemy, Player player)
    {





        if (enemy.animState <= 20)
        {
            Raylib.DrawTexturePro(enemy.spritesheet, new(71, 656, 40, 100), new(enemy.pos, 40 * enemy.scale, 100 * enemy.scale), new(71 / 2, 770 / 2), 0, Color.White);
        }
        else if (enemy.animState > 20 && enemy.animState <= 40)
        {
            Raylib.DrawTexturePro(enemy.spritesheet, new(130, 656, 40, 100), new(enemy.pos, 40 * enemy.scale, 100 * enemy.scale), new(71 / 2, 770 / 2), 0, Color.White);
        }
        else if (enemy.animState > 40 && enemy.animState <= 60)
        {
            Raylib.DrawTexturePro(enemy.spritesheet, new(190, 656, 39, 100), new(enemy.pos, 39 * enemy.scale, 100 * enemy.scale), new(71 / 2, 770 / 2), 0, Color.White);
            player = Enemy.DealDMG(enemy, player);
        }

        if (enemy.animState < 60)
        {

            enemy.animState++;
            enemy.isAttacking = true;

        }
        else if (enemy.animState >= 60)
        {
            enemy.animState = 0;
            enemy.isAttacking = false;
            enemy.timeSince = 0;
            enemy.cooldown = Random.Shared.Next(120, 721);
        }
        return (enemy, player);
    }

    public static Enemy Idle(Enemy enemy)
    {




        if (enemy.animIdle <= 20)
        {
            Raylib.DrawTexturePro(enemy.spritesheet, new(71, 528, 40, 110), new(enemy.pos, 40 * enemy.scale, 110 * enemy.scale), new(71 / 2, 770 / 2), 0, Color.White);
        }
        else if (enemy.animIdle > 20 && enemy.animIdle <= 40)
        {
            Raylib.DrawTexturePro(enemy.spritesheet, new(130, 528, 40, 110), new(enemy.pos, 40 * enemy.scale, 110 * enemy.scale), new(71 / 2, 770 / 2), 0, Color.White);
        }
        else if (enemy.animIdle > 40 && enemy.animIdle <= 60)
        {
            Raylib.DrawTexturePro(enemy.spritesheet, new(190, 528, 39, 110), new(enemy.pos, 39 * enemy.scale, 110 * enemy.scale), new(71 / 2, 770 / 2), 0, Color.White);
        }

        if (enemy.animIdle >= 60)
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
        if ((player.isDodgeingL || player.isDodgeingR || player.stunned) == false)
        {
            if (player.isBlocking == true )
            {
                player.hp -= enemy.dmg / 3;
                player.stunTime = 20;
            }
            else
            {
                player.hp -= enemy.dmg;
                player.stunTime = 20;
            }
        }
        return player;
    }

    public static Enemy StunCheck(Enemy enemy)
    {
        if (enemy.stunTime != 0)
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

    public static void Hurt(Enemy enemy, Player player)
    {
        if (player.attack == 1)
        {
            Raylib.DrawTexturePro(enemy.spritesheet, new(48, 880, -56, 96), new(enemy.pos, enemy.scale * 56, enemy.scale * 96), new(71 / 2, 770 / 2), 0, Color.White);
        }
        else if (player.attack == 3)
        {
            Raylib.DrawTexturePro(enemy.spritesheet, new(48, 880, 56, 96), new(enemy.pos, enemy.scale * 56, enemy.scale * 96), new(71 / 2, 770 / 2), 0, Color.White);
        }
        else
        {
            Raylib.DrawTexturePro(enemy.spritesheet, new(48 + 130, 880, 56, 96), new(enemy.pos, enemy.scale * 56, enemy.scale * 96), new(71 / 2, 770 / 2), 0, Color.White);
        }
    }
}