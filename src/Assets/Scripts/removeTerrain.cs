using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class removeTerrain : MonoBehaviour
{
    Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        ContactPoint2D[] contacts = new ContactPoint2D[1];
        if (collision.gameObject.name == "bullet(Clone)"){
            Vector3 hitPosition = Vector3.zero;
            collision.GetContacts(contacts);
            hitPosition.x = contacts[0].point.x;
            hitPosition.y = contacts[0].point.y;
            Debug.Log("bruh");
            tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);


        }
        else{
            Debug.Log(collision.gameObject.name);
        }
    }


}
