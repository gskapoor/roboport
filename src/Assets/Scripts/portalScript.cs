using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalScript : MonoBehaviour
{
    public GameObject Portal;
    public GameObject Player;
    [SerializeField] public float portalOffset = -1f;



    public void OnTriggerEnter2D(Collider2D other)
    {
     
    if (other.gameObject.name == "player") 

        {
         
        StartCoroutine (Teleport ());
        }
    }


 IEnumerator Teleport()
    {
    yield return new WaitForSeconds (0.5f);
    Player.transform.position = new Vector2 (Portal.transform.position.x + portalOffset, Portal.transform.position.y);
    }
}
