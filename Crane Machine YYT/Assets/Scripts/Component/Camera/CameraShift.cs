using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShift : MonoBehaviour
{
    [SerializeField] private Transform CameraTransform;
    [Space(20)]
    [SerializeField] private Transform CameraLeftTransform;
    [SerializeField] private Transform CameraMiddleTransform;
    [SerializeField] private Transform CameraRightTransform;

    public void ShiftCameraToLeft()
    {
        CameraTransform.position = CameraLeftTransform.position;
        CameraTransform.rotation = CameraLeftTransform.rotation;
    }

    public void ShiftCameraToMiddle()
    {
        CameraTransform.position = CameraMiddleTransform.position;
        CameraTransform.rotation = CameraMiddleTransform.rotation;
    }

    public void ShiftCameraToRight()
    {
        CameraTransform.position = CameraRightTransform.position;
        CameraTransform.rotation = CameraRightTransform.rotation;
    }
}
