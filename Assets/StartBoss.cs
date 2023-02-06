using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBoss : MonoBehaviour
{
    public GameObject boss;
    public GameObject weapon;
    public GameObject door;
    public AudioSource music;
    public AudioClip bossClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            music.clip = bossClip;
            music.Play();
            boss.SetActive(true);
            weapon.SetActive(true);
            door.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
