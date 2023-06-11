using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum PetState {
    stand,
    move,
    chasing,
    attack,
    back
}

public class Pet : ComputerAI
{
    [SerializeField] private GameObject player;

    public float moveSpeed;

    private float withPlayerDistance = 50.0f;

    private NavMeshAgent agent;
    private PetState petstate;

    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        moveSpeed = 7.0f;

        HP = 100;
        AttackDamage = 30;
        AttackRange = 10;
        ViewRange = 20;

        petstate = PetState.stand;
    }

    void Update()
    {
        Debug.Log(petstate);
        switch(petstate) {
            case PetState.stand:
                Stand();
                break;
            case PetState.move:
                Move();
                break;
            case PetState.chasing:
                Chasing();
                break;
            case PetState.attack:
                Attack();
                break;
            case PetState.back:
                Back();
                break;
        }
    }

    private void Stand() {
        if(player.GetComponent<PlayerMove>().isMove) {
            petstate = PetState.move;
        }

        for(int i = 0; i < rival.Length; i++) {
            if(Vector3.Distance(transform.position, rival[i].transform.position) <= ViewRange) {
                petstate = PetState.chasing;
            }
        }

        // transform.position = player.transform.position + player.transform.forward * 2.0f + player.transform.right * 2.0f;
        rb.velocity = Vector3.zero;
        transform.rotation = player.transform.rotation;
    }

    private void Move() {
        if(!player.GetComponent<PlayerMove>().isMove) {
            petstate = PetState.back;
        }

        for(int i = 0; i < rival.Length; i++) {
            if(Vector3.Distance(transform.position, rival[i].transform.position) <= ViewRange) {
                petstate = PetState.chasing;
            }
        }

        rb.velocity = transform.forward * moveSpeed;

        // transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.1f);
    }

    private void Chasing() {
        for(int i = 0; i < rival.Length; i++) {
            if(Vector3.Distance(transform.position, rival[i].transform.position) > ViewRange) {
                petstate = PetState.back;
            }
        }

        for(int i = 0; i < rival.Length; i++) {
            if(Vector3.Distance(transform.position, rival[i].transform.position) <= AttackRange) {
                petstate = PetState.attack;
            }
        }
    }

    private void Attack() {
        for(int i = 0; i < rival.Length; i++) {
            if(Vector3.Distance(transform.position, rival[i].transform.position) > AttackRange) {
                petstate = PetState.chasing;
            }
        }
    }

    private void Back() {
        if(Vector3.Distance(transform.position, player.transform.position) < 3.0f) {
            petstate = PetState.stand;
        }

        // rb.velocity = (player.transform.position - transform.position).normalized * 1.0f;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position + player.transform.forward * 2.0f, 0.1f);
        transform.LookAt(player.transform.position);
    }

    public void isPlaying() {
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButtonDown(0)) {
            FollowMousePosition();
        }
    }

    private void FollowMousePosition() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit)) {
            agent.SetDestination(hit.point);
        }
    }
}
