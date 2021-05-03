using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAds : MonoBehaviour,IUnityAdsListener
{

    private string m_androidgameid= "4020697";
    private string m_bannerplacementid= "Banner_Android";
    private string m_interstialplacementid= "Interstitial_Android";
    private string m_rewardedplacementid= "Rewarded_Android";

    public bool m_testmode=false;


    // Start is called before the first frame update
    void Start()
    {
        _Initilazation();
    }

    void OnDisable()
    {
        Advertisement.RemoveListener(this);
    }

    void _Initilazation()
    {

        Advertisement.AddListener(this);
        Advertisement.Initialize(m_androidgameid,m_testmode);

        StartCoroutine(_CheckInitilizationProcess());
    }



    IEnumerator _CheckInitilizationProcess()
    {
        if (Advertisement.isInitialized==false)
        {
            Debug.Log("Initilization started");
            yield return null;
        }

        Debug.Log("Initilization Done");

        _ShowBannerAd();

    }

    void _ShowBannerAd()
    {
        Advertisement.Banner.Show(m_bannerplacementid);
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
    }

    public void _ShowInterstialAd()
    {
        if (Advertisement.IsReady(m_interstialplacementid))
        {
            Advertisement.Show(m_interstialplacementid);
        }
    }

    public void _ShowRewardedAd()
    {
        if (Advertisement.IsReady(m_rewardedplacementid))
        {
            Advertisement.Show(m_rewardedplacementid);
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ad is Ready : " + placementId);

        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Ad Eror : " + message);
        // throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad Did Start : " + placementId);
        //throw new System.NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // AD Finished
        if (showResult==ShowResult.Finished)
        {
            Debug.Log("Ad Finished : " + placementId);
        }

        //Ad Skiped
        if (showResult == ShowResult.Skipped)
        {
            Debug.Log("Ad Skiped : " + placementId);
        }

        //Ad Failed
        if (showResult == ShowResult.Failed)
        {
            Debug.Log("Ad Failed : " + placementId);
        }

        //t/hrow new System.NotImplementedException();
    }
}
