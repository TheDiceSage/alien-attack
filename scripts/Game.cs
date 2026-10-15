using Godot;
using System;

public partial class Game : Node2D
{

    int lives = 3;
    Area2D Deathzone => GetNode<Area2D>("Deathzone");
    Player Player => GetNode<Player>("Player");
    public override void _Ready()
    {

        Deathzone.AreaEntered += _OnDeathzoneEntered;
        Player.TookDamage += _OnPlayerTookDamage;
    }

    private void _OnDeathzoneEntered(Area2D area)
    {
        if (area is Enemy enemy)
        {
            enemy.Die();
        }
        
    }

    private void _OnPlayerTookDamage()
    {
        lives--;
        
        if (lives <= 0)
        {
            GD.Print("Game Over!");
            Player.Die();
        }
        else {GD.Print($"Player took damage! Lives remaining: {lives}");}
    }


}
