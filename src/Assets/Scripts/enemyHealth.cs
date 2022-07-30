using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    
    [SerializeField]public float health = 5;

    public void TakeDamage(int damage)
    {
        health -= damage;
    
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
