using Godot;

public partial class Player : CharacterBody2D
{
    [Export] public float Speed = 200f;

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("Shoot"))
        {
            Shoot();
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        var ScreenSize = GetViewport().GetVisibleRect().Size;

        Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        Velocity = direction * Speed;

        MoveAndSlide();

        GlobalPosition = GlobalPosition.Clamp(new Vector2(0, 0), ScreenSize);

        GD.Print(GlobalPosition);
    }

    public void Shoot()
{
    GD.Print("Shoot");
    var rocket = GD.Load<PackedScene>("res://scenes/Rocket.tscn").Instantiate<Rocket>();
    GetParent().AddChild(rocket);
    rocket.GlobalPosition = GlobalPosition;
}
}