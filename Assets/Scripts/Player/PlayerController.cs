using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IPlayerDamage
{

    public float speed;
    public float dmg;
    private Vector2 _move;

    private Animator _animator;

    [SerializeField]
    private float DamageAfterTime = 0.3f;



    [SerializeField]
    private int Damage = 1;

    private AttackArea _attackArea;

    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
    

    }

    // Update is called once per frame
    void Update()
    {
        if(DialogueManager.isActive)
            return;
        

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
        }
    }
}


