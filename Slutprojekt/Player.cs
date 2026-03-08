using System.Numerics;
using Raylib_cs;
public class Player
{
    public int hp;
    public int lowDmg;

    public int highDmg;
    public bool isDodgeing;
    public Texture2D spritesheet;

    public Player()
    {
        spritesheet = Raylib.LoadTexture(@"LittleMac.png");
        isDodgeing = false;
        lowDmg = 1;
        highDmg = 3;
        hp = 100;
    }

    public static void Idle(Texture2D spritesheet)
    {
        Vector2 pos = new(500,500);
        int scale = 5;
        Raylib.DrawTexturePro(spritesheet,new(88,80,24,76),new(pos,24*scale,76*scale),new(24/2,76/2),0,Color.White);
    }
    public static void HighHitleft(Texture2D spritesheet)
    {
        
    }
}