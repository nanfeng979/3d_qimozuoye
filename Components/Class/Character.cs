using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    protected float HP;
    protected float MaxHP;

    protected float AttackDamage;
    protected float AttackRange;
    protected float AttackTime;
    protected float AttackTimer;
    protected float ViewRange;
    protected GameObject currentTarget;

    public GameObject[] rival;
    public Image BloodVolumeBar;

    protected Rigidbody rb;
    public Animator anim;

    public void TakeDamage(int damage) {
        HP -= damage;
        // anim.SetTrigger("isBeAttacked");
    }

    public virtual void Attack() {}

    protected void SetBloodVolumeBar() {
        BloodVolumeBar.fillAmount = HP / MaxHP;
    }

    public virtual void IsDead() {}

    public float GetHP() {
        return HP;
    }

}
