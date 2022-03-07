using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounder : MonoBehaviour
{
    [SerializeField] private AudioSource keySound;
    private bool GetWild = false;

    public void OnPush()
    {
        if ((keySound != null) && !GetWild)
        {
            keySound.time = 0.15f;
            keySound.Play();
            GetWild = !GetWild;
        }
    }

    public void OffPush()
    {
        if ((keySound != null) && GetWild)
        {
            keySound.Stop();
            GetWild = !GetWild;
        }
    }
}
