using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySc : MonoBehaviour {
    private int hp = 7;
    private int ONE_BULLET = 5;
    private int nowBullet;
    private int reloadTime = 3;
    private int bulletSpace = 1;
    private Timer timer;
    private Timer spaceTimer;
    private FireSc fireSc;

	// Use this for initialization
	void Start () {
        nowBullet = ONE_BULLET;
        timer = Timer.Run();
        spaceTimer = Timer.Run();
        fireSc = gameObject.GetComponent<FireSc>();
        fireSc.enemyMode = true;
        GameObject bulletPosR = gameObject.transform.Find("bulletEnemyPosR").gameObject;
        GameObject bulletPosL = gameObject.transform.Find("bulletEnemyPosL").gameObject;
        fireSc.setBulletPos(bulletPosR, bulletPosL);
    }
	
	// Update is called once per frame
	void Update () {
		if(nowBullet == 0)
        {
            if (timer.IsStart())    //タイマー動作中か
            {
                if (timer.IsEnd())
                {
                    nowBullet = ONE_BULLET;  //補給
                    timer.Stop();
                }
            }
            else
            {
                timer.Start(reloadTime);    //タイマースタート
            }
        }else
        {
            //銃弾発射
            if (spaceTimer.IsEndStop())
            {
                fireSc.FireL(2, 30);
                spaceTimer.Start(bulletSpace);
                nowBullet--;
            }
        }
	}

    void setOneMaxBullet(int cnt)
    {
        ONE_BULLET = cnt;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Fire")
        {
            hp--;
            if(hp == 0)
            {
                Destroy(timer);
                Destroy(spaceTimer);
                Destroy(gameObject);
            }
        }
    }
}
