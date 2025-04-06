using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerCharacterData selectedCharacter;

    void Awake()
    {
        // Singleton‰»
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // ƒV[ƒ“‚ğŒ×‚¢‚Å‚à•Û
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
