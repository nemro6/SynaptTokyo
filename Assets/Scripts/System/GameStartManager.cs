using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStartManager : MonoBehaviour
{
    [Header("�v���C���[�̏o���ʒu")]
    public Transform playerSpawnPoint;

    [Header("UI�Q��")]
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
            Debug.Log($"�L��������: {selected.characterName}");

            // �v���C���[����
            GameObject player = Instantiate(selected.characterPrefab, playerSpawnPoint.position, Quaternion.identity);

            // PlayerController �Ƀf�[�^��UI��n��
            PlayerController pc = player.GetComponent<PlayerController>();
            if (pc != null)
            {
                pc.characterData = selected;

                pc.energySlider = energySlider;
                pc.expSlider = expSlider;
                pc.expText = expText;
                pc.levelText = levelText;
                pc.skillChoiceUI = skillChoiceUI;

                Debug.Log("PlayerController �Ƀf�[�^��UI��n���܂����I");
            }
            else
            {
                Debug.LogWarning("PlayerController ��������܂���I");
            }
        }
        else
        {
            Debug.LogError("GameManager.Instance.selectedCharacter �܂��� characterPrefab �� null �ł��I");
        }
    }
}
