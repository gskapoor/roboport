using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField] private float shotDelay = 0.2f;

    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool canShoot = true;
    


    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetButton("Fire1") && canShoot == true)
        {
            Shoot();
            canShoot = false;
            StartCoroutine(ShootDelay());
        }
            
    }
    IEnumerator ShootDelay()
    {
     yield return new WaitForSeconds(shotDelay);
     canShoot = true;
    }
  
    void Shoot()
    {
        // shooting logic
        Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
    }
}
