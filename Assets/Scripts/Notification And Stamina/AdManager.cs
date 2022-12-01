using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] string gameID = "";
    [SerializeField] string adID = "";
    [SerializeField] string ad2ID = "";

    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameID);
    }

    public void ShowAD()
    {
        if (!Advertisement.IsReady()) return;

        Advertisement.Show(adID);
    }    
    public void ShowAD2()
    {
        if (!Advertisement.IsReady()) return;

        Advertisement.Show(ad2ID);
    }

    public void OnUnityAdsReady(string placementId)
    {
    }

    public void OnUnityAdsDidError(string message)
    {
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == "x2Ad")
        {
            if (showResult == ShowResult.Finished)
            {
                int loops = (PlayerPrefs.GetInt("LastLoops") + PlayerPrefs.GetInt("FrootLoops"));
                PlayerPrefs.SetInt("FrootLoops", loops);
                Debug.Log("Te doy la recompensa");
            }
            else
            {
                PlayerPrefs.SetInt("LastLoops", 0);
                Debug.Log("No te doy nada");
            }
        }
    }
}

