using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Spot : MonoBehaviour
{
    public GameObject Player;
    private Light _light;

    void Start()
    {
        _light = GetComponent<Light>();
    }

    void Update()
    {
        if(Player.transform.position.z >= transform.position.z - 2) {
            _light.enabled = true;
        } else {
            _light.enabled = false;
        }
    }
}
