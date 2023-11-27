using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public bool isTargetPractice;
    public float health = 10f;
    public float defaultHealth;

    private void Start()
    {
        defaultHealth = health;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        if (isTargetPractice)
        {
            health = defaultHealth;
            gameObject.transform.position = new Vector3(UnityEngine.Random.Range(-127, -75), UnityEngine.Random.Range(2, 12), UnityEngine.Random.Range(-22, -8));
        }
        else
        {
            Destroy(gameObject);
        }

        Debug.Log("Target Broken!");
    }
}
