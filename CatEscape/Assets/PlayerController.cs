using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 左ボタンが押された時
    public void LButtonDown()
    {
        transform.Translate(-3, 0, 0);
    }

    // 右ボタンが押された時
    public void RButtonDown()
    {
        transform.Translate(3, 0, 0);
    }
}
