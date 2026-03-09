using System.Runtime.CompilerServices;
using Raylib_cs;

public class Toolbox
{
   
    public static void Combat(Enemy enemy, Player player)
    {   

    //    enemy
        
        enemy =Enemy.Attack(enemy);
        
            
        // player
        if(player.stunned == false)
        {
            if(Raylib.IsKeyPressed(KeyboardKey.J)==true || player.isAttacking)
            {
                player.animIdle=0;
            }
            else if(Raylib.IsKeyPressed(KeyboardKey.K)==true || player.isAttacking)
            {
                player.animIdle=0;
            }
            else
            {
                player = Player.Idle(player);
            }
        }
    }
}