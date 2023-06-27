using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights_Spot : MonoBehaviour
{
    public GameObject Env_Lights_Spot;
    public GameObject Light_Spot;
    
    private int len = 10;

    void Start()
    {
        // 用脚本实现自动创建灯光。
        for(int i = 0; i < len; i++) {
            Instantiate(Light_Spot, new Vector3(3.5f, 1.5f, i * 4), Quaternion.identity, Env_Lights_Spot.transform);
            Instantiate(Light_Spot, new Vector3(-3.5f, 1.5f, i * 4), Quaternion.identity, Env_Lights_Spot.transform);
        }
    }

}
