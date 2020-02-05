/**
 * @deprecated
 * Enhance connector for Unity
 */

using UnityEngine;
using System;
using FGL.Enhance.Internals;
using System.Collections.Generic;

public class FGLEnhance
{
    ///// PUBLIC /////

    // Where the rewarded as was triggered
    public const string REWARDED_PLACEMENT_SUCCESS = "SUCCESS";                 // Ad following success in the game, such as completing a level
    public const string REWARDED_PLACEMENT_HELPER = "HELPER";                   // Ad to help the user, for instance after losing a level or when needing currency
    public const string REWARDED_PLACEMENT_NEUTRAL = "NEUTRAL";                 // Ad in a neutral circumstance, for instance the user tapping "Watch video for a reward"

    // default placement type
    public const string PLACEMENT_DEFAULT = "default";             // Default ad placement

    // Where the interstitial was triggered
    public const string INTERSTITIAL_PLACEMENT_DEFAULT = "default";             // Default ad placement
    public const string INTERSTITIAL_LEVEL_COMPLETED = "level_completed";       // Level completed

    // Overlay position
    public const string POSITION_TOP = "TOP";                                   // Top
    public const string POSITION_BOTTOM = "BOTTOM";                             // Bottom

    // Type of reward that was granted
    public enum RewardType
    {
        REWARDTYPE_ITEM,           // Arbitrary game-defined item granted (no coin amount reported)
        REWARDTYPE_COINS          // A defined coins amount was granted
    };

    /**
      * Set currency received callback
      * 
      * @param onCurrencyReceived callback executed when a currency is received
      */
	public static void SetReceivedCurrencyCallback(Action<int> onCurrencyReceived)
    {
		Enhance.SetReceivedCurrencyCallback (onCurrencyReceived);
    }

    /**
      * Set interstitial completed callback
      * 
      * @param onInterstitialCallback callback executed when an interstitial completes
      */
    public static void SetInterstitialCallback(Action onInterstitialCallback)
    {
        if (GameObject.Find(FGLEnhance_Callbacks.CallbackObjectName) == null)
        {
            string newName = "__FGLEnhance_Callback_" + UnityEngine.Random.Range(0, int.MaxValue);
            GameObject callbackObject = new GameObject(newName);
            callbackObject.AddComponent<FGLEnhance_Callbacks>();
        }

        FGLEnhance_Callbacks.OnInterstitialCallback = onInterstitialCallback;

        InitializeEnhance();
#if UNITY_EDITOR
        FGLEditorInternals.RequestInterstitialEvents(FGLEnhance_Callbacks.CallbackObjectName);
#elif UNITY_ANDROID
        FGLAndroidInternals.RequestInterstitialEvents(FGLEnhance_Callbacks.CallbackObjectName);
#elif UNITY_IOS
        FGLiOSInternals.RequestInterstitialEvents(FGLEnhance_Callbacks.CallbackObjectName);
#endif
    }

    /**
     * Check if an interstitial ad is ready
     * 
     * @return true if an interstitial ad is ready, false if not
     */
    public static bool IsInterstitialReady(string placement = INTERSTITIAL_PLACEMENT_DEFAULT)
    {
		return Enhance.IsInterstitialReady (placement);
    }

    /**
     * Show interstitial ad
     */
    public static void ShowInterstitialAd(string placement = INTERSTITIAL_PLACEMENT_DEFAULT)
    {
		Enhance.ShowInterstitialAd (placement);
    }

    /**
     * Check if a rewarded ad is ready
     * 
     * @return true if a rewarded ad is ready, false if not
     */
    public static bool IsRewardedAdReady(string placement = REWARDED_PLACEMENT_NEUTRAL)
    {
		return Enhance.IsRewardedAdReady (placement);
    }

    /**
      * Show rewarded ad
      * 
      * @param placement placement type for this ad
      * @param onRewardGrantedCallback callback executed when the ad reward is granted
      * @param onRewardDeclinedCallback callback executed when the ad reward is declined
      * @param onRewardUnavailableCallback callback executed when the ad reward is unavailable
      */
    public static void ShowRewardedAd(string placement, Action<FGLEnhance.RewardType, int> onRewardGrantedCallback, Action onRewardDeclinedCallback, Action onRewardUnavailableCallback)
    {
		Action<Enhance.RewardType, int> onGrantedAction = delegate(Enhance.RewardType rType, int rValue) {
			FGLEnhance.RewardType fglRewardType = FGLEnhance.RewardType.REWARDTYPE_ITEM;
			
			if(rType == Enhance.RewardType.COINS) 
				fglRewardType = FGLEnhance.RewardType.REWARDTYPE_COINS;
			
			onRewardGrantedCallback(fglRewardType, rValue);
		};

		Action onDeclinedAction = delegate() {
			onRewardDeclinedCallback();
		};

		Action onUnavailableAction = delegate() {
			onRewardUnavailableCallback();	
		};

		Enhance.ShowRewardedAd (placement, onGrantedAction, onDeclinedAction, onUnavailableAction);
    }

    /**
     * Check if an overlay ad is ready
     *
     * @return true if an overlay ad is ready, false if not
     */
    public static bool IsOverlayAdReady()
    {
        return IsBannerAdReady();
    }

    /**
     * Show overlay ad
     * 
     * @param position position (top or bottom)
     */
    public static void ShowOverlayAd(string position)
    {
        ShowBannerAd(position);
    }

    /**
     * Hide overlay ad
     */
    public static void HideOverlayAd()
    {
        HideBannerAd();
    }

	/**
	* Check if a banner ad is ready
	*
	* @return true if an banner ad is ready, false if not
	*/
	public static bool IsBannerAdReady()
	{
        return IsBannerAdReady(PLACEMENT_DEFAULT);
	}

