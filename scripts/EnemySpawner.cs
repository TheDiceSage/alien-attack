using Godot;

public partial class EnemySpawner : Node2D
{
    [Export] public PackedScene EnemyScene;

    private Node2D SpawnPositions;

    public override void _Ready()
    {
        SpawnPositions = GetNode<Node2D>("SpawnPositions");
        GetNode<Timer>("Timer").Timeout += OnTimerTimeout;
        }

    private void OnTimerTimeout()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        var PositionsArray = SpawnPositions.GetChildren();
        var randomPosition = (Node2D)PositionsArray[GD.RandRange(0, PositionsArray.Count -1)];
        var enemyInstance = EnemyScene.Instantiate<Enemy>();
        AddChild(enemyInstance);
        enemyInstance.GlobalPosition = randomPosition.GlobalPosition;
    }
}