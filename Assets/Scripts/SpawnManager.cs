using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePerfab;
    private Vector3 spawnPos = new Vector3(25,0,0);
    private float startDelay = 2;//遅延
    private float repeatRate = 2;//繰り返し時間
    private PlayerController pc;

    void Start()
    {
        InvokeRepeating("SpawnObstacle",startDelay,repeatRate);
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    //スポーンする処理のまとまり
    void SpawnObstacle()
    {
        if (!pc.gameOver)
        {
            Instantiate(obstaclePerfab,spawnPos,obstaclePerfab.transform.rotation);
        }
        
    }
}
