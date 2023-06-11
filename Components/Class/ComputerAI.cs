using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerAI : MonoBehaviour
{
    public int HP;
    public int AttackDamage;
    public float AttackRange;
    public float ViewRange;

    public GameObject[] rival;

    protected Rigidbody rb;
}
