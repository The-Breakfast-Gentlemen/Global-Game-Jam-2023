using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour, IDamageable
{
    public float health;

    // Start is called before the first frame update
    public void Damage(int damageAmount)
    {
        Debug.Log("OW BITCH!");
    }
}
