using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public FloatingJoystick inputMove; //�����JoyStick
    public float moveSpeed = 1.0f; //�ړ����鑬�x
    private Vector2 player_pos;
    

    void Start()
    {
        
    }

    void Update()
    {
        player_pos = this.transform.position;
        player_pos.y = Mathf.Clamp(player_pos.y, 0f, 100f);
        //���X�e�B�b�N�ł̏c�ړ�
        this.transform.position += this.transform.forward * inputMove.Vertical * moveSpeed * Time.deltaTime;
        //���X�e�B�b�N�ł̉��ړ�
        this.transform.position += this.transform.right * inputMove.Horizontal * moveSpeed * Time.deltaTime;
     }
}
