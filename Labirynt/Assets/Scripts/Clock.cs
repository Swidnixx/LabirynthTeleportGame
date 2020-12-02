using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : PickUp
{
    public bool addTime;
    public uint time = 5;

    public override void Picked()
    {
        if (addTime)
            GameManager.gameManager.AddTime((int)time);
        else
            GameManager.gameManager.AddTime((int)time * (-1));

        Destroy(this.gameObject);
    }

    void Update()
    {
        Rotation();
    }
}
