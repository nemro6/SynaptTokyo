using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [Header("キャラデータ")]
    public PlayerCharacterData characterData;

    [Header("移動")]
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    [Header("weapon発射")]
    public WeaponData initialWeapon;
    public Transform firePoint;

    private float currentEnergy = 0f;

    [Header("UI")]
    public Slider energySlider;
    public Slider expSlider;
    public TMPro.TextMeshProUGUI expText;
    public TMPro.TextMeshProUGUI levelText;
    public SkillChoiceUI skillChoiceUI; // 今後のweapon習得用UI

    [Header("経験値とレベル")]
    public int level = 1;
    public int currentExp = 0;
    public int expToNextLevel = 100;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (characterData != null)
        {
            moveSpeed = characterData.moveSpeed;
            initialWeapon = characterData.initialWeapon;
        }

        UpdateLevelUI();
    }

    void Update()
    {
        Move();

        if (initialWeapon != null)
        {
            currentEnergy += initialWeapon.baseEnergy * Time.deltaTime;

            if (currentEnergy >= initialWeapon.baseEnergy)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Fire();
                    currentEnergy = 0f;
                }
            }

            if (energySlider != null)
                energySlider.value = currentEnergy / initialWeapon.baseEnergy;
        }
    }

    void Move()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        rb.velocity = input * moveSpeed;
    }

    void Fire()
    {
        if (initialWeapon.projectilePrefab != null && firePoint != null)
        {
            GameObject proj = Instantiate(initialWeapon.projectilePrefab, firePoint.position, firePoint.rotation);
            WeaponProjectile wp = proj.GetComponent<WeaponProjectile>();
            if (wp != null)
            {
                wp.Init(initialWeapon);
            }
        }
    }

    public void GainExp(int amount)
    {
        currentExp += amount;
        while (currentExp >= expToNextLevel)
        {
            currentExp -= expToNextLevel;
            level++;
            expToNextLevel = Mathf.RoundToInt(expToNextLevel * 1.25f);
            Debug.Log($"レベルアップ！現在レベル: {level}");
        }

        UpdateLevelUI();
    }

    void UpdateLevelUI()
    {
        if (levelText != null)
            levelText.text = $"Lv.{level}";

        if (expSlider != null)
        {
            expSlider.maxValue = expToNextLevel;
            expSlider.value = currentExp;
        }

        if (expText != null)
        {
            expText.text = $"{currentExp} / {expToNextLevel}";
        }
    }

    public void AcquireWeapon(WeaponData weapon)
    {
        Debug.Log($"weapon {weapon.weaponName} を習得しました！");
        // 今後: リストに追加して自動発射 weapon に加えるなど
    }
}
