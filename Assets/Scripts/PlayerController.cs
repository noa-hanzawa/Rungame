using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb; //重力とかのやつ
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround=true;
    public bool gameOver = false;//最初はゲームオーバーではない
    private Animator playerAnim;//アニメーター

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        Physics.gravity*=gravityModifier; //重力調節
        playerAnim = GetComponent<Animator>();//アニメーターゲット
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce,
                        ForceMode.Impulse); //力
            isOnGround=false;//地面から離れた
            playerAnim.SetTrigger("Jump_trig");//ジャンプするアニメ再生

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))//プレイヤーがぶつかった相手がGroundなら
        {
            isOnGround = true;//地面にいることにする
        }
        else if (collision.gameObject.CompareTag("Obstacle"))//プレイヤーがぶつかった相手がObstacleなら
        {
            gameOver = true;//ゲームオーバーにする
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",1);
        }
    }
}
