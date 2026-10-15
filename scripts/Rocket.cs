using System;
using Godot;

public partial class Rocket : Area2D
{
    [Export] public float RocketSpeed = 480f;

    public override void _Ready()
    {
        GetNode<VisibleOnScreenNotifier2D>("VisibleNotifier").ScreenExited += OnScreenExited;
        AreaEntered += OnAreaEntered;
    }


    public override void _PhysicsProcess(double delta)
    {
        GlobalPosition += new Vector2(RocketSpeed * (float)delta, 0);
    }

    public void OnScreenExited()
    {
        QueueFree();
    }

private void OnAreaEntered(Area2D area)
    {
        if (area is Enemy enemy)
        {
            enemy.Die();
            QueueFree();
        }
        
    }

}