using Godot;
using System;

public partial class PathEnemy : Path2D
{
    private PathFollow2D PathFollow;
    public Enemy Enemy;

    public override void _Ready()
    {
        PathFollow = GetNode<PathFollow2D>("PathFollow2D");
        Enemy = GetNode<Enemy>("PathFollow2D/Enemy");
        PathFollow.SetProgressRatio(1);
    }

    public override void _Process(double delta)
    {
        PathFollow.ProgressRatio -= 0.25f * (float)delta;
        if(PathFollow.ProgressRatio <= 0f)
        {
            QueueFree();
        }
    }


}
