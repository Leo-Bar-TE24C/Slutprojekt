using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;
public class Player
{
    public int hp;
    public int lowDmg;
    public int highDmg;
    public bool isDodgeingR;
    public bool isDodgeingL;
    public Texture2D spritesheet;
    public bool stunned;
    public int stunTime;
    public int animState;
    public bool isAttacking;
    public int animIdle;
    public int idleSide;
    public Vector2 pos;
    public int scale;
    public int attack;
    public bool isBlocking;
    public int maxHealth;

    public Player()
    {
        spritesheet = Raylib.LoadTexture(@"LittleMac.png");
        isDodgeingR = false;
        isDodgeingL = false;
        lowDmg = 1;
        highDmg = 3;
        hp = 100;
        stunned = false;
        animState = 0;
        isAttacking = false;
        animIdle = 0;
        idleSide = 0;
        pos = new(450, 500);
        scale = 5;
        attack = 0;
        isBlocking = false;
        stunTime=0;
        maxHealth=hp;
    }

    public static Player Idle(Player player)
    {
        player.pos.X = 450;

        if (player.idleSide >= 20 && player.idleSide <= 60)
        {
            player.pos.X += 10;
        }
        else if (player.idleSide >= 100 && player.idleSide <= 1400)
        {
            player.pos.X -= 10;
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
            Raylib.DrawTexturePro(player.spritesheet, new(88, 80, 24, 76), new(player.pos, 24 * player.scale, 76 * player.scale), new(24 / 2, 76 / 2), 0, Color.White);
        }
        else if (player.animIdle <= 40 && player.animIdle >= 20)
        {
            Raylib.DrawTexturePro(player.spritesheet, new(128, 80, 24, 76), new(player.pos, 24 * player.scale, 76 * player.scale), new(24 / 2, 76 / 2), 0, Color.White);
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
    public static Player HighHitLeft(Player player)
    {
        player.pos.Y = 350;
        if (player.animState <= 20)
        {
            Raylib.DrawTexturePro(player.spritesheet, new(88, 80 + 75, 24, 76), new(player.pos, 24 * player.scale, 76 * player.scale), new(24 / 2, 76 / 2), 0, Color.White);
        }

        if (player.animState >= 20)
        {
            player.animState = 0;
            player.isAttacking = false;
            player.pos.Y = 500;
            player.attack = 0;
        }
        else
        {
            player.animState++;
            player.isAttacking = true;
            player.attack = 1;
        }

        return player;
    }

    public static Player HitLeft(Player player)
    {
        if (player.animState <= 20)
        {
            Raylib.DrawTexturePro(player.spritesheet, new(407, 80, -25, 76), new(player.pos, 25 * player.scale, 76 * player.scale), new(24 / 2, 76 / 2), 0, Color.White);
        }

        if (player.animState >= 20)
        {
            player.animState = 0;
            player.isAttacking = false;
        }
        else
        {
            player.animState++;
            player.isAttacking = true;
            player.attack = 0;
        }

        return player;
    }

    public static Player HighHitRight(Player player)
    {

        player.pos.Y = 350;
        if (player.animState <= 20)
        {
            Raylib.DrawTexturePro(player.spritesheet, new(88, 80 + 75, -24, 76), new(player.pos, 24 * player.scale, 76 * player.scale), new(24 / 2, 76 / 2), 0, Color.White);
        }

        if (player.animState >= 20)
        {
            player.animState = 0;
            player.isAttacking = false;
            player.pos.Y = 500;
            player.attack = 0;
        }
        else
        {
            player.animState++;
            player.isAttacking = true;
            player.attack = 3;
        }

        return player;
    }

    public static Player HitRight(Player player)
    {
        if (player.animState <= 20)
        {
            Raylib.DrawTexturePro(player.spritesheet, new(407, 80, 25, 76), new(player.pos, 25 * player.scale, 76 * player.scale), new(24 / 2, 76 / 2), 0, Color.White);
        }

        if (player.animState >= 20)
        {
            player.animState = 0;
            player.isAttacking = false;
        }
        else
        {
            player.animState++;
            player.isAttacking = true;
            player.attack = 2;
        }

        return player;
    }

    public static Player Dodge(Player player)
    {
        if (player.animState <= 30)
        {
            if (player.isDodgeingL == true)
            {
                player.pos.X = 350;
                Raylib.DrawTexturePro(player.spritesheet, new(407 - 40, 80, 25, 76), new(player.pos, 25 * player.scale, 76 * player.scale), new(24 / 2, 76 / 2), 0, Color.White);
            }
            else if (player.isDodgeingR == true)
            {
                player.pos.X = 550;
                Raylib.DrawTexturePro(player.spritesheet, new(407 - 40, 80, -25, 76), new(player.pos, 25 * player.scale, 76 * player.scale), new(24 / 2, 76 / 2), 0, Color.White);
            }
        }

        if(player.animState>=30)
        {
            player.animState = 0;
            player.isDodgeingL = false;
            player.isDodgeingR = false;
            player.pos.X =450;
        }
        else
        {
            player.animState++;
        }
        return player;
    }

    public static Player Block(Player player)
    {
        if (Raylib.IsKeyDown(KeyboardKey.S)==true)
        {
            player.isBlocking=true;
            Raylib.DrawTexturePro(player.spritesheet, new(407 - 40-80, 80, 25, 76), new(player.pos, 25 * player.scale, 76 * player.scale), new(24 / 2, 76 / 2), 0, Color.White);

        }
        else
        {
            player.isBlocking = false;
        }
        return player;
    }

    public static Player StunCheck(Player player)
    {
        if (player.stunTime!=0)
        {
            player.stunTime--;
            player.stunned = true;
        }
        else
        {
            player.stunned = false;
        }
        return player;
    }
}