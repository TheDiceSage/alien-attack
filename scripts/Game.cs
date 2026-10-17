using Godot;
using System;

public partial class Game : Node2D
{

    int lives = 3;
    int score = 0;
private bool _isGameOver;
    Area2D Deathzone => GetNode<Area2D>("Deathzone");
    Player Player => GetNode<Player>("Player");
    Hud Hud => GetNode<Hud>("UI/HUD");

    EnemySpawner _enemySpawner => GetNode<EnemySpawner>("EnemySpawner");

    AudioStreamPlayer2D EnemyHitSound => GetNode<AudioStreamPlayer2D>("EnemyHitSound");
    AudioStreamPlayer2D PlayerHitSound => GetNode<AudioStreamPlayer2D>("PlayerHitSound");

    CanvasLayer UI => GetNode<CanvasLayer>("UI");

    PackedScene GameOverScene = GD.Load<PackedScene>("res://scenes/game_over_screen.tscn");

    public override void _Ready()
    {
        Deathzone.AreaEntered += _OnDeathzoneEntered;
        Player.TookDamage += _OnPlayerTookDamage;
        _enemySpawner.EnemySpawned += _OnEnemySpawnerEnemySpawned;
        _enemySpawner.PathEnemySpawned += _OnEnemySpawnerPathEnemySpawned;
    }

    private void _OnDeathzoneEntered(Area2D area)
    {
        if (area is Enemy enemy)
        {
            enemy.QueueFree();
        }

    }

    private async void _OnPlayerTookDamage()
    {
        if (_isGameOver) return;
        lives--;
        Hud.UpdateLives(lives);
        PlayerHitSound.Play();
        if (lives <= 0)
        {
            _isGameOver = true;
            GD.Print("Game Over!");
            Player.Die();
            await ToSignal(GetTree().CreateTimer(0.5), SceneTreeTimer.SignalName.Timeout);
            var GameOverInstance = GameOverScene.Instantiate<GameOverScreen>();
            UI.AddChild(GameOverInstance);
            GameOverInstance.SetScore(score);
        }
        else { GD.Print($"Player took damage! Lives remaining: {lives}"); }
    }

    private void _OnEnemySpawnerEnemySpawned(Enemy enemyInstance)
    {
        GD.Print($"Enemy spawned at position: {enemyInstance.GlobalPosition}");
        AddChild(enemyInstance);
        enemyInstance.EnemyDied += _OnEnemyDied;
        

    }

    private void _OnEnemySpawnerPathEnemySpawned(PathEnemy pathEnemyInstance)
    {
        AddChild(pathEnemyInstance);
        pathEnemyInstance.Enemy.EnemyDied += _OnEnemyDied;
    }

    private void _OnEnemyDied(Enemy enemyInstance)
    {
        score += 100;
        GD.Print($"Enemy died! Score: {score}");
        Hud.UpdateScore(score);
        EnemyHitSound.Play();
    }


}
