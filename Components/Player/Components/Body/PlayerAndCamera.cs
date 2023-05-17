using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAndCamera : MonoBehaviour
{
    [SerializeField] private Camera myCamera;
    private Vector3 offset;

    private Vector3 oldMousePosition;

    void Start()
    {
        offset = transform.position - myCamera.transform.position;
    }

    void Update()
    {
        CameraFollowMouse();

        myCamera.transform.position = transform.position - transform.forward * offset.z - transform.up * offset.y - transform.right * offset.x;
    }

    private void CameraFollowMouse() {
        Vector3 newMousePosition = Input.mousePosition;

        transform.Rotate(transform.up, newMousePosition.x - oldMousePosition.x);

        oldMousePosition = newMousePosition;
    }
}
