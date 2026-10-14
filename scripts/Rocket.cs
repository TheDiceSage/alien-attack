using Godot;

public partial class Rocket : Area2D
{
    [Export] public float RocketSpeed = 480f;

    public override void _Ready()
    {
        GetNode<VisibleOnScreenNotifier2D>("VisibleNotifier").ScreenExited += OnScreenExited;
    }

    public override void _PhysicsProcess(double delta)
    {
        GlobalPosition += new Vector2(RocketSpeed * (float)delta, 0);
        GD.Print(RocketSpeed * (float)delta);
    }

    public void OnScreenExited()
    {
        QueueFree();
    }
}