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
    void Start()
    {
        HP = 100;
        MaxHP = 100;
    }

    void Update()
    {
        SetBloodVolumeBar();
    }
}
