using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private PlayerController pc;
    private float leftBound = -15;//左の限界

    private void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }   //プレイヤースクリプトを持ってきた  

    void Update()
    {
        if (!pc.gameOver) //プレイヤーがgame0verではないなら
            {
            //左に動かす
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            }

        //左に行き過ぎた、かつ、その行き過ぎたやつがObstacleなら
        if(transform.position.x< leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);//消す
        }
    }
}
