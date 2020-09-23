using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody rd;
    public int force = 5;
    private int score = 0;
    public Text text;
    public GameObject winText;
        
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");//得到水平轴的值
        float v = Input.GetAxis("Vertical");
        rd.AddForce(new Vector3(h,0,v)*force);//*5将向量增大，增大速度
    }

    //碰撞检测
    void OnCollisionEnter(Collision collision)//coliision事碰撞到的对象
    {
        //collision.collider//获取碰撞物体的collider组件
        //string name = collision.collider.name; //获取碰撞物体的collider组件的名字
        //print(name);
        if (collision.collider.tag == "Pick")
        {
            Destroy(collision.collider.gameObject);
        }
    }
    //触发检测
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pick")
        {
            Destroy(other.gameObject);
            score++;
            text.text = score.ToString();
            if (score == 7)
            {
                winText.SetActive(true);
            }
        }
    }
}
