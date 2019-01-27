using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{

    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }
    public float damageAmount = 6f;

    public Slider healthBar;

    [SerializeField]
    Player Player;

    // Start is called before the first frame update
    void Start()
    {
        MaxHealth = 20f;
        CurrentHealth = MaxHealth;

        healthBar.value = CalculateHealth();

        Player = GetComponent<Player>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.X))
    //    {
    //        DealDamage(damageAmount);
    //    }
    //}

    void DealDamage(float damageValue)
    {
        CurrentHealth -= damageValue;
        healthBar.value = CalculateHealth();

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    float CalculateHealth()
    {
        return CurrentHealth / MaxHealth;
    }

    void Die()
    {
        CurrentHealth = 0;
        Debug.Log("Player " + Player.playerNum + " is dead.");
    }
}
