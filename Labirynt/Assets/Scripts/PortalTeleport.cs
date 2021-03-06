﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform player;
    public Transform recieverPortal;

    private bool playerIsOverlapping = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerIsOverlapping)
        {
            Vector3 portalToPlayerDistance = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayerDistance);
            

            if (dotProduct < 0f)
            {
                float rotationDiff = -Quaternion.Angle(transform.rotation, recieverPortal.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayerDistance;
                player.position = recieverPortal.position + positionOffset;
                playerIsOverlapping = false;

            }
        }

    }

    void Update()
    {
        //Debug.Log("Portal: " + transform.position + " ... Docelowo: " + new Vector3(0, transform.position.y + 3, 0));
        Debug.DrawLine(transform.position, transform.position + Vector3.up*3);
        Debug.DrawLine(transform.position, player.position);
        Vector3 portalToPlayerDistance = player.position - transform.position;
        float dotProduct = Vector3.Dot(transform.up, portalToPlayerDistance);
        //Debug.Log("Dot: " + dotProduct);
    }
}
