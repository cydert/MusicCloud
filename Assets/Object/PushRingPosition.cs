using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRingPosition : MonoBehaviour
{
    public GameObject plane;
    float length;
    const float OLD_LENGTH = 1000;
    // Use this for initialization
    void Start()
    {
        length = OLD_LENGTH;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetLength(float addLength)
    {
        length = addLength;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(0, 0, plane.transform.position.z + length);
    }

    public void ResetPosition()
    {
        transform.position = new Vector3(0, 0, plane.transform.position.z + length);
    }
}
