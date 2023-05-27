using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public GameObject EnvWalls;
    public GameObject Wall;

    private int len = 10;

    void Start()
    {
        for(int i = 0; i < len; i++) {
            GameObject Wall_left = Instantiate(Wall, new Vector3(-4, 0, i * 4), Quaternion.identity, EnvWalls.transform);
            Wall_left.transform.Rotate(0, 90, 0);

            GameObject Wall_right = Instantiate(Wall, new Vector3(4, 0, i * 4), Quaternion.identity, EnvWalls.transform);
            Wall_right.transform.Rotate(0, -90, 0);
            
        }   
    }

    void Update()
    {
        
    }
}
