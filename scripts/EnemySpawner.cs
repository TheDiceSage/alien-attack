using System.IO;
using System.Runtime.CompilerServices;
using Godot;

public partial class EnemySpawner : Node2D
{
    [Export] public PackedScene EnemyScene;

    [Export] public PackedScene PathEnemyScene;

    [Signal]
    public delegate void EnemySpawnedEventHandler(Enemy enemyInstance);
    
    [Signal]
    public delegate void PathEnemySpawnedEventHandler(PathEnemy PathEnemyInstance);
    

    private Node2D SpawnPositions;


    public override void _Ready()
    {
        SpawnPositions = GetNode<Node2D>("SpawnPositions");
        GetNode<Timer>("Timer").Timeout += OnTimerTimeout;
        GetNode<Timer>("PathEnemyTimer").Timeout += OnPathTimerTimeout;
    }

    private void OnTimerTimeout()
    {
        SpawnEnemy();
    }

    private void OnPathTimerTimeout()
    {
        SpawnPathEnemy();
    }

    private void SpawnEnemy()
    {
        var PositionsArray = SpawnPositions.GetChildren();
        var randomPosition = (Node2D)PositionsArray[GD.RandRange(0, PositionsArray.Count - 1)];
        var enemyInstance = EnemyScene.Instantiate<Enemy>();
        enemyInstance.GlobalPosition = randomPosition.GlobalPosition;
        EmitSignal(SignalName.EnemySpawned, enemyInstance);
    }

    private void SpawnPathEnemy()
    {
        var PathEnemyInstance = PathEnemyScene.Instantiate<PathEnemy>();
        EmitSignal(SignalName.PathEnemySpawned, PathEnemyInstance);
    }
}