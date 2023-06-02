using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePerfab;
    private Vector3 spawnPos = new Vector3(25,0,0);
    private float startDelay = 2;//�x��
    private float repeatRate = 2;//�J��Ԃ�����
    private PlayerController pc;

    void Start()
    {
        InvokeRepeating("SpawnObstacle",startDelay,repeatRate);
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    //�X�|�[�����鏈���̂܂Ƃ܂�
    void SpawnObstacle()
    {
        if (!pc.gameOver)
        {
            Instantiate(obstaclePerfab,spawnPos,obstaclePerfab.transform.rotation);
        }
        
    }
}
