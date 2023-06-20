using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyState {
    stand,
    chasing,
    attack,
    back
}

public class Enemy : ComputerAI
{

    private EnemyState enemyState;

    void Start()
    {
        anim = GetComponent<Animator>();

        HP = 100;
        MaxHP = 100;
        AttackDamage = 30;
        AttackRange = 2.0f;
        AttackTime = 2.0f;
        ViewRange = 3.5f;
        AttackTimer = AttackTime;

        enemyState = EnemyState.stand;
    }

    void Update()
    {
        SetBloodVolumeBar();
        currentTarget = FindNearestRival();

        if(HP <= 0) {
            IsDead();
        }

        switch (enemyState) {
            case EnemyState.stand:
                StandState();
                break;
            case EnemyState.chasing:
                ChasingState();
                break;
            case EnemyState.attack:
                AttackState();
                break;
            case EnemyState.back:
                BackState();
                break;
        }
    }

    private void RestoreHP() {
        HP += 3;
    }

    private GameObject FindNearestRival() {
        for(int i = 0; i < rival.Length; i++) {
            if(Vector3.Distance(transform.position, rival[i].transform.position) <= ViewRange) {
                if(!rival[i].transform.gameObject.activeSelf) continue;

                return rival[i];
            }
        }
        
        return null;
    }

    private void StandState() {
        anim.SetBool("isAttack", false);


        if(currentTarget != null) {
            enemyState = EnemyState.chasing;
        }


        if(HP < MaxHP) {
            Invoke(nameof(RestoreHP), 1.0f);
        } else {
            HP = MaxHP;
        }
    }
    
    private void ChasingState() {
        if(currentTarget == null) {
            enemyState = EnemyState.back;
        }

        if(Vector3.Distance(transform.position, currentTarget.transform.position) <= AttackRange) {
            enemyState = EnemyState.attack;
        }

        transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, 0.03f);
        transform.LookAt(currentTarget.transform);
    }

    private void AttackState() {
        if(currentTarget == null) {
            enemyState = EnemyState.stand;
            return;
        }


        transform.LookAt(currentTarget.transform);

        AttackTimer += Time.deltaTime;
        if(AttackTimer >= AttackTime) {
            anim.SetBool("isAttack", true);
            AttackTimer -= AttackTime;
        }
    }

    private void BackState() {

    }

}
