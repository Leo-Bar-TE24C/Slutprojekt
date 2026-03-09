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

    public Enemy()
    {
        spritesheet = Raylib.LoadTexture(@"PunchOutGlassJoe.gif");
        dmg = 5;
        hp = 150;
        moveset = ["Right hook", "Viva la france"];
        isAttacking = false;
        animState = 0;
    }

    public static (int, bool, int) Attack(List<string> moveset, Texture2D spritesheet, int animState, bool isAttacking, int move)
    {
        if (isAttacking == false)
        {
            move = Random.Shared.Next(moveset.Count);
            isAttacking = true;
        }
        

        if (moveset[move] == "Right hook")
        {
            (animState,isAttacking) = RightHook(spritesheet, animState);
        }
        else if (moveset[move] == "Viva la france")
        {
            (animState,isAttacking) = VivaLaFrance(spritesheet, animState);
        }
        return (animState, isAttacking, move);
    }

    public static (int,bool) RightHook(Texture2D spritesheet, int animState)
    {
        Vector2 pos = new(450, 600);
        int scale = 5;
        bool isAttacking=true;

        if (animState <= 20)
        {
            Raylib.DrawTexturePro(spritesheet, new(71, 770, 35, 89), new(pos, 35 * scale, 89 * scale), new(71 / 2, 770 / 2), 0, Color.White);
        }
        else if (animState > 20 && animState <= 40)
        {
            Raylib.DrawTexturePro(spritesheet, new(135, 770, 35, 89), new(pos, 35 * scale, 89 * scale), new(71 / 2, 770 / 2), 0, Color.White);
        }
        else if (animState > 40 && animState <= 60)
        {
            Raylib.DrawTexturePro(spritesheet, new(202, 766, 39, 93), new(pos, 39 * scale, 93 * scale), new(71 / 2, 770 / 2), 0, Color.White);
        }

        if (animState < 60)
        {

            animState++;
            isAttacking=true;
            
        }
        else if (animState >= 60)
        {
            animState = 0;
            isAttacking=false;
        }
        return (animState,isAttacking);
    }

    public static (int, bool) VivaLaFrance(Texture2D spritesheet, int animState)
    {
        Vector2 pos = new(450, 600);
        int scale = 5;
                bool isAttacking=true;

        
        if (animState <= 20)
        {
            Raylib.DrawTexturePro(spritesheet, new(71, 656, 40, 100), new(pos, 40 * scale, 100 * scale), new(71 / 2, 770 / 2), 0, Color.White);
        }
        else if (animState > 20 && animState <= 40)
        {
            Raylib.DrawTexturePro(spritesheet, new(130, 656, 40, 100), new(pos, 40 * scale, 100 * scale), new(71 / 2, 770 / 2), 0, Color.White);
        }
        else if (animState > 40 && animState <= 60)
        {
            Raylib.DrawTexturePro(spritesheet, new(190, 656, 39, 100), new(pos, 39 * scale, 100 * scale), new(71 / 2, 770 / 2), 0, Color.White);
        }
        
        if (animState < 60)
        {

            animState++;
            isAttacking=true;
            
        }
        else if (animState >= 60)
        {
            animState = 0;
            isAttacking=false;
        }
        return (animState,isAttacking);
    }
}
