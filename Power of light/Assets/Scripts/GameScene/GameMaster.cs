using TMPro; 
using UnityEngine;

public class GameMaster : MonoBehaviour {

    [SerializeField] float maxHealth;
    float health;
    public float Health {
        get
        {
            return health; 
        }
        set
        {
            health = value;
            UpdateHealthUI(); 
            if (health <= 0)
            {
                health = 0;
                BattleLost(); 
            }
        }
    }
    int gold; 
    int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
            UpdateGoldUI(); 
        }
    }

    public static GameMaster instance;
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI lastingEnemiesText;

    private void Awake()
    {
        Gold = 0;
        Health = maxHealth;

        if (instance == null) instance = this;
        else this.enabled = false;
    }

    private void UpdateHealthUI()
    {
        healthText.text = string.Format(health.ToString()); 
    } 
    private void UpdateGoldUI()
    {
        goldText.text = string.Format(gold.ToString()); 
    }
    public void UpdateLastingEnemiesUI(int number)
    {
        lastingEnemiesText.text = string.Format(number.ToString()); 
    }

    void DamageCity(float damage)
    {
        Health -= damage;
    }

    public void IncreaseGold(int amount)
    {
        Gold += amount; 
    }

    public void WaveEnded()
    {
        Health = maxHealth;
    }

    public void BattleLost()
    {
        //game over
    }
}
