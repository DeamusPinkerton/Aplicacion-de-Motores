using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] string gameID = "";
    [SerializeField] string adID = "";

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
        if (placementId == "Rewarded_Android")
        {
            if (showResult == ShowResult.Finished)
            {
                Debug.Log("Te doy la recompensa");
            }
            else
            {
                Debug.Log("No te doy nada");
            }
        }
    }
}

