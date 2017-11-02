using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MainSc : MonoBehaviour {
    public GUIStyle infoStyle;

    private string[] musicList = { "Flight Sound", "メルト" };
    private int selectNum = 0;

    bool isInput = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    void FixedUpdate()
    {
        float roll = CrossPlatformInputManager.GetAxis("Horizontal");

        if (isInput)
        {
            if (roll < 0.9 && roll > -0.9)
                isInput = false;
        } else {
            if (roll > 0.9) //右
            {
                isInput = true;
                selectNum = selectNumNext(selectNum + 1);
            }
            else if(roll < -0.9)
            {
                isInput = true;
                selectNum = selectNumNext(selectNum - 1);
            }
        }
    }

    private int selectNumNext(int num)
    {
        return Mathf.Abs(num % musicList.Length);
    }

    void OnGUI()
    {

        string[] screenres = UnityStats.screenRes.Split('x');
        int width = int.Parse(screenres[0]);
        int height = int.Parse(screenres[1]);
        GUI.Label(new Rect(width / 2 - 80, height / 3-50 , 80, 120), "Sound Cloud", infoStyle);
        GUI.Label(new Rect(width / 2 - 80, height / 2+100 , 80, 120), "曲選択\n<ー  "+musicList[selectNum] +"  ー>", infoStyle);

    }
}
