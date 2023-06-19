using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMove playerMove;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !playerMove.isMove) {
            Attack();
        }

        if(playerMove.isMove) {
            Move(true);
        } else {
            Move(false);
        }
    }

    private void Attack() {
        Debug.Log("123");
        anim.SetTrigger("isAttack");
    }

    private void Move(bool isMove) {
        anim.SetBool("isRun", isMove);
    }
}
