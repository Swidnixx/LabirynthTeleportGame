using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUp
{
    public KeyColor color;

    public override void Picked()
    {
        GameManager.gameManager.PlayClip(pickUpClip);
        GameManager.gameManager.AddKey(color);
        Destroy(this.gameObject);
    }


    void Update()
    {
        Rotation();
    }
}
