using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;
    Vector2 p1; // 矢の中心座標
    Vector2 p2;　// プレイヤの中心座標
    Vector2 dir; // プレイヤから矢に向かうベクトル
    float d; // プレイヤから矢に向かうベクトルの長さ
    float r1 = 0.5f; // 矢の半径
    float r2 = 1.0f; // プレイヤの半径

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.1f, 0);

        if(transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        // 当たり判定
        p1 = transform.position;
        p2 = this.player.transform.position;
        dir = p1 - p2;
        d = dir.magnitude;

        if(d < r1 + r2)
        {
            // 監督スクリプトに矢とプレイヤーが衝突したことを伝える
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHP();

            //  衝突した場合は矢を消す
            Destroy(gameObject);
        }

    }
}
