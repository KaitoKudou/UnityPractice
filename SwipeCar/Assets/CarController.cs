using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float speed = 0;
    float swipeLength; // スワイプした長さ
    Vector2 startPos; 
    Vector2 endPos;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
             // マウスをクリックした座標
            this.startPos = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            this.endPos = Input.mousePosition;
            this.swipeLength = this.endPos.x - this.startPos.x;
            //　スワイプの長さを初速度に変換
            this.speed = swipeLength / 500.0f;

            // 効果音再生
            GetComponent<AudioSource>().Play();
        }

        transform.Translate(this.speed, 0, 0);
        this.speed *= 0.98f;
    }
}
