using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;
    private NavMeshAgent agent;

    private float moveSpeed = 5.0f;
    private float jumpSpeed = 5.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

    }

    public void isPlaying() {
        Move();
        Jump();
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
