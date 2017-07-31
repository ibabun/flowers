using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerManager : MonoBehaviour {
    public int flowerInScene;
    public int maxFlowers = 30;

    public GameObject eater;
    public int eaterNum;
    public GameObject food;
    public int foodNum;

    public void transferProc()
    {
        flowerBirgth eaterSTR = eater.GetComponent<flowerBirgth>();
        flowerBirgth foodSTR = food.GetComponent<flowerBirgth>();

        if (eater != null && food != null)
        {

            eaterSTR.life = foodSTR.life + eaterSTR.life;
            Destroy(foodSTR.gameObject);
            //Debug.Log("i am_" + eaterSTR.myNum + "_by_" + foodSTR.myNum + "__with result__" + flowerInScene);
            flowerInScene--;
            eater = null;
            food = null;

        }
    }

    public void killProc()
    {
        if (food != null)
        {
            flowerBirgth foodSTR = food.GetComponent<flowerBirgth>();
            Destroy(foodSTR.gameObject);
            //Debug.Log("i am_" + foodSTR.myNum + "   die");
            flowerInScene--;
            eater = null;
            food = null;
        }
    }

}