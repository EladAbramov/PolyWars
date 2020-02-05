using UnityEngine;
using System.Collections.Generic;

namespace FGL.Enhance.Internals
{
    public class FGLEditorInternals
    {

        public static void Initialize()
        {

        }

        public static void RequestInterstitialEvents(string bridgeObjectName)
        {
        }

        public static void SetCurrencyCallback(string bridgeObjectName)
        {
        }

        public static bool IsInterstitialReady(string placement)
        {
            return true;
        }

        public static void ShowInterstitialAd(string placement)
        {
			/*GameObject interstitial = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("Enhance_PlaceholderInterstitial"));
            interstitial.name = "Example Interstitial Ad";
            Debug.Log("[Enhance] Displaying interstitial ad");*/
        }

        public static bool IsRewardedAdReady(string placement)
        {
            return true;
        }

        public static void ShowRewardedAd(string placement, string bridgeObjectName)
        {
			/*GameObject rewarded = (GameObject)GameObject.Instantiate(Resources.Load<GameObject>("Enhance_PlaceholderRewarded"));
            rewarded.name = "Example Rewarded Ad";
            Debug.Log("[Enhance] Displaying rewarded ad");*/
        }

        public static void GrantReward()
        {
            GameObject callbackClass = GameObject.Find(FGLEnhance_Callbacks.CallbackObjectName);
            if (callbackClass == null) return;
            FGLEnhance_Callbacks enhanceCallbacks = callbackClass.GetComponent<FGLEnhance_Callbacks>();
            enhanceCallbacks.EnhanceOnCoinsRewardGranted("1");
        }

        public static bool IsBannerAdReady(string placement)
        {
            return true;
        }

        public static void ShowBannerAd(string placement, string position)
        {
            Debug.Log("[Enhance] Displaying banner ad");
        }

        public static void HideBannerAd()
        {
            Debug.Log("[Enhance] Hiding banner ad");
        }

        public static bool IsSpecialOfferReady(string placement)
        {
            return true;
        }

        public static void ShowSpecialOffer(string placement)
        {
            Debug.Log("[Enhance] Displaying special offer");
        }

        public static bool IsOfferwallReady(string placement)
        {
            return true;
        }

        public static void ShowOfferwall(string placement)
        {
            Debug.Log("[Enhance] Displaying offerwall");
        }

        public static void LogEvent(string eventType)
        {
            Debug.Log(string.Format("[Enhance] Log Event: {0}", eventType));
        }

        public static void LogEvent(string eventType, string paramKey, string paramValue)
        {
            Debug.Log(string.Format("[Enhance] Log Event: {0} ({1} = {2})", eventType, paramKey, paramValue));
        }

        public static void LogMessage(string tag, string message)
        {
            Debug.Log(string.Format("[Enhance] {0} {1}", tag, message));
        }

        public static void SetSdkValue(string sdkId, string key, string value)
        {
        }

        public static void SetCurrentScreen(string name)
        {
        }

        public static void RequestLocalNotificationsPermission(string bridgeObjectName)
        {
        }

        public static void EnableLocalNotifications(string title, string message, int delay)
        {
        }

        public static void DisableLocalNotifications()
        {
        }

        public static bool IsPurchasingSupported()
        {
            return false;
        }

        public static void AttemptPurchase(string sku, string bridgeObjectName)
        {
            GameObject callbackClass = GameObject.Find(FGLEnhance_Callbacks.CallbackObjectName);
            FGLEnhance_Callbacks enhanceCallbacks = callbackClass.GetComponent<FGLEnhance_Callbacks>();
            enhanceCallbacks.EnhanceOnPurchaseFailed("");
        }

        public static void ConsumePurchase(string sku, string bridgeObjectName)
        {
            GameObject callbackClass = GameObject.Find(FGLEnhance_Callbacks.CallbackObjectName);
            FGLEnhance_Callbacks enhanceCallbacks = callbackClass.GetComponent<FGLEnhance_Callbacks>();
            enhanceCallbacks.EnhanceOnConsumeFailed("");
        }

        public static string GetDisplayPrice(string sku, string defaultPrice)
        {
            return defaultPrice;
        }

        public static bool IsItemOwned(string sku)
        {
            return false;
        }

		public static int GetOwnedItemCount(string sku)
		{
			return 0;
		}

        public static bool IsRestoringNeeded()
        {
            return false;
        }

        public static void RestorePurchases(string bridgeObjectName)
        {
            GameObject callbackClass = GameObject.Find(FGLEnhance_Callbacks.CallbackObjectName);
            FGLEnhance_Callbacks enhanceCallbacks = callbackClass.GetComponent<FGLEnhance_Callbacks>();
            enhanceCallbacks.EnhanceOnRestoreSuccess("");
        }

        public static void RequestAppConfig(string bridgeObjectName)
        {
        }

        public static void SetSdkConfiguration(string sdkId, string configurationKey, string configurationValue)
		{
		}

		public static void LogEventWithParameters(string eventType, Dictionary<string, string> parameters)
		{
			Debug.Log(string.Format("[Enhance] Log Event With Parameters: {0}", eventType));
		}

		public static void SetOnReadyCallback(string bridgeObjectName)
		{
		}

		public static void SetOnCompleteCallback(string bridgeObjectName)
		{
		}

		public static void SetOnClickedCallback(string bridgeObjectName)
		{
		}

		public static void SetOnShowingCallback(string bridgeObjectName)
		{
		}

		public static void SetOnUnavailableCallback(string bridgeObjectName)
		{
		}

		public static void SetOnFailedToShowCallback(string bridgeObjectName)
		{
		}

		public static void SetOnLoadingCallback(string bridgeObjectName)
		{
		}
    }
}

