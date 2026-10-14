using Godot;

public partial class Rocket : Area2D
{
    [Export] public float Speed = 480f;

    public override void _PhysicsProcess(double delta)
    {
        GlobalPosition += new Vector2(Speed * (float)delta, 0);
        GD.Print(Speed * (float)delta);
    }
}