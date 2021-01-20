using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public AudioClip pickUpClip;

    public virtual void Picked()
    {
    }

    public void Rotation()
    {
        transform.RotateAround(Vector3.up, 0.05f);
       // transform.Rotate(new Vector3(0, 5, 0));
    }
}
