using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMove : MonoBehaviour {
    public GameObject player;
    public GameObject field1;
    public GameObject field2;

    int fieldLength = 1000;
    private long boader;
    private int boaderOff = 500;
    private int cnt = 0;
    // Use this for initialization
    void Start () {
        boader = fieldLength;
	}
	
	// Update is called once per frame
	void Update () {
        if(player.transform.position.z > boader+boaderOff)
        {
            if (cnt % 2 == 0) field1.transform.position = new Vector3(field1.transform.position.x, field1.transform.position.y, boader+fieldLength);
            else
            {
                field2.transform.position = new Vector3(field2.transform.position.x, field2.transform.position.y, boader+fieldLength);

            }
            boader += fieldLength;
            cnt++;
            
        }else if(player.transform.position.z-1 < boader-fieldLength + boaderOff)
        {
            cnt--;
            if (cnt % 2 == 0) field1.transform.position = new Vector3(field1.transform.position.x, field1.transform.position.y, boader - fieldLength*2);
            else
            {
                field2.transform.position = new Vector3(field2.transform.position.x, field2.transform.position.y, boader - fieldLength*2);

            }
            boader -= fieldLength;
            
        }
	}
}
