using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class SkillChoiceUI : MonoBehaviour
{
    public GameObject buttonPrefab; // UI�{�^���̃v���n�u
    public Transform buttonContainer;

    private PlayerController player;

    public void Init(PlayerController playerRef, List<WeaponData> weaponOptions)
    {
        player = playerRef;

        // �����̃{�^�����폜
        foreach (Transform child in buttonContainer)
        {
            Destroy(child.gameObject);
        }

        // �V����weapon�̑I������ǉ�
        foreach (var weapon in weaponOptions)
        {
            GameObject buttonObj = Instantiate(buttonPrefab, buttonContainer);
            TextMeshProUGUI label = buttonObj.GetComponentInChildren<TextMeshProUGUI>();
            if (label != null)
                label.text = weapon.weaponName;

            Button button = buttonObj.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(() => OnWeaponSelected(weapon));
            }
        }

        gameObject.SetActive(true);
    }

    void OnWeaponSelected(WeaponData selected)
    {
        player.AcquireWeapon(selected);
        gameObject.SetActive(false);
    }
}
