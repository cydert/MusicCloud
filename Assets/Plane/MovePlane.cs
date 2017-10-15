using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlane : MonoBehaviour {
    private Rigidbody rigid;
    Vector3 angleSpeed = new Vector3(0, 10, 0);//回転速度
    // Use this for initialization
    void Start () {
        rigid = GetComponent<Rigidbody>();


    }
	
	// Update is called once per frame
	void Update () {
        //十字キー
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            //上
            Debug.Log("up");

        }
        else if (0 < Input.GetAxisRaw("Vertical"))
        {
            //下
            Debug.Log("down");
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            //左
            Debug.Log("left");
        }
        else if (0 < Input.GetAxisRaw("Horizontal"))
        {
            //右
            Debug.Log("right");
        }

        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Fire1");
            //rigidbody.AddForce(Vector3.forward * 1000f * Time.deltaTime, ForceMode.Force);
            /*
            Vector3 v = GetComponent<Rigidbody>().velocity;//現在の速度を取得
            Vector3 cro = Vector3.Cross(v, angleSpeed);
            rigid.AddForce(cro);*/
            transform.Rotate(0, Time.deltaTime * 360, 0);
        }

        if (Input.GetButton("PowerUp"))
        {
            rigid.AddForce(Vector3.forward * 100f * Time.deltaTime, ForceMode.Impulse);   //瞬間速度UP
        }
    }
}
