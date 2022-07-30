using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    [SerializeField]private float speed = 1;
    private Rigidbody2D body;
    
    
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(speed,body.velocity.y);
        

    }
    void OnCollisionEnter2D (Collision2D collision)
    {   
       speed *= - 1;
    }
}
