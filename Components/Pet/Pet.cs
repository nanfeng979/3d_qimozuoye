using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// 宠物的状态枚举
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
        anim = GetComponent<Animator>();
        moveSpeed = 7.0f;

        HP = 100;
        MaxHP = 100;
        AttackDamage = 10;
        AttackRange = 3;
        AttackTime = 2.5f;
        ViewRange = 6;
        AttackTimer = AttackTime;

        petstate = PetState.stand;
    }

    void Update()
    {
        // 实时更新血量UI。
        SetBloodVolumeBar();

        if(HP <= 0) {
            IsDead();
        }

        // 宠物的智能行为的有限状态机。
        switch (petstate) {
            case PetState.stand:
                StandState();
                break;
            case PetState.move:
                MoveState();
                break;
            case PetState.chasing:
                ChasingState();
                break;
            case PetState.attack:
                AttackState();
                break;
            case PetState.back:
                BackState();
                break;
        }
    }

    private void StandState() {
        if(player.GetComponent<PlayerMove>().isMove) {
            petstate = PetState.move;
        }

        for(int i = 0; i < rival.Length; i++) {
            if(Vector3.Distance(transform.position, rival[i].transform.position) <= ViewRange) {
                petstate = PetState.chasing;
                currentTarget = rival[i];
            }
        }

        // transform.position = player.transform.position + player.transform.forward * 2.0f + player.transform.right * 2.0f;
        rb.velocity = Vector3.zero;
        transform.rotation = player.transform.rotation;
    }

    private void MoveState() {
        if(!player.GetComponent<PlayerMove>().isMove) {
            petstate = PetState.back;
        }

        for(int i = 0; i < rival.Length; i++) {
            if(Vector3.Distance(transform.position, rival[i].transform.position) <= ViewRange) {
                petstate = PetState.chasing;
                currentTarget = rival[i];
            }
        }

        rb.velocity = transform.forward * moveSpeed;

        // transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.1f);
    }

    private void ChasingState() {
        if(Vector3.Distance(transform.position, currentTarget.transform.position) > ViewRange) {
            petstate = PetState.back;
        }

        if(Vector3.Distance(transform.position, currentTarget.transform.position) <= AttackRange) {
            petstate = PetState.attack;
        }

        rb.velocity = Vector3.zero;
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, 0.1f);
        transform.LookAt(currentTarget.transform);
    }

    private void AttackState() {
        if(Vector3.Distance(transform.position, currentTarget.transform.position) > AttackRange) {
            petstate = PetState.chasing;
        }


        rb.velocity = Vector3.zero;
        transform.LookAt(currentTarget.transform);

        AttackTimer += Time.deltaTime;
        if(AttackTimer >= AttackTime) {
            anim.SetTrigger("isAttack");
            AttackTimer -= AttackTime;
        }
    }

    private void BackState() {
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
