using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StudentAttackController : MonoBehaviour
{
    public Animator _animator; 
    private Animator _weapon_animator;
    private NavMeshAgent agent;
    public List<IPlayerDamage> PlayerDamageables { get; } = new();
    private GameObject player;
    private PlayerController playerController;
    public GameObject weapon;
    
    // Start is called before the first frame update
    void Start()
    {
        //_animator = GetComponentInParent<Animator>();
        agent = GetComponentInParent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        weapon = GameObject.FindWithTag("StudentWeapon");
        //_weapon_animator = weapon.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(player.transform);
    }

    void OnTriggerEnter(Collider other)
    {
        var playerDamageable = other.GetComponent<IPlayerDamage>();
        if(playerDamageable != null)
        {

            //Debug.Log(playerDamageable);
            PlayerDamageables.Add(playerDamageable);
        }

        if(other.CompareTag("Player"))
        {
            int rand = Random.Range(1, 100);
            //Debug.Log(rand);
            if(rand < 70)
            {
                //Debug.Log("BOSS ATTACK");
                StartCoroutine(Attack());
            }
            else
            {
                //Debug.Log("CLOCKWORK");
                StartCoroutine(Clockwork());
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        var playerDamageable = other.GetComponent<IPlayerDamage>();
        if(playerDamageable != null && PlayerDamageables.Contains(playerDamageable))
        {
            PlayerDamageables.Remove(playerDamageable);
        }
    }

    private IEnumerator Attack()
    {
        agent.isStopped = true;
        //Debug.Log("Attack Started");

        // Enable exclamation to warn of attack, enable weapon
        yield return new WaitForSeconds(1);
        // Perform attack animation
        _animator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.3f);
        //Debug.Log("Attack Ended");
        // Disable exclamation and weapon
        agent.isStopped = false;
    }

    private IEnumerator Clockwork()
    {
        agent.isStopped = true;
        //Debug.Log("Clockwork Started");

        // Enable exclamation to warn of attack, enable weapon
        yield return new WaitForSeconds(1);
        // Perform attack animation
        _animator.SetTrigger("Clockwork");
        yield return new WaitForSeconds(0.3f);
        //Debug.Log("Clockwork Ended");
        // Disable exclamation and weapon
        agent.isStopped = false;
    }
}
