using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerCharacterData selectedCharacter;

    void Awake()
    {
        // Singleton化
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // シーンを跨いでも保持
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
