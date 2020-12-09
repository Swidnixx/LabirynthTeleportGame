using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{

    public Door[] doors;
    public KeyColor myColor;
    bool locked = false;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void UseKey()
    {
        foreach(Door d in doors)
        {
            d.OpenClose();
        }
    }

    bool iCanOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            iCanOpen = true;
            Debug.Log("You can use a Key");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            iCanOpen = false;
            Debug.Log("You can not use a Key");
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
