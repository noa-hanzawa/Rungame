using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 30;
    private PlayerController pc;
    private float leftBound = -15;//���̌��E

    private void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
    }   //�v���C���[�X�N���v�g�������Ă���  

    void Update()
    {
        if (!pc.gameOver) //�v���C���[��game0ver�ł͂Ȃ��Ȃ�
            {
            //���ɓ�����
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            }

        //���ɍs���߂����A���A���̍s���߂������Obstacle�Ȃ�
        if(transform.position.x< leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);//����
        }
    }
}
