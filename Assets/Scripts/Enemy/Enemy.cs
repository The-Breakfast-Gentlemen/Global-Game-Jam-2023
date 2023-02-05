using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour, IDamageable
{
    public float bossHealth;
    public GameObject weapon;

    // Start is called before the first frame update
    public void Damage(int damageAmount)
    {
        Debug.Log("OW BITCH!");
        bossHealth--;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(bossHealth <= 0)
        {
            BossDeath();
        }
    }

    void BossDeath()
    {
        gameObject.SetActive(false);
        weapon.SetActive(false);

    }
}
