using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHand : MonoBehaviour
{
    [SerializeField] private Transform rightHandPosition;
    [SerializeField] private Animator anim;

    private bool canWave = true;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            if(!canWave) {
                return;
            }

            canWave = false;
            anim.SetTrigger("IsWaving");
        }
    }

    public void canWaing() {
        canWave = true;
    }

    
}
