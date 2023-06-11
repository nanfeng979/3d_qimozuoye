using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerAI : MonoBehaviour
{
    protected int HP;
    protected int MaxHP;
    protected int AttackDamage;
    protected float AttackRange;
    protected float AttackTime;
    protected float AttackTimer;
    protected float ViewRange;

    public GameObject[] rival;
    public Image BloodVolumeBar;

    protected Rigidbody rb;
    protected Animator anim;

    protected void Attack(GameObject target, int damage) {
        target.GetComponent<ComputerAI>().TakeDamage(damage);
    }

    protected void TakeDamage(int damage) {
        HP -= damage;
    }

    protected void SetBloodVolumeBar() {
        BloodVolumeBar.fillAmount = HP / MaxHP;
    }

}
