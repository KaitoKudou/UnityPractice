using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 780.0f;
    float walkForce = 50.0f;
    float maxWalkSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //　ジャンプをする
        if((Input.GetKeyDown(KeyCode.Space)) && (this.rigid2D.velocity.y == 0))
        {
            
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpForce);

        }

        //左右移動
        int key = 0;
        if (Input.GetKeyDown(KeyCode.RightArrow)) key = 1;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) key = -1;

        //　プレイヤの速度
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        //  スピード制限
        if(speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        //　進む方向に応じて、プレイヤの向きを反転
        if(key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        // プレイヤ速度に応じてアニメーション速度を変える
        if(this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / speedx;
        }
        else
        {
            this.animator.speed = 1.0f;
        }
        

        // プレイヤが画面外に出た場合は最初から
        if(transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    // ゴールに到達
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Goal!!!");
        SceneManager.LoadScene("ClearScene");
    }
}
