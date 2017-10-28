using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityStandardAssets.Vehicles.Aeroplane;
using UnityEditor;

public class planeInfoGui : MonoBehaviour {

    public GUIStyle infoStyle;
    public GUIStyle warningStyle;

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
        Debug.Log(UnityStats.screenRes);
        GUI.Label(new Rect(width - 200, height - 130, 200, 130), "スロットル\n" + m_Aeroplane.Throttle*100+"%\n"+ "速度\n" + m_Aeroplane.ForwardSpeed, infoStyle);
        //GUI.Label(new Rect(width-200 ,height-100,200,100), "速度\n"+m_Aeroplane.ForwardSpeed, infoStyle);

    }
}
