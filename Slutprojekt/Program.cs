using Raylib_cs;

Raylib.InitWindow(100,100, "Punch Out");
Raylib.SetTargetFPS(60);

while(Raylib.WindowShouldClose() == false)
{

    Toolbox.Combat();


    Raylib.BeginDrawing();

    // play animations based on combat

    Raylib.EndDrawing();
}