using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pet : MonoBehaviour
{
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
    }

    public void isPlaying() {
        if(Input.GetMouseButtonDown(0)) {
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
