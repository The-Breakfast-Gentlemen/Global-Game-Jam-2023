using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IPlayerDamage
{

    public float speed;
    public float dmg;
    //float timer = 0;

    public bool hasRingler = false;
    public int fireTime = 3;

    public bool hasSue = false;

    public bool hasLily = false;

    public bool hasRockim = false;

    private Vector2 _move;

    private Animator _animator;

    [SerializeField]
    private float DamageAfterTime = 0f;



    [SerializeField]
    private int Damage = 1;

    private AttackArea _attackArea;
    public GameObject drone;

    public Enemy enemy;

    // Update is called once per frame
    void Update()
    {
        if(DialogueManager.isActive)
            return;
        
        if(hasSue)
        {
            drone.SetActive(true);
        }
       MovePlayer(); 
    }

    public void OnMove(InputAction.CallbackContext context) 
    {
        _move = context.ReadValue<Vector2>();
    }

    public void MovePlayer()
    {
        Vector3 movement = new Vector3(_move.x, 0f, _move.y);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _attackArea = GetComponentInChildren<AttackArea>();
    }

    public void OnAttack(InputAction.CallbackContext value)
    {
        if(value.started)
        {
            Debug.Log("ATTACK");
            _animator.SetTrigger("Attack");

            if(hasRockim)
            {
                if(Random.Range(1, 100) < 30) // 30% chance
                {
                    StartCoroutine(Hit(true));
                }
            }
            else
                StartCoroutine(Hit(false));
        }

    }

    public void PlayerDamage(int damage)
    {
        Debug.Log("The player has taken damage");
    }

    private IEnumerator Hit(bool strong)
    {
        yield return new WaitForSeconds(DamageAfterTime);
        foreach(var attackAreaDamageable in _attackArea.Damageables)
        {
            attackAreaDamageable.Damage(Damage * (strong ? 2 : 1));
            if(hasRingler)
            {
                for(int i = 0; i < fireTime; i++)
                {
                    Debug.Log("BURN");
                    attackAreaDamageable.Damage(Damage);
                    yield return new WaitForSeconds(1);
                }
            }
        }
    }
}


