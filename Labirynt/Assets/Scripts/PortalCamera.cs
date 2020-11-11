using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{

    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;
    float myAngle;

    public void SetMyAngle(float angle)
    {
        myAngle = angle;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffsetFromPortal = playerCamera.position -
            otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;

        float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        if (myAngle == 90 || myAngle == 290)
        {
            angularDifferenceBetweenPortalRotations -= 90;
        }

        Quaternion portalRotationDifference = Quaternion.AngleAxis(
            angularDifferenceBetweenPortalRotations, Vector3.up);

        Vector3 newCameraRotation = portalRotationDifference * playerCamera.forward;

        if(myAngle == 90 || myAngle == 270)
        {
            newCameraRotation = new Vector3(newCameraRotation.z * -1, newCameraRotation.y, newCameraRotation.x);
            transform.rotation = Quaternion.LookRotation(newCameraRotation, Vector3.up);
        }
        else
        {
            newCameraRotation = new Vector3(newCameraRotation.x * -1, newCameraRotation.y, newCameraRotation.z);
            transform.rotation = Quaternion.LookRotation(newCameraRotation, Vector3.up);
        }
    }
}
