using UniRx;

public class CharacterExperienceController
{
    private int _maxExperience = 1000;
    public IReadOnlyReactiveProperty<int> Level => _level;
    private ReactiveProperty<int> _level = new();

    public IReadOnlyReactiveProperty<int> CurrentExperience => _currentExperience;
    private ReactiveProperty<int> _currentExperience = new();

    public int MaxExperience => _maxExperience;
    public bool IsReachedMaxExperience => _maxExperience <= _currentExperience.Value;

    public CharacterExperienceController(int level)
    {
        _level = new IntReactiveProperty(level);
        _currentExperience = new IntReactiveProperty(0);
    }

    public void IncreaseExperience(int experience)
    {
        _currentExperience.Value += experience;

        if (_currentExperience.Value > _maxExperience)
            _currentExperience.Value = _maxExperience;
    }

    public void ChangeNextLevel()
    {
        _level.Value++;
        _currentExperience.Value = 0;
    }
}