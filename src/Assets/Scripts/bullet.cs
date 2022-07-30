using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{


    [SerializeField] public float speed = 20f;
    [SerializeField] public int dmg = 1;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    IEnumerator Start (){
        rb.velocity = transform.right * speed;
        yield return new WaitForSeconds(2f);
    }

    void OnTriggerEnter2D (Collider2D collision)
    {   
        enemyHealth enemy = collision.GetComponent<enemyHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(dmg);
        }
        Destroy(gameObject);
    }


}
