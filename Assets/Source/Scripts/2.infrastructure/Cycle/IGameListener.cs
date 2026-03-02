public interface IGameListener { }

interface IGameInitializeListener : IGameListener
{
    public void Initialize();
}

interface IGameTickListener : IGameListener
{
    public void UpdateGame();
}