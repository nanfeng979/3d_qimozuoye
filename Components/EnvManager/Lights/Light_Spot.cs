using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Spot : MonoBehaviour
{
    public GameObject Player;
    private Vector3 PlayerOldPos;
    private Vector3 PlayerNewPos;
    
    private Light _light;

    private bool isLeft;

    void Start()
    {
        PlayerOldPos = Player.transform.position;

        _light = GetComponent<Light>();

        if(gameObject.name == "Left") {
            isLeft = true;
        } else {
            isLeft = false;
        }

        _light.intensity = 0.0f;
    }

    void Update()
    {
        PlayerNewPos = Player.transform.position;


        if(Vector3.Distance(Player.transform.position, transform.position) > 8.0f) {
            return;
        }

        if(Mathf.Abs((Player.transform.forward - transform.forward).x) < 0.5f) {
            _light.intensity = 2.5f;
        }
        

        PlayerOldPos = PlayerNewPos;
    }
}
