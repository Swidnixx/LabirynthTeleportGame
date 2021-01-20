using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = -10;
    public Transform groundCheck;
    public LayerMask groundMask;

    bool isGrounded;
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


        isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);
        //Debug.DrawLine(transform.position, transform.position + Vector3.down * 2.4f);
        if (!isGrounded)
        {
            if (velocity.y > gravity)
            {
                velocity.y += gravity * Time.deltaTime; 
            }else
            {
                velocity.y = gravity;
            }

            characterController.Move(velocity * Time.deltaTime); 
        }
        else
        {
            velocity.y = 0;
        }

        RaycastHit hit;
        if(Physics.Raycast(groundCheck.position, Vector3.down, out hit, 0.4f, groundMask))
        {
            string terrainTag = hit.collider.gameObject.tag;
            switch(terrainTag)
            {
                default:
                    speed = 12;
                    break;

                case "Slow":
                    speed = 3;
                    break;

                case "Fast":
                    speed = 20;
                    break;
            }
        }
    }


    private void OnTriggerEnter(Collider hit)
    {
        Debug.Log("test");
        if(hit.gameObject.tag == "PickUp")
        {
            hit.gameObject.GetComponent<PickUp>().Picked();
        }
    }
}
