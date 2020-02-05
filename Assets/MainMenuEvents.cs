using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using GoogleMobileAds.Api;

public class MainMenuEvents : MonoBehaviour
{
    private Text signInButtonText;
    private Text authStatus;
    private GameObject ldrButton;

    // ... other code here... 
    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        ldrButton = GameObject.Find("StartButton_LB");
        GameObject startButton = GameObject.Find("StartButton_LogIn");
        EventSystem.current.firstSelectedGameObject = startButton;


        //  ADD THIS CODE BETWEEN THESE COMMENTS

        // Create client configuration
        PlayGamesClientConfiguration config = new
            PlayGamesClientConfiguration.Builder()
            .Build();

        // Enable debugging output (recommended)
        PlayGamesPlatform.DebugLogEnabled = true;

        // Initialize and activate the platform
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        // END THE CODE TO PASTE INTO START

        // ADD THESE LINES
        // Get object instances
        signInButtonText =
            GameObject.Find("StartButton_LogIn").GetComponentInChildren<Text>();
        authStatus = GameObject.Find("authStatus").GetComponent<Text>();

        // ...

        // PASTE THESE LINES AT THE END OF Start()
        // Try silent sign-in (second parameter is isSilent)
        PlayGamesPlatform.Instance.Authenticate(SignInCallback, true);
    }

    private InterstitialAd interstitial;

    public void RequestInterstitial()
    {
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);


    }

    public void LoadAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
    }

    public void Update()
    {
        // Hide or show the achievement and leaderboards buttons
        ldrButton.SetActive(Social.localUser.authenticated);

        //if (this.interstitial.IsLoaded())
        //{
        //    this.interstitial.Show();
        //}
    }

    public void SignIn()
    {
        if (!PlayGamesPlatform.Instance.localUser.authenticated)
        {
            // Sign in with Play Game Services, showing the consent dialog
            // by setting the second parameter to isSilent=false.
            PlayGamesPlatform.Instance.Authenticate(SignInCallback, false);
        }
        else
        {
            // Sign out of play games
            PlayGamesPlatform.Instance.SignOut();

            // Reset UI
            signInButtonText.text = "Sign In";
            authStatus.text = "";
        }
    }

    public void SignInCallback(bool success)
    {
        if (success)
        {
            Debug.Log("(Lollygagger) Signed in!");

            // Change sign-in button text
            signInButtonText.text = "Sign out";

            // Show the user's name
            authStatus.text = "Signed in as: " + Social.localUser.userName;
        }
        else
        {
            Debug.Log("(Lollygagger) Sign-in failed...");

            // Show failure message
            signInButtonText.text = "Sign in";
            authStatus.text = "Sign-in failed";
        }
    }

    public void ShowLeaderboards()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        }
        else
        {
            Debug.Log("Cannot show leaderboard: not authenticated");
        }
    }


}
