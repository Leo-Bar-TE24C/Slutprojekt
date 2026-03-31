using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;

public class Toolbox
{

    public static (Enemy, Player) Combat(Enemy enemy, Player player)
    {

        //    enemy
        enemy = Enemy.StunCheck(enemy);
        if (enemy.stunned == false)
        {
            if (enemy.isAttacking == true || enemy.timeSince >= enemy.cooldown)
            {
                enemy.animIdle = 0;
                (enemy, player) = Enemy.Attack(enemy, player);
            }
            else
            {
                enemy.timeSince++;
                enemy = Enemy.Idle(enemy);
            }
        }

        // player
        (enemy, player) = Toolbox.PayerChecks(player, enemy);

        Healthbar(342, player.hp, player.maxHealth, false);
        Healthbar(753, enemy.hp, enemy.maxHealth, true);

        return (enemy, player);
    }

    public static (Enemy, Player) PayerChecks(Player player, Enemy enemy)
    {
        player = Player.StunCheck(player);

        if (player.stunned == false)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.J) == true || (player.isAttacking == true && (player.attack == 0 || player.attack == 1)))
            {
                player.animIdle = 0;
                if (Raylib.IsKeyDown(KeyboardKey.W) == true || player.attack == 1)
                {
                    (enemy, player) = Player.HighHitLeft(player, enemy);
                }
                else
                {
                    (enemy, player) = Player.HitLeft(player, enemy);
                }
            }
            else if (Raylib.IsKeyPressed(KeyboardKey.K) == true || (player.isAttacking == true && (player.attack == 2 || player.attack == 3)))
            {
                player.animIdle = 0;
                if (Raylib.IsKeyDown(KeyboardKey.W) == true || player.attack == 3)
                {
                    (enemy, player) = Player.HighHitRight(player, enemy);
                }
                else
                {
                    (enemy, player) = Player.HitRight(player, enemy);
                }
            }
            else if ((Raylib.IsKeyPressed(KeyboardKey.A) || player.isDodgeingL) == true)
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

        return (enemy, player);
    }
    public static void Healthbar(int posX, int health, int maxHealth, bool reverse)
    {
        // max widht = 190
        float x = 190 - ((float)health / (float)maxHealth * 190);
        int width = (int)x;


        if (reverse == false)
        {
            Raylib.DrawRectangle(posX, 65, width, 30, Color.Black);
        }
        else
        {
            Raylib.DrawRectangle(posX - width, 65, width, 30, Color.Black);
        }
    }

    public static void DisplayMousePos()
    {
        Vector2 mousePos = Raylib.GetMousePosition();

        Raylib.DrawRectangle(0, 0, 200, 40, Color.Black);
        Raylib.DrawText($"{mousePos}", 0, 0, 30, Color.White);

    }

    public static void DisplayHP(Player player, Enemy enemy)
    {
        Raylib.DrawRectangle(0, 0, 200, 40, Color.Black);
        Raylib.DrawText($"{player.hp}, {enemy.hp}", 0, 0, 30, Color.White);
    }

    public static (int, Player) Win(int round, Player player)
    {
        round++;
        player.hp = player.maxHealth;
        player.win = false;
        return (round, player);
    }

    public static (int, Player) Lose(int round, Player player)
    {
        round = 0;
        player.hp = player.maxHealth;
        player.lose = false;
        return (round, player);
    }
}
