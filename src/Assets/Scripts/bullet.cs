using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour{


    [SerializeField] public float speed = 200f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start (){
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D collision)
    {   
        Destroy(gameObject);
    }


}
