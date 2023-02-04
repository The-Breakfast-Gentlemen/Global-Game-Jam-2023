using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float speed;
    private Vector2 _move;

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
}
