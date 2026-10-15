using Godot;
using System;

public partial class Enemy : Area2D
{
    [Export] public float EnemySpeed = -240f;
    
    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
    }

    public override void _PhysicsProcess(double delta)
    {
        GlobalPosition += new Vector2(EnemySpeed * (float)delta, 0);

    }

    public void Die()
    {
        QueueFree();
    }

    public void OnBodyEntered(Node2D body)
    {
        GD.Print($"Entered: {body.Name} ({body.GetType()})");
        if (body is Player player)
        {
            player.TakeDamage();
            Die();
        }
    }
}
