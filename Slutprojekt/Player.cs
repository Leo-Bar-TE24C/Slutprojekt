using Raylib_cs;
public class Player
{
    public int hp;
    public int lowDmg;

    public int highDmg;
    public bool isDodgeing;
    public Texture2D Spritesheet;

    public Player()
    {
        Spritesheet = Raylib.LoadTexture(@"LittleMac.png");
        isDodgeing = false;
        lowDmg = 1;
        highDmg = 3;
        hp = 100;
    }
}