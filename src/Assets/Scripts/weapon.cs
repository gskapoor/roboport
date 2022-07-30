using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool Shot = true;
    


    // Update is called once per frame
    void Update()
    {
        
        if (Shot == false) 
          {
              
              StartCoroutine(ShootDelay());
              
          }
        
        else if(Input.GetKey(KeyCode.J) && Shot == true)
        {
            Shoot();
            
            Shot = false;
        }
            
    }
    IEnumerator ShootDelay()
   {
     yield return new WaitForSeconds(1);
     Debug.Log("I've Waited");
     Shot = true;
   }
  
    void Shoot()
    {
        // shooting logic
        Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
    }
}
