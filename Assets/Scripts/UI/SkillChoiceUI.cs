using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class SkillChoiceUI : MonoBehaviour
{
    public GameObject panel;
    public Button[] buttons;
    private List<SkillData> options = new List<SkillData>();
    private PlayerController player;

    public void Init(PlayerController playerRef, List<SkillData> skillOptions)
    {
        player = playerRef;
        options = skillOptions;

        panel.SetActive(true);

        for (int i = 0; i < buttons.Length; i++)
        {
            if (i < options.Count)
            {
                var skill = options[i];
                buttons[i].gameObject.SetActive(true);
                buttons[i].GetComponentInChildren<TextMeshProUGUI>().text = skill.skillName;

                int index = i; // クロージャー対策！
                buttons[i].onClick.RemoveAllListeners();
                buttons[i].onClick.AddListener(() =>
                {
                    player.AcquireSkill(skill);
                    panel.SetActive(false);
                });
            }
            else
            {
                buttons[i].gameObject.SetActive(false);
            }
        }
    }
}
