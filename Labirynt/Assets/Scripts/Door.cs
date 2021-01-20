using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform closePosition;
    public Transform openPosition;
    public Transform door;

    public bool open = false;
    public float closingSpeed = 5;

    public void OpenClose()
    {
        open = !open;
    }

    // Start is called before the first frame update
    void Start()
    {
        door.position = closePosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!open && Vector3.Distance(door.position, closePosition.position) > 0.01f)
        {
            door.position = Vector3.MoveTowards(door.position, closePosition.position, Time.deltaTime * closingSpeed); 
        }

        if (open && Vector3.Distance(door.position, openPosition.position) > 0.01f)
        {
            door.position = Vector3.MoveTowards(door.position, openPosition.position, Time.deltaTime * closingSpeed);
        }
    }


}
