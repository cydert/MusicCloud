using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySc : MonoBehaviour {
    private int ONE_BULLET = 5;
    private int nowBullet = 0;
    private int reloadTime = 3;
    private Timer timer;

	// Use this for initialization
	void Start () {
        timer = new Timer();
	}
	
	// Update is called once per frame
	void Update () {
		if(nowBullet == 0)
        {
            if (timer.IsStart())    //タイマー動作中か
            {
                if (timer.IsEnd()) nowBullet = ONE_BULLET;  //補給
            }
            else
            {
                timer.Start(reloadTime);    //タイマースタート
            }
        }else
        {
            //銃弾発射

        }
	}

    void setOneMaxBullet(int cnt)
    {
        ONE_BULLET = cnt;
    }
}
