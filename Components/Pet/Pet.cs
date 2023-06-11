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

public class Pet : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] monster;

    private NavMeshAgent agent;
    private PetState petstate;
    

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        petstate = PetState.stand;
    }

    void Update()
    {
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

        for(int i = 0; i < monster.Length; i++) {
            // if()
        }
    }

    private void Move() {

    }

    private void Chasing() {

    }

    private void Attack() {

    }

    private void Back() {

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
