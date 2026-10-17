using Godot;
using System;

public partial class GameOverScreen : Control
{
    private Label _Score;
    public override void _Ready()
    {
        GetNode<Button>("Panel/RetryButton").Pressed += _OnRetryButtonPressed;
    _Score = GetNode<Label>("Panel/Score");
    }
    
    private void _OnRetryButtonPressed()
    {
        GD.Print("Retry button pressed");
        GetTree().ReloadCurrentScene();
    }

    public void SetScore(int score)
    {
        GD.Print($"Setting score to: {score}");
        _Score.Text = $"SCORE: {score}";
    }
}
