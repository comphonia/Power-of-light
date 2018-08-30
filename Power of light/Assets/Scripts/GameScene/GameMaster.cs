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
                defeatPanel.SetActive(true); 
            }
        }
    }
    int gold; 
    public int Gold
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
    [SerializeField] TextMeshProUGUI waveNumberText;

    [SerializeField] GameObject defeatPanel; 

    private void Awake()
    {
        Gold = 200;
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
    public void UpdateWaveNumberUI (int number)
    {
        waveNumberText.text = string.Format("WAVE: " + number); 
    }

    void DamageCity(float damage)
    {
        Health -= damage;
    }

    public void WaveEnded()
    {
        Health = maxHealth;
    }
}
