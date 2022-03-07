using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class modeChanger : MonoBehaviour
{

    ///mode数      : 11
    ///
    ///camera      : 0
    ///CtoA BASE   : 1
    ///CtoA one    : 2
    ///CtoA two    : 3
    ///CtoA three  : 4
    ///CtoA mone   : 5
    ///CtoA mtwo   : 6
    ///CtoA mthree : 7
    ///CtoA mfour  : 8
    ///Demo        : 9

    public GameObject camera;
    public GameObject[] keyObject;
    ///DemoMode用
    ///public GameObject Demo;
    private int CommandNumber = 0;

    private int KeyOqSet = 7;
    private int Keynum = 0;

    // Start is called before the first frame update
    void Start()
    {
        ///cameraMode();
        CtoABASEMode();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.M))
        {
            switch (CommandNumber)
            {
                case 0:
                    cameraMode();
                    CommandNumber += 1;
                    break;
                case 1:
                    CtoABASEMode();
                    CommandNumber += 1;
                    break;
                case 2:
                    CtoAoneMode();
                    CommandNumber += 1;
                    break;
                case 3:
                    CtoAtwoMode();
                    CommandNumber += 1;
                    break;
                case 4:
                    CtoAthreeMode();
                    CommandNumber += 1;
                    break;
                case 5:
                    CtoAMoneMode();
                    CommandNumber += 1;
                    break;
                case 6:
                    CtoAMtwoMode();
                    CommandNumber += 1;
                    break;
                case 7:
                    CtoAMthreeMode();
                    CommandNumber += 1;
                    break;
                case 8:
                    CtoAMfourMode();
                    CommandNumber += 1;
                    break;
                case 9:
                    DemoMode();
                    CommandNumber = 0;
                    break;
                default:
                    CommandNumber = 0;
                    break;
            }
        }
    }


    ///camera      : 0
    ///CtoA BASE   : 1
    ///CtoA one    : 2
    ///CtoA two    : 3
    ///CtoA three  : 4
    ///CtoA mone   : 5
    ///CtoA mtwo   : 6
    ///CtoA mthree : 7
    ///CtoA mfour  : 8
    ///Demo        : 9


    /// <summary>
    /// mode : 0
    /// </summary>
    private void cameraMode()
    {
        ///camera
        camera.GetComponent<cameraC>().enabled = true;

        GetComponent<Demo>().enabled = false;

        ///fourOq
        keyObject[0].GetComponent<BASEcp>().enabled = false;

        ///threeOq ～ mthreeOq
        for (Keynum = 0; Keynum< KeyOqSet ; Keynum++)
        {
            keyObject[Keynum * 12 + 1].GetComponent<BASEc>().enabled = false;
            keyObject[Keynum * 12 + 2].GetComponent<BASEcsh>().enabled = false;
            keyObject[Keynum * 12 + 3].GetComponent<BASEd>().enabled = false;
            keyObject[Keynum * 12 + 4].GetComponent<BASEdsh>().enabled = false;
            keyObject[Keynum * 12 + 5].GetComponent<BASEe>().enabled = false;
            keyObject[Keynum * 12 + 6].GetComponent<BASEf>().enabled = false;
            keyObject[Keynum * 12 + 7].GetComponent<BASEfsh>().enabled = false;
            keyObject[Keynum * 12 + 8].GetComponent<BASEg>().enabled = false;
            keyObject[Keynum * 12 + 9].GetComponent<BASEgsh>().enabled = false;
            keyObject[Keynum * 12 + 10].GetComponent<BASEa>().enabled = false;
            keyObject[Keynum * 12 + 11].GetComponent<BASEash>().enabled = false;
            keyObject[Keynum * 12 + 12].GetComponent<BASEb>().enabled = false;
        }

        ///mfourOq
        keyObject[85].GetComponent<BASEa>().enabled = false;
        keyObject[86].GetComponent<BASEash>().enabled = false;
        keyObject[87].GetComponent<BASEb>().enabled = false;
    }

    /// <summary>
    /// mode : 9
    /// </summary>
    private void DemoMode()
    {
        ///全てのスクリプトを止めて，別ので動かす
        cameraMode();
        camera.GetComponent<cameraC>().enabled = false;

        GetComponent<Demo>().enabled = true;
    }


    /// <summary>
    /// mode : 1
    /// </summary>
    private void CtoABASEMode()
    {
        ///camera
        camera.GetComponent<cameraC>().enabled = false;

        ///enable key
        Keynum = 3;

        keyObject[Keynum * 12 + 1].GetComponent<BASEc>().enabled = true;
        keyObject[Keynum * 12 + 2].GetComponent<BASEcsh>().enabled = true;
        keyObject[Keynum * 12 + 3].GetComponent<BASEd>().enabled = true;
        keyObject[Keynum * 12 + 4].GetComponent<BASEdsh>().enabled = true;
        keyObject[Keynum * 12 + 5].GetComponent<BASEe>().enabled = true;
        keyObject[Keynum * 12 + 6].GetComponent<BASEf>().enabled = true;
        keyObject[Keynum * 12 + 7].GetComponent<BASEfsh>().enabled = true;
        keyObject[Keynum * 12 + 8].GetComponent<BASEg>().enabled = true;
        keyObject[Keynum * 12 + 9].GetComponent<BASEgsh>().enabled = true;
        keyObject[Keynum * 12 + 10].GetComponent<BASEa>().enabled = true;
        keyObject[Keynum * 12 + 11].GetComponent<BASEash>().enabled = true;
        keyObject[Keynum * 12 + 12].GetComponent<BASEb>().enabled = true;
    }

    /// <summary>
    /// mode : 2
    /// </summary>
    private void CtoAoneMode()
    {
        ///enable key
        Keynum = 2;

        keyObject[Keynum * 12 + 1].GetComponent<BASEc>().enabled = true;
        keyObject[Keynum * 12 + 2].GetComponent<BASEcsh>().enabled = true;
        keyObject[Keynum * 12 + 3].GetComponent<BASEd>().enabled = true;
        keyObject[Keynum * 12 + 4].GetComponent<BASEdsh>().enabled = true;
        keyObject[Keynum * 12 + 5].GetComponent<BASEe>().enabled = true;
        keyObject[Keynum * 12 + 6].GetComponent<BASEf>().enabled = true;
        keyObject[Keynum * 12 + 7].GetComponent<BASEfsh>().enabled = true;
        keyObject[Keynum * 12 + 8].GetComponent<BASEg>().enabled = true;
        keyObject[Keynum * 12 + 9].GetComponent<BASEgsh>().enabled = true;
        keyObject[Keynum * 12 + 10].GetComponent<BASEa>().enabled = true;
        keyObject[Keynum * 12 + 11].GetComponent<BASEash>().enabled = true;
        keyObject[Keynum * 12 + 12].GetComponent<BASEb>().enabled = true;


        ///unenable key
        Keynum = 3;

        keyObject[Keynum * 12 + 1].GetComponent<BASEc>().enabled = false;
        keyObject[Keynum * 12 + 2].GetComponent<BASEcsh>().enabled = false;
        keyObject[Keynum * 12 + 3].GetComponent<BASEd>().enabled = false;
        keyObject[Keynum * 12 + 4].GetComponent<BASEdsh>().enabled = false;
        keyObject[Keynum * 12 + 5].GetComponent<BASEe>().enabled = false;
        keyObject[Keynum * 12 + 6].GetComponent<BASEf>().enabled = false;
        keyObject[Keynum * 12 + 7].GetComponent<BASEfsh>().enabled = false;
        keyObject[Keynum * 12 + 8].GetComponent<BASEg>().enabled = false;
        keyObject[Keynum * 12 + 9].GetComponent<BASEgsh>().enabled = false;
        keyObject[Keynum * 12 + 10].GetComponent<BASEa>().enabled = false;
        keyObject[Keynum * 12 + 11].GetComponent<BASEash>().enabled = false;
        keyObject[Keynum * 12 + 12].GetComponent<BASEb>().enabled = false;
    }

    /// <summary>
    /// mode : 3
    /// </summary>
    private void CtoAtwoMode()
    {
        ///enable key
        Keynum = 1;

        keyObject[Keynum * 12 + 1].GetComponent<BASEc>().enabled = true;
        keyObject[Keynum * 12 + 2].GetComponent<BASEcsh>().enabled = true;
        keyObject[Keynum * 12 + 3].GetComponent<BASEd>().enabled = true;
        keyObject[Keynum * 12 + 4].GetComponent<BASEdsh>().enabled = true;
        keyObject[Keynum * 12 + 5].GetComponent<BASEe>().enabled = true;
        keyObject[Keynum * 12 + 6].GetComponent<BASEf>().enabled = true;
        keyObject[Keynum * 12 + 7].GetComponent<BASEfsh>().enabled = true;
        keyObject[Keynum * 12 + 8].GetComponent<BASEg>().enabled = true;
        keyObject[Keynum * 12 + 9].GetComponent<BASEgsh>().enabled = true;
        keyObject[Keynum * 12 + 10].GetComponent<BASEa>().enabled = true;
        keyObject[Keynum * 12 + 11].GetComponent<BASEash>().enabled = true;
        keyObject[Keynum * 12 + 12].GetComponent<BASEb>().enabled = true;


        ///unenable key
        Keynum = 2;

        keyObject[Keynum * 12 + 1].GetComponent<BASEc>().enabled = false;
        keyObject[Keynum * 12 + 2].GetComponent<BASEcsh>().enabled = false;
        keyObject[Keynum * 12 + 3].GetComponent<BASEd>().enabled = false;
        keyObject[Keynum * 12 + 4].GetComponent<BASEdsh>().enabled = false;
        keyObject[Keynum * 12 + 5].GetComponent<BASEe>().enabled = false;
        keyObject[Keynum * 12 + 6].GetComponent<BASEf>().enabled = false;
        keyObject[Keynum * 12 + 7].GetComponent<BASEfsh>().enabled = false;
        keyObject[Keynum * 12 + 8].GetComponent<BASEg>().enabled = false;
        keyObject[Keynum * 12 + 9].GetComponent<BASEgsh>().enabled = false;
        keyObject[Keynum * 12 + 10].GetComponent<BASEa>().enabled = false;
        keyObject[Keynum * 12 + 11].GetComponent<BASEash>().enabled = false;
        keyObject[Keynum * 12 + 12].GetComponent<BASEb>().enabled = false;
    }

    /// <summary>
    /// mode : 4
    /// </summary>
    private void CtoAthreeMode()
    {
        ///enable key
        Keynum = 0;

        keyObject[Keynum * 12 + 1].GetComponent<BASEc>().enabled = true;
        keyObject[Keynum * 12 + 2].GetComponent<BASEcsh>().enabled = true;
        keyObject[Keynum * 12 + 3].GetComponent<BASEd>().enabled = true;
        keyObject[Keynum * 12 + 4].GetComponent<BASEdsh>().enabled = true;
        keyObject[Keynum * 12 + 5].GetComponent<BASEe>().enabled = true;
        keyObject[Keynum * 12 + 6].GetComponent<BASEf>().enabled = true;
        keyObject[Keynum * 12 + 7].GetComponent<BASEfsh>().enabled = true;
        keyObject[Keynum * 12 + 8].GetComponent<BASEg>().enabled = true;
        keyObject[Keynum * 12 + 9].GetComponent<BASEgsh>().enabled = true;
        keyObject[Keynum * 12 + 10].GetComponent<BASEa>().enabled = true;
        keyObject[Keynum * 12 + 11].GetComponent<BASEash>().enabled = true;
        keyObject[Keynum * 12 + 12].GetComponent<BASEb>().enabled = true;

        ///fourOq
        keyObject[0].GetComponent<BASEcp>().enabled = true;


        ///unenable key
        Keynum = 1;

        keyObject[Keynum * 12 + 1].GetComponent<BASEc>().enabled = false;
        keyObject[Keynum * 12 + 2].GetComponent<BASEcsh>().enabled = false;
        keyObject[Keynum * 12 + 3].GetComponent<BASEd>().enabled = false;
        keyObject[Keynum * 12 + 4].GetComponent<BASEdsh>().enabled = false;
        keyObject[Keynum * 12 + 5].GetComponent<BASEe>().enabled = false;
        keyObject[Keynum * 12 + 6].GetComponent<BASEf>().enabled = false;
        keyObject[Keynum * 12 + 7].GetComponent<BASEfsh>().enabled = false;
        keyObject[Keynum * 12 + 8].GetComponent<BASEg>().enabled = false;
        keyObject[Keynum * 12 + 9].GetComponent<BASEgsh>().enabled = false;
        keyObject[Keynum * 12 + 10].GetComponent<BASEa>().enabled = false;
        keyObject[Keynum * 12 + 11].GetComponent<BASEash>().enabled = false;
        keyObject[Keynum * 12 + 12].GetComponent<BASEb>().enabled = false;
    }

    /// <summary>
    /// mode : 5
    /// </summary>
    private void CtoAMoneMode()
    {
        ///enable key
        Keynum = 4;

        keyObject[Keynum * 12 + 1].GetComponent<BASEc>().enabled = true;
        keyObject[Keynum * 12 + 2].GetComponent<BASEcsh>().enabled = true;
        keyObject[Keynum * 12 + 3].GetComponent<BASEd>().enabled = true;
        keyObject[Keynum * 12 + 4].GetComponent<BASEdsh>().enabled = true;
        keyObject[Keynum * 12 + 5].GetComponent<BASEe>().enabled = true;
        keyObject[Keynum * 12 + 6].GetComponent<BASEf>().enabled = true;
        keyObject[Keynum * 12 + 7].GetComponent<BASEfsh>().enabled = true;
        keyObject[Keynum * 12 + 8].GetComponent<BASEg>().enabled = true;
        keyObject[Keynum * 12 + 9].GetComponent<BASEgsh>().enabled = true;
        keyObject[Keynum * 12 + 10].GetComponent<BASEa>().enabled = true;
        keyObject[Keynum * 12 + 11].GetComponent<BASEash>().enabled = true;
        keyObject[Keynum * 12 + 12].GetComponent<BASEb>().enabled = true;


        ///unenable key
        Keynum = 0;

        keyObject[Keynum * 12 + 1].GetComponent<BASEc>().enabled = false;
        keyObject[Keynum * 12 + 2].GetComponent<BASEcsh>().enabled = false;
        keyObject[Keynum * 12 + 3].GetComponent<BASEd>().enabled = false;
        keyObject[Keynum * 12 + 4].GetComponent<BASEdsh>().enabled = false;
        keyObject[Keynum * 12 + 5].GetComponent<BASEe>().enabled = false;
        keyObject[Keynum * 12 + 6].GetComponent<BASEf>().enabled = false;
        keyObject[Keynum * 12 + 7].GetComponent<BASEfsh>().enabled = false;
        keyObject[Keynum * 12 + 8].GetComponent<BASEg>().enabled = false;
        keyObject[Keynum * 12 + 9].GetComponent<BASEgsh>().enabled = false;
        keyObject[Keynum * 12 + 10].GetComponent<BASEa>().enabled = false;
        keyObject[Keynum * 12 + 11].GetComponent<BASEash>().enabled = false;
        keyObject[Keynum * 12 + 12].GetComponent<BASEb>().enabled = false;

        ///fourOq
        keyObject[0].GetComponent<BASEcp>().enabled = false;
    }

    /// <summary>
    /// mode : 6
    /// </summary>
    private void CtoAMtwoMode()
    {
        ///enable key
        Keynum = 5;

        keyObject[Keynum * 12 + 1].GetComponent<BASEc>().enabled = true;
        keyObject[Keynum * 12 + 2].GetComponent<BASEcsh>().enabled = true;
        keyObject[Keynum * 12 + 3].GetComponent<BASEd>().enabled = true;
        keyObject[Keynum * 12 + 4].GetComponent<BASEdsh>().enabled = true;
        keyObject[Keynum * 12 + 5].GetComponent<BASEe>().enabled = true;
        keyObject[Keynum * 12 + 6].GetComponent<BASEf>().enabled = true;
        keyObject[Keynum * 12 + 7].GetComponent<BASEfsh>().enabled = true;
        keyObject[Keynum * 12 + 8].GetComponent<BASEg>().enabled = true;
        keyObject[Keynum * 12 + 9].GetComponent<BASEgsh>().enabled = true;
        keyObject[Keynum * 12 + 10].GetComponent<BASEa>().enabled = true;
        keyObject[Keynum * 12 + 11].GetComponent<BASEash>().enabled = true;
        keyObject[Keynum * 12 + 12].GetComponent<BASEb>().enabled = true;


        ///unenable key
        Keynum = 4;

        keyObject[Keynum * 12 + 1].GetComponent<BASEc>().enabled = false;
        keyObject[Keynum * 12 + 2].GetComponent<BASEcsh>().enabled = false;
        keyObject[Keynum * 12 + 3].GetComponent<BASEd>().enabled = false;
        keyObject[Keynum * 12 + 4].GetComponent<BASEdsh>().enabled = false;
        keyObject[Keynum * 12 + 5].GetComponent<BASEe>().enabled = false;
        keyObject[Keynum * 12 + 6].GetComponent<BASEf>().enabled = false;
        keyObject[Keynum * 12 + 7].GetComponent<BASEfsh>().enabled = false;
        keyObject[Keynum * 12 + 8].GetComponent<BASEg>().enabled = false;
        keyObject[Keynum * 12 + 9].GetComponent<BASEgsh>().enabled = false;
        keyObject[Keynum * 12 + 10].GetComponent<BASEa>().enabled = false;
        keyObject[Keynum * 12 + 11].GetComponent<BASEash>().enabled = false;
        keyObject[Keynum * 12 + 12].GetComponent<BASEb>().enabled = false;
    }

    /// <summary>
    /// mode : 7
    /// </summary>
    private void CtoAMthreeMode()
    {
        ///enable key
        Keynum = 6;

        keyObject[Keynum * 12 + 1].GetComponent<BASEc>().enabled = true;
        keyObject[Keynum * 12 + 2].GetComponent<BASEcsh>().enabled = true;
        keyObject[Keynum * 12 + 3].GetComponent<BASEd>().enabled = true;
        keyObject[Keynum * 12 + 4].GetComponent<BASEdsh>().enabled = true;
        keyObject[Keynum * 12 + 5].GetComponent<BASEe>().enabled = true;
        keyObject[Keynum * 12 + 6].GetComponent<BASEf>().enabled = true;
        keyObject[Keynum * 12 + 7].GetComponent<BASEfsh>().enabled = true;
        keyObject[Keynum * 12 + 8].GetComponent<BASEg>().enabled = true;
        keyObject[Keynum * 12 + 9].GetComponent<BASEgsh>().enabled = true;
        keyObject[Keynum * 12 + 10].GetComponent<BASEa>().enabled = true;
        keyObject[Keynum * 12 + 11].GetComponent<BASEash>().enabled = true;
        keyObject[Keynum * 12 + 12].GetComponent<BASEb>().enabled = true;


        ///unenable key
        Keynum = 5;

        keyObject[Keynum * 12 + 1].GetComponent<BASEc>().enabled = false;
        keyObject[Keynum * 12 + 2].GetComponent<BASEcsh>().enabled = false;
        keyObject[Keynum * 12 + 3].GetComponent<BASEd>().enabled = false;
        keyObject[Keynum * 12 + 4].GetComponent<BASEdsh>().enabled = false;
        keyObject[Keynum * 12 + 5].GetComponent<BASEe>().enabled = false;
        keyObject[Keynum * 12 + 6].GetComponent<BASEf>().enabled = false;
        keyObject[Keynum * 12 + 7].GetComponent<BASEfsh>().enabled = false;
        keyObject[Keynum * 12 + 8].GetComponent<BASEg>().enabled = false;
        keyObject[Keynum * 12 + 9].GetComponent<BASEgsh>().enabled = false;
        keyObject[Keynum * 12 + 10].GetComponent<BASEa>().enabled = false;
        keyObject[Keynum * 12 + 11].GetComponent<BASEash>().enabled = false;
        keyObject[Keynum * 12 + 12].GetComponent<BASEb>().enabled = false;
    }

    /// <summary>
    /// mode : 8
    /// </summary>
    private void CtoAMfourMode()
    {
        ///enable key
        Keynum = 7;

        keyObject[Keynum * 12 + 1].GetComponent<BASEa>().enabled = true;
        keyObject[Keynum * 12 + 2].GetComponent<BASEash>().enabled = true;
        keyObject[Keynum * 12 + 3].GetComponent<BASEb>().enabled = true;


        ///unenable key
        Keynum = 6;

        keyObject[Keynum * 12 + 1].GetComponent<BASEc>().enabled = false;
        keyObject[Keynum * 12 + 2].GetComponent<BASEcsh>().enabled = false;
        keyObject[Keynum * 12 + 3].GetComponent<BASEd>().enabled = false;
        keyObject[Keynum * 12 + 4].GetComponent<BASEdsh>().enabled = false;
        keyObject[Keynum * 12 + 5].GetComponent<BASEe>().enabled = false;
        keyObject[Keynum * 12 + 6].GetComponent<BASEf>().enabled = false;
        keyObject[Keynum * 12 + 7].GetComponent<BASEfsh>().enabled = false;
        keyObject[Keynum * 12 + 8].GetComponent<BASEg>().enabled = false;
        keyObject[Keynum * 12 + 9].GetComponent<BASEgsh>().enabled = false;
        keyObject[Keynum * 12 + 10].GetComponent<BASEa>().enabled = false;
        keyObject[Keynum * 12 + 11].GetComponent<BASEash>().enabled = false;
        keyObject[Keynum * 12 + 12].GetComponent<BASEb>().enabled = false;
    }
}
