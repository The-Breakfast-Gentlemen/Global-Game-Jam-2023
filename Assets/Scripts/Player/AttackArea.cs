using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Interfaces
{
    public interface IDamageable
    {
        public void Damage(int damageAmount);
    }
}

public class AttackArea : MonoBehaviour
{
    private List<IDamageable> _damageablesInRange;

    public List<IDamageable> Damageables {get;} = new();

    public void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();

        if(damageable != null)
        {
            _damageablesInRange.Add(damageable);
        } 
    }

    public void OnTriggerExit(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if(damageable != null && _damageablesInRange.Contains(damageable))
        {
            _damageablesInRange.Remove(damageable);
        }
    }
}
