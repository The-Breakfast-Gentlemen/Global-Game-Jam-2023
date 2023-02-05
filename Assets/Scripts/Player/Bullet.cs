using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject target;
    public float speed = 5f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            target = GameObject.FindWithTag("Enemy");
        }
        Vector3 direction = (Vector3)(target.transform.position- transform.position).normalized;
        //direction.Normalize();
        rb.velocity = direction * speed;


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            var damageable = other.GetComponent<IDamageable>();
            if(damageable != null)
            {
                Debug.Log("DRONE SHOT");
                damageable.Damage(1);
            }

            Destroy(gameObject);
        }
    }    
    
}
