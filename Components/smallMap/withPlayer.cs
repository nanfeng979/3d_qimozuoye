using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 用于管理小地图。
public class withPlayer : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        // 始终观察玩家的正上方位置
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
    }
}
