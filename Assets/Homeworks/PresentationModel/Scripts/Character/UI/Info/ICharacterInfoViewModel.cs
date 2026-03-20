using UnityEngine;

public interface ICharacterInfoViewModel : IViewModel
{
    string Name { get; }
    string Description { get; }
    Sprite SpriteAvatar { get; }
    string Level { get; }

    void ChangeLevel(int level);
}