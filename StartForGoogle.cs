using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
public class StartForGoogle : MonoBehaviour
{
    //private static StartForGoogle Instance = null;
    public static StartForGoogle instance;
    //{ get { return Instance; } }

    private string appID = "topSecret-only for GitHub";

    private RewardBasedVideoAd rewardedAd;
    private string rewardedAdID = "topSecret-only for GitHub";

   
    private void Awake()
     {
       /* {
            if (instance != null && instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
            else
            {
                instance = this;
            }

        }*/
        if(instance == null)
        {
        instance = this;
        }
        else
        {
         Destroy(this);

         }
    }
    private void Start()
    {
        rewardedAd = RewardBasedVideoAd.Instance;
        RequestRewardedAd();

        rewardedAd.OnAdLoaded += HandleRewardBasedVideoLoaded;

        rewardedAd.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;

        rewardedAd.OnAdRewarded += HandleRewardBasedVideoRewarded;

        rewardedAd.OnAdClosed += HandleRewardBasedVideoClosed;
    }
    public void RequestRewardedAd()
    {
        AdRequest request = new AdRequest.Builder().Build();

        rewardedAd.LoadAd(request, rewardedAdID);
    }

    public void ShowRewardedAd()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
        else
        {
            Debug.Log("Rewarded ad not loaded");
        }
    }
    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        Debug.Log("Rewarded Video ad loaded successfully");

    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("Failed to load rewarded video ad : " + args.Message);


    }



    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        Debug.Log("You have been rewarded with  " + amount.ToString() + " " + type);
// MOJA NAGRODA ZA REKLAME
        PlayerPrefs.SetInt("heartNumber", PlayerPrefs.GetInt("heartNumber") + 2);
    }


    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        Debug.Log("Rewarded video has closed");
        RequestRewardedAd();

    }
}


// tast android
// I	ca-app-pub-3940256099942544/5224354917
