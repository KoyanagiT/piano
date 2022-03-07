using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraC : MonoBehaviour
{

    private Transform camerac;

    // Start is called before the first frame update
    void Start()
    {
        camerac = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        ///移動
        if (Input.GetKey(KeyCode.A))
        {
            camerac.Translate(-0.3f, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            camerac.Translate(0.3f, 0, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            camerac.Translate(0, 0, -0.3f);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            camerac.Translate(0, 0, 0.3f);
        }
        else if (Input.GetKey(KeyCode.R))
        {
            camerac.Translate(0, 0.3f, 0);
        }
        else if (Input.GetKey(KeyCode.F))
        {
            camerac.Translate(0, -0.3f, 0);
        }

        ///回転
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift))
            {
                camerac.Rotate(0, 0, -1);
            }
            else
            {
                camerac.Rotate(0, 1, 0);
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift))
            {
                camerac.Rotate(0, 0, 1);
            }
            else
            {
                camerac.Rotate(0, -1, 0);
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            camerac.Rotate(-1, 0, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            camerac.Rotate(1, 0, 0);
        }
    }
}