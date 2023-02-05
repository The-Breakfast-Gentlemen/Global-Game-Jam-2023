using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossWeaponController : MonoBehaviour
{
    private PlayerController playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerController.PlayerDamage(1);
        }
    }
}
