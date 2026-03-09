using System.Numerics;
using Raylib_cs;
public class Player
{
    public int hp;
    public int lowDmg;
    public int highDmg;
    public bool isDodgeing;
    public Texture2D spritesheet;
    public bool stunned;
    public int animState;
    public bool isAttacking;
    public int animIdle;
    public int idleSide;

    public Player()
    {
        spritesheet = Raylib.LoadTexture(@"LittleMac.png");
        isDodgeing = false;
        lowDmg = 1;
        highDmg = 3;
        hp = 100;
        stunned = false;
        animState = 0;
        isAttacking = false;
        animIdle = 0;
        idleSide = 0;
    }

    public static Player Idle(Player player)
    {
        Vector2 pos = new(450, 500);
        int scale = 5;

        if (player.idleSide >= 20 && player.idleSide <= 60)
        {
            pos.X += 10;
        }
        else if (player.idleSide >= 100 && player.idleSide <= 1400)
        {
            pos.X -= 10;
        }

        if (player.idleSide >= 120)
        {
            player.idleSide = 0;
        }
        else
        {
            player.idleSide++;
        }

        if (player.animIdle <= 20)
        {
            Raylib.DrawTexturePro(player.spritesheet, new(88, 80, 24, 76), new(pos, 24 * scale, 76 * scale), new(24 / 2, 76 / 2), 0, Color.White);
        }
        else if (player.animIdle <= 40 && player.animIdle >= 20)
        {
            Raylib.DrawTexturePro(player.spritesheet, new(128, 80, 24, 76), new(pos, 24 * scale, 76 * scale), new(24 / 2, 76 / 2), 0, Color.White);
        }

        if (player.animIdle >= 40)
        {
            player.animIdle = 0;
        }
        else
        {
            player.animIdle++;
        }
        return player;
    }
    public static int HighHitLeft(Player player)
    {
        return player.animState;
    }

    public static int HitLeft(Player player)
    {
        return player.animState;
    }

    public static int HighHitRight(Player player)
    {
        return player.animState;
    }

    public static int HitRight(Player player)
    {
        return player.animState;
    }
}