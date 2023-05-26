using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;

    private float moveSpeed = 5.0f;
    private float jumpSpeed = 5.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(GameManager.Instance.GetGameStatus() == EGameStatus.Playing) {
            Move();
            Jump();
        }
    }

    private void Move() {
        if(Input.GetKey(KeyCode.W)) {
            rb.velocity = transform.forward * moveSpeed;
        } else if(Input.GetKey(KeyCode.S)) {
            rb.velocity = -transform.forward * moveSpeed;
        }
    }
    private void Jump() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            rb.velocity = Vector3.up * jumpSpeed;
        }
    }
}
