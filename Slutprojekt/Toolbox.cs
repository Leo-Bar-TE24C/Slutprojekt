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
            (enemy,player) = Enemy.Attack(enemy,player);
        }
        else
        {
            enemy.timeSince++;
            enemy = Enemy.Idle(enemy);
        }


        // player
        player = Toolbox.PayerChecks(player);

        return (enemy, player);
    }

    public static Player PayerChecks(Player player)
    {
        player = Player.StunCheck(player);

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
                if (Raylib.IsKeyDown(KeyboardKey.W) == true || player.attack == 3)
                {
                    player = Player.HighHitRight(player);
                }
                else
                {
                    player = Player.HitRight(player);
                }
            }
            else if ((Raylib.IsKeyPressed(KeyboardKey.A) || player.isDodgeingL ) == true)
            {
                player.animIdle = 0;
                player.isDodgeingL = true;
                player = Player.Dodge(player);
            }
            else if ((Raylib.IsKeyPressed(KeyboardKey.D) || player.isDodgeingR) == true)
            {
                player.animIdle = 0;
                player.isDodgeingR = true;
                player = Player.Dodge(player);
            }
            else if ((Raylib.IsKeyPressed(KeyboardKey.S) || player.isBlocking) == true)
            {
                player.animIdle = 0;
                player = Player.Block(player);
            }
            else
            {
                player = Player.Idle(player);
            }
        }

        return player;
    }
}
