using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = -10;
    Vector3 velocity;
    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent <CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);

         //Debug.Log(velocity.y);
        //Debug.DrawLine(transform.position, transform.position + Vector3.down * 2.4f);
        if (!Physics.Raycast(transform.position, Vector3.down, 1.4f))
        {
            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity); 
        }
        else
        {
            velocity.y = 0;
        }
    }
}
