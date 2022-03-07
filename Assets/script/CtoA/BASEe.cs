using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BASEe : MonoBehaviour
{
    private Animator anime;
    private bool bl = false;
    private sounder sound;
    // Start is called before the first frame update
    void Start()
    {
        anime = transform.GetComponent<Animator>();
        sound = GetComponent<sounder>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (bl)
            {
                sound.OnPush();
                anime.speed = 10;
                anime.SetBool("Open", true);
                bl = false;
            }
        }
        else
        {
            if (!bl)
            {
                anime.speed = 2;
                anime.SetBool("Open", false);
                bl = true;
            }
        }
    }
}
