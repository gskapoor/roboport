using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    
    [SerializeField]private float health = 5;

    void Update()
    {
        if (health == 0){
            Destroy(gameObject);         
        }

    }

}
