using Raylib_cs;
public class Enemy
{
    
    public int dmg;
    public int hp;
    List<string> moveset;

    public Texture2D Spritesheet;

    public Enemy()
    {
        Spritesheet = Raylib.LoadTexture(@"PunchOutGlassJoe.gif");
        dmg = 5;
        hp = 100;
        moveset = ["Right hook", "Left hook", "Viva la france"];
    }
    
    public void Attack(List<string> moveset)
    {
        
    }
}
