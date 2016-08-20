using UnityEngine;
using System.Collections;

public class health : MonoBehaviour
{

    public float currentHealth = 50;

    public GameObject killEffect;

    void ApplyDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            if (killEffect)
                Instantiate(killEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
