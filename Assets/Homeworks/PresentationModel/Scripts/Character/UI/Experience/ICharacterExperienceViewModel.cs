
public interface ICharacterExperienceViewModel : IViewModel
{
    int Experience { get; }
    int MaxExperience { get; }
    bool IsReachedExperience { get; }

    void ChangeExperience(int experience);

    void ChangeReachedExperience(bool isReached);

    string GetTextInfoExperience();
}
