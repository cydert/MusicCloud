using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSc : MonoBehaviour {
    public GameObject bulletIns;    //銃弾のインスタンス
    public GameObject bulletPosR;   //発射場所
    public GameObject bulletPosL;

    private int speed = 8;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            FireR();
        }

        if (Input.GetButton("Fire2"))
        {
            FireL();
        }
    }
    public void setSpeed(int speed)
    {
        this.speed = speed;
    }

    public void FireR()
    {
        Quaternion rote = Quaternion.Euler(90.0f, 0.0f, 0.0f);
        GameObject bullet = Instantiate(bulletIns, bulletPosR.transform.position, rote);   //インスタンス化
        Rigidbody buRigid = bullet.GetComponent<Rigidbody>();    //発射
        buRigid.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    public void FireL()
    {
        Quaternion rote = Quaternion.Euler(90.0f, 0.0f, 0.0f);
        GameObject bullet = Instantiate(bulletIns, bulletPosL.transform.position, rote);   //インスタンス化
        Rigidbody buRigid = bullet.GetComponent<Rigidbody>();    //発射
        buRigid.AddForce(transform.forward * speed, ForceMode.Impulse);
    }
}
