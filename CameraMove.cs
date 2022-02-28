using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public FloatingJoystick inputMove; //左画面JoyStick
    public float moveSpeed = 1.0f; //移動する速度
    private Vector2 player_pos;
    

    void Start()
    {
        
    }

    void Update()
    {
        player_pos = this.transform.position;
        player_pos.y = Mathf.Clamp(player_pos.y, 0f, 100f);
        //左スティックでの縦移動
        this.transform.position += this.transform.forward * inputMove.Vertical * moveSpeed * Time.deltaTime;
        //左スティックでの横移動
        this.transform.position += this.transform.right * inputMove.Horizontal * moveSpeed * Time.deltaTime;
     }
}
