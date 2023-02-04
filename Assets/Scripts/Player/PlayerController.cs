using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float dmg;
    private Vector2 _move;

    private Animator _animator;

    [SerializeField]
    private float DamageAfterTime;

    [SerializeField]
    private int Damage;

    [SerializeField]
    private AttackArea _attackArea;

    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
    

    }

    // Update is called once per frame
    void Update()
    {
       MovePlayer(); 

       if(Mouse.current.leftButton.wasPressedThisFrame)
       {
           
       }
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
        _animator = GetComponentInChildren<Animator>();
    }

    public void OnAttack(InputValue value)
    {
        _animator.SetTrigger("Attack");
        //StartCoroutine(Hit(false));
    }

}
