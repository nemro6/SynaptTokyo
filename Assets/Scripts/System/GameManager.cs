using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerCharacterData selectedCharacter;

    void Awake()
    {
        // Singleton��
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �V�[�����ׂ��ł��ێ�
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