    /**
    * Check if a banner ad is ready
    *
    * @return true if an banner ad is ready, false if not
    */
    public static bool IsBannerAdReady(string placement)
    {
		return Enhance.IsBannerAdReady (placement);
    }

    /**
    * Show banner ad
    * 
    * @param position position (top or bottom)
    */
    public static void ShowBannerAd (string position)
    {
        ShowBannerAd(PLACEMENT_DEFAULT, position);
    }

	/**
	* Show banner ad
	* 
	* @param position position (top or bottom)
	*/
	public static void ShowBannerAd (string placement, string position)
	{
		Enhance.Position ePos = Enhance.Position.BOTTOM;
		if (position.Equals("BOTTOM", StringComparison.OrdinalIgnoreCase)) ePos = Enhance.Position.TOP;

		Enhance.ShowBannerAdWithPosition (placement, ePos);
	}

	/**
	* Hide banner ad
	*/
	public static void HideBannerAd ()
	{
		Enhance.HideBannerAd ();
	}

    /**
     * Check if a special offer is ready
     *
     * @return true if a special offer is ready, false if not
     */
    public static bool IsSpecialOfferReady()
    {
        return IsSpecialOfferReady(PLACEMENT_DEFAULT);
    }

	/**
     * Check if a special offer is ready
     *
     * @return true if a special offer is ready, false if not
     */
    public static bool IsSpecialOfferReady(string placement)
    {
		return Enhance.IsSpecialOfferReady (placement);
    }

    /**
     * Show special offer
     */
    public static void ShowSpecialOffer()
    {
        ShowSpecialOffer(PLACEMENT_DEFAULT);
    }

    /**
     * Show special offer
     */
    public static void ShowSpecialOffer(string placement)
    {
		Enhance.ShowSpecialOffer (placement);
    }

    /**
     * Check if an offerwall is ready
     *
     * @return true if an offerwall is ready, false if not
     */
    public static bool IsOfferwallReady()
    {
        return IsOfferwallReady(PLACEMENT_DEFAULT);
    }

    /**
     * Check if an offerwall is ready
     *
     * @return true if an offerwall is ready, false if not
     */
    public static bool IsOfferwallReady(string placement)
    {
		return Enhance.IsOfferwallReady (placement);
    }

    /**
     * Show offerwall
     */
    public static void ShowOfferwall()
    {
        ShowOfferwall(PLACEMENT_DEFAULT);
    }

    /**
     * Show offerwall
     */
    public static void ShowOfferwall(string placement)
    {
		Enhance.ShowOfferwall (placement);
    }

    /**
     * Log custom analytics event
     * 
     * @param eventType event type (for instance 'menu_shown')
     */
    public static void LogEvent(string eventType)
    {
		Enhance.LogEvent (eventType);
    }

    /**
     * Log custom analytics event
     * 
     * @param eventType event type (for instance 'level_completed')
     * @param paramKey parameter key (for instance 'level')
     * @param paramValue parameter value (for instance '3')
     */
    public static void LogEvent(string eventType, string paramKey, string paramValue)
    {
		Enhance.LogEvent (eventType, paramKey, paramValue);
    }

    /**
     * Set callback for receiving remote configuration keys for the app
     * 
     * @param onAppConfigReceivedCallback method called back with the received dictionary of key/value pairs
     */
    public static void SetAppConfigCallback(Action<Dictionary<string, string>> onAppConfigReceivedCallback)
    {
        if (GameObject.Find(FGLEnhance_Callbacks.CallbackObjectName) == null)
        {
            string newName = "__FGLEnhance_Callback_" + UnityEngine.Random.Range(0, int.MaxValue);
            GameObject callbackObject = new GameObject(newName);
            callbackObject.AddComponent<FGLEnhance_Callbacks>();
        }

        FGLEnhance_Callbacks.OnAppConfigReceivedCallback = onAppConfigReceivedCallback;

        InitializeEnhance();
#if UNITY_EDITOR
        FGLEditorInternals.RequestAppConfig(FGLEnhance_Callbacks.CallbackObjectName);
#elif UNITY_ANDROID
        FGLAndroidInternals.RequestAppConfig(FGLEnhance_Callbacks.CallbackObjectName);
#elif UNITY_IOS
        FGLiOSInternals.RequestAppConfig(FGLEnhance_Callbacks.CallbackObjectName);
#endif
    }

    /**
     * Request permission from the user to show local notifications
     * 
     * @param onPermissionGrantedCallback executed when the permission is granted
     * @param onPermissionRefusedCallback executed when the permission is refused
     */
    public static void RequestLocalNotificationPermission(Action onPermissionGrantedCallback, Action onPermissionRefusedCallback)
    {
		Enhance.RequestLocalNotificationPermission (onPermissionGrantedCallback, onPermissionRefusedCallback);
    }

    /**
     * Enable local notifications
     *
     * @param title notification title
     * @param message notification message
     * @param delay notification delay in seconds
     */
    public static void EnableLocalNotification(string title, string message, int delay)
    {
		Enhance.EnableLocalNotification (title, message, delay);
    }

    /**
     * Disable local notifications
     */
    static public void DisableLocalNotification()
    {
		Enhance.DisableLocalNotification ();
    }

    ///// PRIVATE /////
    static public void InitializeEnhance()
    {
        if (!mInitialized)
        {
            mInitialized = true;

#if UNITY_EDITOR
            FGLEditorInternals.Initialize();
#elif UNITY_ANDROID
            FGLAndroidInternals.Initialize();
#elif UNITY_IOS
            FGLiOSInternals.Initialize();
#endif
        }
    }

    static bool mInitialized = false;
}
