using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody rb;

    private float moveSpeed = 5.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Rotate();
    }

    private void Move() {
        if(Input.GetKey(KeyCode.W)) {
            rb.velocity = transform.forward * moveSpeed;
        } else if(Input.GetKey(KeyCode.S)) {
            rb.velocity = -transform.forward * moveSpeed;
        }
    }

    private void Rotate() {
        if(Input.GetKeyDown(KeyCode.Q)) {
            StartCoroutine(RotateCoroutine(-30));
        } else if(Input.GetKeyDown(KeyCode.E)) {
            StartCoroutine(RotateCoroutine(30));
        }
    }

    IEnumerator RotateCoroutine(float angle) {
        float time = 0;
        while(time < 1.0f) {
            time += Time.deltaTime;
            transform.Rotate(0, angle * Time.deltaTime, 0);
            yield return null;
        }
    }
}
