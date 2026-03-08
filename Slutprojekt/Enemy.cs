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

    public Enemy()
    {
        spritesheet = Raylib.LoadTexture(@"PunchOutGlassJoe.gif");
        dmg = 5;
        hp = 150;
        moveset = ["Right hook", "Left hook", "Viva la france"];
        isAttacking = false;
    }
    
    public static void Attack(List<string> moveset, Texture2D spritesheet)
    {
        int move = Random.Shared.Next(moveset.Count);

        if(moveset[move] == "Right hook")
        {
            RightHook(spritesheet);
        }
        else if (moveset[move] ==  "Left hook" )
        {
            
        }
        else if (moveset[move] ==  "Viva la france" )
        {
            
        }
    }

    public static void RightHook(Texture2D spritesheet)
    {
        Vector2 pos = new(450, 600);
        int scale = 5 ;
        

        Raylib.DrawTexturePro(spritesheet,new(71,770,35,89),new(pos,35*scale,89*scale),new(71/2,770/2),0,Color.White);
        Raylib.DrawTexturePro(spritesheet,new(135,770,35,89),new(pos,35*scale,89*scale),new(71/2,770/2),0,Color.White);
        Raylib.DrawTexturePro(spritesheet,new(202,766,39,93),new(pos,39*scale,93*scale),new(71/2,770/2),0,Color.White);


    }

    public static void LeftHook()
    {
        
    }

    public static void VivaLaFrance()
    {
        
    }
}
