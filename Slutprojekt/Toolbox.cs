using System.Runtime.CompilerServices;
using Raylib_cs;

public class Toolbox
{
   
    public static void Combat(Enemy enemy, Player player)
    {
        // player
        {
             // if to the sides dodge (take no damage)
    // if back block (take less damage)
    // if spacebar hit punch
    // if up and spacebar high punch
    // if punch and no block or dodge deal damage
        }

    //    enemy
        if(enemy.isAttacking==false)
        {
        Enemy.Attack(enemy.moveset, enemy.spritesheet);
            enemy.isAttacking=true;
        }
    }
}