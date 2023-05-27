using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundsOverSpread : MonoBehaviour
{
    public GameObject EnvGround;
    public GameObject Ground;

    private int widthCount;
    private int heightCount;

    void Start()
    {
        widthCount = 40;
        heightCount = 40;

        OverSpread(4);
    }

    void Update()
    {
        
    }

    private void OverSpread(int len) {
        for(int i = -widthCount / 2; i < widthCount / 2; i++) {
            for(int j = -heightCount / 2; j < heightCount / 2; j++) {
                Instantiate(Ground, new Vector3(i * len, 0.1f, j * len), Quaternion.identity, EnvGround.transform);
            }
        }
    }
}
