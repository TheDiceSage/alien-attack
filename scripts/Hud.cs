using Godot;
using System;

public partial class Hud : Control
{
    private Label _Score;
    private Label _Lives;

    public override void _Ready()
    {
        _Score = GetNode<Label>("Score");
        _Lives = GetNode<Label>("Lives");
        _Score.Text = "Score: 0";
        _Lives.Text = "X 3";
    }

    public void UpdateScore(int score)
    {
        _Score.Text = $"Score: {score}";
    }

    public void UpdateLives(int lives)
    {
        _Lives.Text = $"X {lives}";
    }

}
