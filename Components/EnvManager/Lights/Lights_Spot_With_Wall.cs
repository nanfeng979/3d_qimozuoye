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
        // 得到所有的墙壁对象。
        wallChildrensCount = Wall_Father.transform.childCount;

        // 为每个墙壁添加灯光，并且固定好方位。
        for (int i = 0; i < wallChildrensCount; i++) {
            GameObject lightGameObject = Instantiate(light_spot, new Vector3(0, 2, 1), Quaternion.identity, Wall_Father.transform.GetChild(i).transform);
            lightGameObject.transform.localPosition = new Vector3(0, 2, 1);
        }
    }

}
