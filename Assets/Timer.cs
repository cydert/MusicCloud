using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    bool isStart = false;   //動作中か
    bool isEnd = true;      //終了してるか
    float setSec;           //指定時間
    private float nowTime;
    private static GameObject thisGameObject;

    public static Timer Run()
    {
        return thisGameObject.AddComponent<Timer>();
    }

	// Use this for initialization
	void Start () {
        thisGameObject = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (isStart)
        {
            nowTime += Time.deltaTime; //タイムを加算
            Debug.Log(nowTime);
            if (nowTime >= setSec)
            {
                nowTime = 0;
                //指定時間
                final();    //後処理
            }
        }
    }

    public bool Start(float sec)
    {
        if (isStart && !isEnd) return false;
        setSec = sec;
        init(); //初期化
        return true;
    }

    //指定時間になったか
    public bool IsEnd()
    {
        return isEnd;
    }

    //指定時間になったか
    public bool IsEndStop()
    {
        if (isEnd)
        {
            isStart = false;
            return true;
        }
        return false;
    }

    public bool IsStart()
    {
        return isStart;
    }

    private void init()
    {
        nowTime = 0;
        isEnd = false;
        isStart = true;
    }

    private void final()
    {
        nowTime = 0;
        isEnd = true;
    }

    public void Stop()
    {
        isStart = false;
    }

    public void Del()
    {
        Destroy(this);
    }
}
