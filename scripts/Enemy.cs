using Godot;
using System;

public partial class Enemy : Area2D
{
    [Export] public float EnemySpeed = -240f;

    public override void _PhysicsProcess(double delta)
    {
        GlobalPosition += new Vector2(EnemySpeed * (float)delta, 0);
        GD.Print(EnemySpeed * (float)delta);
    }

    public void Die()
    {
        QueueFree();
    }
}
