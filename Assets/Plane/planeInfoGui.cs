using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityStandardAssets.Vehicles.Aeroplane;
using UnityEditor;

public class planeInfoGui : MonoBehaviour {

    public GUIStyle infoStyle;
    public GUIStyle warningStyle;

    public AudioSource hitSound;

    private bool stall; //失速

    AeroplaneController m_Aeroplane;    //飛行機情報(スクリプト)

	// Use this for initialization
	void Start () {
        m_Aeroplane = GetComponent<AeroplaneController>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnGUI()
    {
        string[] screenres = UnityStats.screenRes.Split('x');
        int width = int.Parse(screenres[0]);
        int height = int.Parse(screenres[1]);
        GUI.Label(new Rect(width - 180, height - 120, 180, 120), "スロットル\n" + m_Aeroplane.Throttle*100+"%\n"+ "速度\n" + m_Aeroplane.ForwardSpeed, infoStyle);
        GUI.Label(new Rect(0 ,0,100,50), "得点\n"+GameInfoSc.score, infoStyle);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Ring")
        {
            Ring ringSc = col.GetComponent<Ring>();
            if (!ringSc.hit) {
                ringSc.hit = true;
                GameInfoSc.AddRingScore();
                Destroy(col.gameObject);
                hitSound.Play();
            }
        }
    }
}
