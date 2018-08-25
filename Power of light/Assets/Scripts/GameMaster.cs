using System.Collections;
using System.Collections.Generic;
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
        }
    }
    float gold; 

    public static GameMaster instance;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("gold")) gold = PlayerPrefs.GetInt("gold");
        else gold = 0; 

        if (instance == null) instance = this;
        else this.enabled = false;

        health = maxHealth; 
    }

    private void UpdateHealthUI()
    {
       
    }

    void DamageCity(float damage)
    {
        Health -= damage;
    }

    public void IncreaseGold(float amount)
    {
        gold += amount; 
    }
}
