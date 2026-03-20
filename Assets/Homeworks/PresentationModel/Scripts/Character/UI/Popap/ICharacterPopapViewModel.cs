
public interface ICharacterPopapViewModel : IViewModel
{
    bool CanLevelUp { get; }

    void LevelUp();

    void ChangeCanLevelUp(bool canLevelUp);
}