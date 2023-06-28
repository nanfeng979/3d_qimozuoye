using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerAI : Character
{
    public virtual void StandState() {}

    public virtual void MoveState() {}

    public virtual void ChasingState() {}

    public virtual void AttackState() {}

    public virtual void BackState() {}

    public override void Attack() {
        currentTarget.GetComponent<Character>().TakeDamage((int)AttackDamage);
    }

    public override void IsDead() {
        gameObject.SetActive(false);
    }

}
