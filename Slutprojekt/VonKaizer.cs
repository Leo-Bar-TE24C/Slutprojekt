using Raylib_cs;

public class VonKaizer: Enemy
{
    int bigDMG;

    
    public VonKaizer()
    {
        dmg = 30;
        bigDMG = dmg*2;
        hp = 200;
        moveset = ["Jab", "Big uper", "Upercut"];
        spritesheet = Raylib.LoadTexture(@"VonKaizer.gif");
    }



}