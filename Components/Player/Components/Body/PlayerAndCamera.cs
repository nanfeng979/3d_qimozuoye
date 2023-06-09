using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 用于管理摄像机的位置。
public class PlayerAndCamera : MonoBehaviour
{
    [Range(1.0f, 10.0f)]
    public float CameraFollowSpeed;

    [SerializeField] private Camera myCamera;
    private Vector3 offset;

    private Vector3 newMousePosition;
    private Vector3 oldMousePosition;
    

    void Start()
    {
        offset = transform.position - myCamera.transform.position;
    }

    public void isPlaying() {
        newMousePosition = Input.mousePosition;
        
        if(Input.GetKey(KeyCode.Tab)) {
            
        } else {
            CameraFollowMouse();
        }
        
        oldMousePosition = newMousePosition;
        myCamera.transform.position = transform.position - transform.forward * offset.z - transform.up * offset.y - transform.right * offset.x;
    }

    private void CameraFollowMouse() {
        
        float cameraFollowSpeed = CameraFollowSpeed * (newMousePosition.x - oldMousePosition.x) / 10;

        transform.Rotate(transform.up, cameraFollowSpeed);
    }
}
