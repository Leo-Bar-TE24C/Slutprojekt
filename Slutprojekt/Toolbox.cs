using System.Runtime.CompilerServices;
using Raylib_cs;

public class Toolbox
{

    public static (Enemy, Player) Combat(Enemy enemy, Player player)
    {

        //    enemy

        if (enemy.isAttacking == true || enemy.timeSince >= enemy.cooldown)
        {
            enemy.animIdle = 0;
            enemy = Enemy.Attack(enemy);
        }
        else
        {
            enemy.timeSince++;
            enemy = Enemy.Idle(enemy);
        }


        // player
        if (player.stunned == false)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.J) == true || (player.isAttacking == true && (player.attack == 0 || player.attack == 1)))
            {
                player.animIdle = 0;
                if (Raylib.IsKeyDown(KeyboardKey.W) == true || player.attack == 1)
                {
                    player = Player.HighHitLeft(player);
                }
                else
                {
                    player = Player.HitLeft(player);
                }
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.K) == true || (player.isAttacking == true && (player.attack == 2 || player.attack == 3)))
            {
                player.animIdle = 0;
                if (Raylib.IsKeyPressed(KeyboardKey.W) == true || player.attack == 3)
                {
                    player = Player.HighHitRight(player);
                }
                else
                {
                    player = Player.HitRight(player);
                }
            }
            else
            {
                player = Player.Idle(player);
            }
        }

        return (enemy, player);
    }
}