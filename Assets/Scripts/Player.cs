using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variables
    public float maxHealth, maxColdness, maxHunger;
    public float coldIncreaseRate, hungerIncreaseRate;
    private float health, coldness, hunger;

    public bool dead;

    //functions
    public void Start()
    {
        health = maxHealth;
    }
    public void Update()
    {
        if (!dead)
        {
            hunger += hungerIncreaseRate * Time.deltaTime;
            coldness += coldIncreaseRate * Time.deltaTime;
        }

        if (coldness >= maxColdness)
            Die();
        if (hunger >= maxHunger)
            Die();

    }


    public void Die()
    {
        dead = true;
        print("You have died");
    }


}
