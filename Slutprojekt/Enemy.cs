using Raylib_cs;
public class Enemy
{
    public int dmg;
    public int hp;
    List<string> moveset = ["punch"];
    public Texture2D glassJoeSpritesheet = Raylib.LoadTexture(@"PunchOutGlassJoe.gif");
}
