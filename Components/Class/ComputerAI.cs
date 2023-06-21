using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerAI : Character
{
    public override void Attack() {
        currentTarget.GetComponent<Character>().TakeDamage((int)AttackDamage);
    }

    public override void IsDead() {
        gameObject.SetActive(false);
    }

}
