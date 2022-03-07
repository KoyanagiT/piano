using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushtest : MonoBehaviour
{
    private Animator anime;
    private bool bl = false;
    // Start is called before the first frame update
    void Start()
    {
        anime = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (bl)
            {
                anime.SetBool("Open", true);
                bl = false;
            }
        }
        else
        {
            if (!bl)
            {
                anime.SetBool("Open", false);
                bl = true;
            }
        }
    }
}
