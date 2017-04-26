using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVariables : MonoBehaviour {

    [Header("Player Stats")]
    public static int Cash;
    public static int PowerSupply;
    public static int Oil;
    public static int Lives;

    public int startCash = 5000;
    public int startLives = 50;
    public int startPS = 1000;
    public int startOil = 0;
    public static int PsCap;

    public static bool hasAR;
    public static bool hasADV;
    public static bool hasSniperAcademy;
    public static bool hasMissileFactory;
    public static bool hasLSR;
    public static bool hasFLM;

    public static int WavesSurvived = 0;

    void Start()
    {
        Cash = startCash;
        Lives = startLives;
        PsCap = startPS;
        PowerSupply = 0;
        Oil = startOil;

        hasAR = false;
        hasADV = false;
        hasSniperAcademy = false;
        hasMissileFactory = false;
        hasLSR = false;
        hasFLM = false;

}

    public void UpgradePS()
    {
        PsCap += 50;
    }


    



}
