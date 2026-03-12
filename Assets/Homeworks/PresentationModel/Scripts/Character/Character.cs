using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterConfig _characterInfo;
    private CharacterStatsController _characterStats;
    private CharacterExperienceController _characterExperience;

    public string Name => _characterInfo.Name;
    public string Description => _characterInfo.Description;
    public Sprite SpriteAvatar => _characterInfo.SpriteAvatar;
    public CharacterStatsController CharacterStats => _characterStats;
    public CharacterExperienceController CharacterExperience => _characterExperience;

    public void Initialize(CharacterConfig characterInfo)
    {
        _characterInfo = characterInfo;
        _characterStats = new CharacterStatsController(_characterInfo.CharacterStats);
        _characterExperience = new CharacterExperienceController(_characterInfo.StartLevel);
    }

    public void LevelUp()
    {
        _characterExperience.ChangeNextLevel();
        _characterStats.IncreaseStats();
    }
}