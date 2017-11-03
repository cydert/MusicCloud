using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class MainSc : MonoBehaviour {
    public GUIStyle infoStyle;

    private string[] musicList = { "Flight Sound", "メルト" };
    private int selectNum = 0;
    private int nowLevel = 1;
    private int maxLevel = 3;

    bool isInput = false;
    bool isSelectMusic = true;
    bool isSelectDif = false;
    bool isLoading = false;
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
                if (isSelectMusic)
                    selectNum = selectNumNext(selectNum + 1);
                else if (isSelectDif)
                    nowLevel = fixNum(nowLevel+1, maxLevel);
            }
            else if(roll < -0.9)
            {
                isInput = true;
                if(isSelectMusic)
                    selectNum = selectNumNext(selectNum - 1);
                else if (isSelectDif)
                    nowLevel = fixNum(nowLevel-1, maxLevel);
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (isSelectMusic)  //音楽決定
            {
                isSelectMusic = false;
                isSelectDif = true;
            }else if (isSelectDif)
            {
                isSelectDif = false;
                isLoading = true;
                SceneManager.LoadSceneAsync("GameScene");

            }

        }
    }

    private int selectNumNext(int num)
    {
        return Mathf.Abs(num % musicList.Length);
    }

    private int fixNum (int num, int max){
        int ans = Mathf.Abs(num % max);
        if (ans == 0) return max;
        return ans;
    }

    void OnGUI()
    {

        string[] screenres = UnityStats.screenRes.Split('x');
        int width = int.Parse(screenres[0]);
        int height = int.Parse(screenres[1]);
        GUI.Label(new Rect(width / 2 - 80, height / 3-50 , 80, 120), "Sound Cloud", infoStyle);
        if(isSelectMusic)
            GUI.Label(new Rect(width / 2 - 80, height / 2+100 , 80, 120), "曲選択\n<ー  "+musicList[selectNum] +"  ー>", infoStyle);
        if (isSelectDif)
            GUI.Label(new Rect(width / 2 - 80, height / 2 + 100, 80, 120), "難易度選択\n<ー  " + nowLevel + "  ー>", infoStyle);
        if(isLoading)
            GUI.Label(new Rect(width / 2 - 80, height / 2 + 100, 80, 120), "読み込み中...", infoStyle);
    }
}
