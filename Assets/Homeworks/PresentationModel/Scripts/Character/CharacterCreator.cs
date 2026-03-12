using UnityEngine;

public class CharacterCreator : MonoBehaviour
{
    [SerializeField] private CharacterCatalog _characterCatalog;
    [SerializeField] private Character _characterPrefab;
    [SerializeField] private Transform _container;

    private void Awake()
    {
        CreateCharacters();
    }

    public void CreateCharacters()
    {
        for (int i = 0; i < _characterCatalog.CharactersConfig.Length; i++)
        {
            Character character = Instantiate(_characterPrefab, _container);

            character.gameObject.name = _characterCatalog.CharactersConfig[i].name;
            character.Initialize(_characterCatalog.CharactersConfig[i]);
        }
    }
}