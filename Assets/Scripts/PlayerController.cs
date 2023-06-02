using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb; //�d�͂Ƃ��̂��
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround=true;
    public bool gameOver = false;//�ŏ��̓Q�[���I�[�o�[�ł͂Ȃ�
    private Animator playerAnim;//�A�j���[�^�[

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        Physics.gravity*=gravityModifier; //�d�͒���
        playerAnim = GetComponent<Animator>();//�A�j���[�^�[�Q�b�g
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector3.up * jumpForce,
                        ForceMode.Impulse); //��
            isOnGround=false;//�n�ʂ��痣�ꂽ
            playerAnim.SetTrigger("Jump_trig");//�W�����v����A�j���Đ�

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))//�v���C���[���Ԃ��������肪Ground�Ȃ�
        {
            isOnGround = true;//�n�ʂɂ��邱�Ƃɂ���
        }
        else if (collision.gameObject.CompareTag("Obstacle"))//�v���C���[���Ԃ��������肪Obstacle�Ȃ�
        {
            gameOver = true;//�Q�[���I�[�o�[�ɂ���
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",1);
        }
    }
}
