using UnityEngine;

[CreateAssetMenu(fileName = "CharacterCatalog", menuName = "Create/CharacterCatalog", order = -51)]
public class CharacterCatalog : ScriptableObject
{
    public CharacterConfig[] CharactersConfig;
}
