using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update(){
    
        if(Input.GetKey(KeyCode.J))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        // shooting logic
        Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
    }
}
