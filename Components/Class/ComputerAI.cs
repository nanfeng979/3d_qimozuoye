using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerAI : MonoBehaviour
{
    protected int HP;
    protected int AttackDamage;
    protected float AttackRange;
    protected float AttackTime;
    protected float AttackTimer;
    protected float ViewRange;

    public GameObject[] rival;

    protected Rigidbody rb;
    protected Animator anim;
}
