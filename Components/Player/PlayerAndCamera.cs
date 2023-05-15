using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAndCamera : MonoBehaviour
{
    [SerializeField] private Camera myCamera;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - myCamera.transform.position;
    }

    void Update()
    {
        myCamera.transform.position = transform.position - transform.forward * offset.z - transform.up * offset.y - transform.right * offset.x;
    }
}
