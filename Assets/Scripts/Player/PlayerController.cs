using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("キャラデータ")]
    public PlayerCharacterData characterData;

    [Header("ステータス")]
    private float currentHP;
    private float currentShield;
    private float moveSpeed;

    [Header("エネルギー管理")]
    public float initialEnergy = 0f;
    public float initialEnergyMax = 100f;
    public float energyRegenRate = 60f;

    [Header("経験値")]
    public int level = 1;
    public int currentExp = 0;
    public int expToNextLevel = 100;

    [Header("UI")]
    public Slider energySlider;
    public Slider expSlider;
    public TextMeshProUGUI expText;
    public TextMeshProUGUI levelText;

    [Header("スキル関連")]
    public Transform firePoint;
    public List<SkillData> allSkills;
    public SkillChoiceUI skillChoiceUI;

    void Start()
    {
        if (characterData != null)
        {
            Debug.Log("StartでApplyCharacterDataを呼び出し！");
            ApplyCharacterData(characterData);
        }
        else
        {
            Debug.LogWarning("characterData が Start 時点で null です！");
        }
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(moveX, moveY).normalized;

        Debug.Log($"移動入力: {move} | moveSpeed: {moveSpeed}");

        transform.Translate(move * moveSpeed * Time.deltaTime);

        if (initialEnergy < initialEnergyMax)
        {
            initialEnergy += energyRegenRate * Time.deltaTime;
            if (initialEnergy > initialEnergyMax) initialEnergy = initialEnergyMax;
        }

        if (Input.GetKeyDown(KeyCode.Space) && initialEnergy >= initialEnergyMax && characterData.initialSkill != null)
        {
            FireSkill(characterData.initialSkill);
            initialEnergy = 0f;
        }

        if (energySlider != null)
            energySlider.value = initialEnergy / initialEnergyMax;

        if (expSlider != null)
        {
            expSlider.value = (float)currentExp / expToNextLevel;
            if (expText != null)
                expText.text = $"{currentExp} / {expToNextLevel}";
        }

        if (levelText != null)
            levelText.text = $"Lv {level}";
    }

    void ApplyCharacterData(PlayerCharacterData data)
    {
        currentHP = data.maxHP;
        currentShield = data.shieldMax;
        moveSpeed = data.moveSpeed;
        initialEnergyMax = 100f * data.energyEfficiency;
        energyRegenRate = 60f * data.energyEfficiency;

        Debug.Log($"[ApplyCharacterData] {data.characterName} → moveSpeed = {moveSpeed}");
    }

    void FireSkill(SkillData skill)
    {
        if (skill.projectilePrefab == null || firePoint == null) return;
        StartCoroutine(FireBurst(skill));
    }

    IEnumerator FireBurst(SkillData skill)
    {
        for (int i = 0; i < skill.shotCount; i++)
        {
            GameObject bullet = Instantiate(skill.projectilePrefab, firePoint.position, firePoint.rotation);
            SkillProjectile sp = bullet.GetComponent<SkillProjectile>();
            if (sp != null)
            {
                sp.speed = skill.projectileSpeed;
                sp.lifeTime = skill.duration > 0 ? skill.duration : 2f;
            }
            yield return new WaitForSeconds(0.1f);
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

            if (skillChoiceUI != null && allSkills.Count > 0)
            {
                List<SkillData> options = new List<SkillData>();
                while (options.Count < 3 && options.Count < allSkills.Count)
                {
                    SkillData candidate = allSkills[Random.Range(0, allSkills.Count)];
                    if (!options.Contains(candidate)) options.Add(candidate);
                }

                skillChoiceUI.Init(this, options);
            }
        }
    }

    public void AcquireSkill(SkillData skill)
    {
        allSkills.Add(skill);
    }
}
