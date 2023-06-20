using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerAI : MonoBehaviour
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
    protected Animator anim;

    public void Attack() {
        currentTarget.GetComponent<ComputerAI>()?.TakeDamage((int)AttackDamage);
    }

    protected void TakeDamage(int damage) {
        HP -= damage;
    }

    protected void SetBloodVolumeBar() {
        BloodVolumeBar.fillAmount = HP / MaxHP;
    }

    protected void IsDead() {
        gameObject.SetActive(false);
    }

}
