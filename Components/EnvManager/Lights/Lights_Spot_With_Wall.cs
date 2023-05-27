using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights_Spot_With_Wall : MonoBehaviour
{
    public GameObject Wall_Father;
    private int wallChildrensCount;
    public GameObject light_spot;

    void Start()
    {
        wallChildrensCount = Wall_Father.transform.childCount;

        for (int i = 0; i < wallChildrensCount; i++) {
            GameObject lightGameObject = Instantiate(light_spot, new Vector3(0, 2, 1), Quaternion.identity, Wall_Father.transform.GetChild(i).transform);
            lightGameObject.transform.localPosition = new Vector3(0, 2, 1);
        }
    }

    void Update()
    {
        
    }
}
