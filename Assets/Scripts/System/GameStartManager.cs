using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStartManager : MonoBehaviour
{
    [Header("プレイヤーの出現位置")]
    public Transform playerSpawnPoint;

    [Header("UI参照")]
    public Slider energySlider;
    public Slider expSlider;
    public TextMeshProUGUI expText;
    public TextMeshProUGUI levelText;
    public SkillChoiceUI skillChoiceUI;

    void Start()
    {
        var selected = GameManager.Instance?.selectedCharacter;

        if (selected != null && selected.characterPrefab != null)
        {
            Debug.Log($"キャラ生成: {selected.characterName}");

            // プレイヤー生成
            GameObject player = Instantiate(selected.characterPrefab, playerSpawnPoint.position, Quaternion.identity);

            // PlayerController にデータとUIを渡す
            PlayerController pc = player.GetComponent<PlayerController>();
            if (pc != null)
            {
                pc.characterData = selected;

                pc.energySlider = energySlider;
                pc.expSlider = expSlider;
                pc.expText = expText;
                pc.levelText = levelText;
                pc.skillChoiceUI = skillChoiceUI;

                Debug.Log("PlayerController にデータとUIを渡しました！");
            }
            else
            {
                Debug.LogWarning("PlayerController が見つかりません！");
            }
        }
        else
        {
            Debug.LogError("GameManager.Instance.selectedCharacter または characterPrefab が null です！");
        }
    }
}
