using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectUI : MonoBehaviour
{
    [System.Serializable]
    public class CharacterButton
    {
        public Button button;
        public PlayerCharacterData characterData;
    }

    public CharacterButton[] characterButtons;

    void Start()
    {
        foreach (var cb in characterButtons)
        {
            if (cb.button != null && cb.characterData != null)
            {
                cb.button.onClick.AddListener(() => OnCharacterSelected(cb.characterData));
            }
        }
    }

    void OnCharacterSelected(PlayerCharacterData selected)
    {
        GameManager.Instance.selectedCharacter = selected;
        SceneManager.LoadScene("GameScene"); // ←ゲーム本編のシーン名に変更
    }
}
