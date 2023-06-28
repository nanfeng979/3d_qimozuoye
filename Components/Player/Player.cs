using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public PlayerMove playerMove;
    public GameObject enemy;

    void Start()
    {
        HP = 300;
        MaxHP = 300;
        AttackDamage = 30;
        currentTarget = enemy;
    }

    void Update()
    {
        SetBloodVolumeBar();

        if(HP <= 0) {
            IsDead();
        }

        if(Input.GetMouseButtonDown(0) && !playerMove.isMove) {
            Attack();
        }

        if(playerMove.isMove) {
            Move(true);
        } else {
            Move(false);
        }
    }

    public override void Attack() {
        anim.SetTrigger("isAttack");
        Invoke(nameof(Damage), 0.8f);
    }

    public void Damage() {
        currentTarget.GetComponent<Character>().TakeDamage((int)AttackDamage);
    }

    private void Move(bool isMove) {
        anim.SetBool("isRun", isMove);
    }

    public override void IsDead()
    {
        Debug.Log("gameOver");
    }
}
