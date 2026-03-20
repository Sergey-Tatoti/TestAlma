using UniRx;

public class CharacterExperienceController
{
    private int _maxExperience = 1000;
    public IReadOnlyReactiveProperty<int> Level => _level;
    private ReactiveProperty<int> _level = new();

    public IReadOnlyReactiveProperty<int> CurrentExperience => _currentExperience;
    private ReactiveProperty<int> _currentExperience = new();

    public IReadOnlyReactiveProperty<bool> IsReachedMaxExperience => _isReachedMaxExperience;
    private ReactiveProperty<bool> _isReachedMaxExperience = new();

    public int MaxExperience => _maxExperience;

    public CharacterExperienceController(int level)
    {
        _level = new IntReactiveProperty(level);
        _currentExperience = new IntReactiveProperty(0);
        _isReachedMaxExperience = new BoolReactiveProperty(false);
    }

    public void IncreaseExperience(int experience)
    {
        _currentExperience.Value += experience;
        _isReachedMaxExperience.Value = _maxExperience <= _currentExperience.Value;

        if (_currentExperience.Value > _maxExperience)
            _currentExperience.Value = _maxExperience;
    }

    public void ChangeNextLevel()
    {
        _level.Value++;
        _currentExperience.Value = 0;
        _isReachedMaxExperience.Value = false;
    }
}