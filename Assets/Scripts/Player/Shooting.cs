using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform firePoint;

    float timer;
    int waitingTime = 5;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        target = GameObject.FindWithTag("Enemy");

        if(timer > waitingTime && target != null)
        {
            Shoot();
            timer = 0;
        }

    

    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
