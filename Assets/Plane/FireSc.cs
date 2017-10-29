using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSc : MonoBehaviour {
    public GameObject bulletIns;    //銃弾のインスタンス
    public GameObject bulletPosR;   //発射場所
    public GameObject bulletPosL;

    public bool enemyMode = false;
    private const float DEF_SIZE = 3;
    private int speed = 8;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!enemyMode)
        {
            if (Input.GetButton("Fire1"))
            {
                FireR();
            }

            if (Input.GetButton("Fire2"))
            {
                FireL();
            }
        }
    }

    public void setBulletPos(GameObject bulletR, GameObject bulletL)
    {
        bulletPosR = bulletR;
        bulletPosL = bulletL;
    }

    public void setSpeed(int speed)
    {
        this.speed = speed;
    }

    //銃弾発射
    public void FireR()
    {
        FireR(speed);
    }

    public void FireL()
    {
        FireL(speed);
    }

    public void FireR(float speed)
    {

        FireR(speed, DEF_SIZE);
    }

    public void FireL(float speed)
    {
        FireL(speed, DEF_SIZE);
    }

    public void FireR(float speed, float size)
    {
        Quaternion rote = Quaternion.Euler(90.0f, 0.0f, 0.0f);
        GameObject bullet = Instantiate(bulletIns, bulletPosR.transform.position, rote);   //インスタンス化
        bullet.transform.localScale = new Vector3(size, size, size);
        Rigidbody buRigid = bullet.GetComponent<Rigidbody>();    //発射
        buRigid.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    public void FireL(float speed, float size)
    {
        Quaternion rote = Quaternion.Euler(90.0f, 0.0f, 0.0f);
        GameObject bullet = Instantiate(bulletIns, bulletPosL.transform.position, rote);   //インスタンス化
        bullet.transform.localScale = new Vector3(size, size, size);
        Rigidbody buRigid = bullet.GetComponent<Rigidbody>();    //発射
        buRigid.AddForce(transform.forward * speed, ForceMode.Impulse);
    }
}
