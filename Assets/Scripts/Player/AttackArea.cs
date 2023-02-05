using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private List<IDamageable> _damageablesInRange;

    public List<IDamageable> Damageables { get; } = new();
    public Transform player;

    void Update()
    {
        transform.position = new Vector3(player.position.x + 1.2f, player.position.y, player.position.z);
    }

    public void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if(damageable != null)
        {
            Debug.Log(damageable);
            Damageables.Add(damageable);
        } 
    }

    public void OnTriggerExit(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if(damageable != null && Damageables.Contains(damageable))
        {
            Damageables.Remove(damageable);
        }
    }
}
