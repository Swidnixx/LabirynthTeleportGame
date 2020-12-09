using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public virtual void Picked()
    {
    }

    public void Rotation()
    {
        transform.RotateAround(Vector3.up, 0.5f);
       // transform.Rotate(new Vector3(0, 5, 0));
    }
}
