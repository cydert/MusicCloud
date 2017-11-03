using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityStandardAssets.Vehicles.Aeroplane;
using UnityEditor;
using UnityEngine.SceneManagement;

public class planeInfoGui : MonoBehaviour {

    public GUIStyle infoStyle;
    public GUIStyle warningStyle;
    public GUIStyle finalStyle;

    public AudioSource hitSound;

    private bool stall; //失速
    public static int hp; //体力
    private bool noDamage = false;
    private float noTime = 0.5f; //無敵時間
    private Timer noDamageT;

    bool end = true;   //終了
    bool succ = false;  //成功
    int finalScore = -1;
    Timer endTimer;

    AeroplaneController m_Aeroplane;    //飛行機情報(スクリプト)

	// Use this for initialization
	void Start () {
        m_Aeroplane = GetComponent<AeroplaneController>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (noDamageT !=null && noDamageT.IsStart())
        {
            if (noDamageT.IsEndStop())
            {
                noDamage = false;
                noDamageT.Del();
            }
        }
    }

    void OnGUI()
    {
        string[] screenres = UnityStats.screenRes.Split('x');
        int width = int.Parse(screenres[0]);
        int height = int.Parse(screenres[1]);
        GUI.Label(new Rect(width - 180, height - 120, 180, 120), "スロットル\n" + m_Aeroplane.Throttle*100+"%\n"+ "速度\n" + m_Aeroplane.ForwardSpeed, infoStyle);
        GUI.Label(new Rect(0 ,0,100,50), "得点:"+GameInfoSc.score+"\n体力:"+hp, infoStyle);
        if (end)
        {
            if (finalScore == -1) finalScore = GameInfoSc.score;
            if (succ)
            {
                GUI.Label(new Rect(width / 2 - 80, height / 2 - 20, 100, 50), "クリア\n" + GameInfoSc.score, finalStyle);
            }else
            {
                GUI.Label(new Rect(width / 2 - 80, height / 2 - 20, 100, 50), "失敗\n" + GameInfoSc.score+"点", finalStyle);
            }
            if (endTimer == null || !endTimer.IsStart()) {
                endTimer = Timer.Run();
                endTimer.Start(5);
            }else if (endTimer.IsEndStop())
            {

                SceneManager.LoadSceneAsync("Menu");
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Ring")
        {
            Ring ringSc = col.GetComponent<Ring>();
            if (!ringSc.hit)
            {
                ringSc.hit = true;
                GameInfoSc.AddRingScore();
                Destroy(col.gameObject);
                hitSound.Play();
            }
        }
        else if (col.tag == "Fire")
        {
            Destroy(col.gameObject);
            if (!noDamage)
            {
                hp--;
                noDamageT = Timer.Run();
                noDamage = true;
                noDamageT.Start(noTime);
            }
            if (hp <= 0)
            {

                end = true;
            }

            
        }
    }
}
