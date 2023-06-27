using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Spot : MonoBehaviour
{
    public GameObject Player;
    
    private Light _light;

    void Start()
    {
        // 将所有灯光亮度调为0。
        _light = GetComponent<Light>();
        _light.intensity = 0.0f;
    }

    void Update()
    {
        // 当玩家接近时，灯光亮度调高。
        if(Vector3.Distance(Player.transform.position, transform.position) < 8.0f) {
            _light.intensity = 2.5f;
        }
    }
}
