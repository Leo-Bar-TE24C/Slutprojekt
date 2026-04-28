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

    public static void Anim(Texture2D spritesheet, Rectangle origin, Rectangle dest, int frameCount, int frameLength)
    {
        for (int i = 0; i < frameCount*frameLength ; i++)
        {  
            if (i <= frameLength)
            {
                Raylib.DrawTexturePro(spritesheet, origin, dest, new(origin.Width/2, origin.Height/2), 0, Color.White);
            }
            else if (i > frameLength && i<= frameLength*2)
            {
                Raylib.DrawTexturePro(spritesheet, origin, dest, new(origin.Width/2, origin.Height/2), 0, Color.White);
            }
        }
    }

}