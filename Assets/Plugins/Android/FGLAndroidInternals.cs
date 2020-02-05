#if UNITY_ANDROID
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace FGL.Enhance.Internals
{
    internal class FGLAndroidInternals
    {
        public static void Initialize()
        {
        }
        
        public static void SetCurrencyCallback(string bridgeObjectName)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("setCurrencyCallback", bridgeObjectName);
        }

        public static void RequestInterstitialEvents(string bridgeObjectName)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("requestInterstitialEvents", bridgeObjectName);
        }

        public static bool IsInterstitialReady(string placement)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            return adConnectorClass.CallStatic<bool>("isInterstitialReady", placement);
        }

        public static void ShowInterstitialAd(string placement)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("showInterstitialAd", placement);
        }

        public static bool IsRewardedAdReady(string placement)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            return adConnectorClass.CallStatic<bool>("isRewardedAdReady", placement);
        }

        public static void ShowRewardedAd(string placement, string bridgeObjectName)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("showRewardedAd", placement, bridgeObjectName);
        }

		public static bool IsBannerAdReady(string placement)
		{
			AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
			return adConnectorClass.CallStatic<bool>("isBannerAdReady", placement);
		}

		public static void ShowBannerAd(string placement, string position)
		{
			AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
			adConnectorClass.CallStatic("showBannerAd", placement, position);
		} 

		public static void HideBannerAd()
		{
			AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
			adConnectorClass.CallStatic("hideBannerAd");
		}

        public static bool IsSpecialOfferReady(string placement)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            return adConnectorClass.CallStatic<bool>("isSpecialOfferReady", placement);
        }

        public static void ShowSpecialOffer(string placement)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("showSpecialOffer", placement);
        }

        public static bool IsOfferwallReady(string placement)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            return adConnectorClass.CallStatic<bool>("isOfferwallReady", placement);
        }

        public static void ShowOfferwall(string placement)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("showOfferwall", placement);
        }

        public static void LogEvent(string eventType)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("logEvent", eventType, null, null);
        }

        public static void LogEvent(string eventType, string paramKey, string paramValue)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("logEvent", eventType, paramKey, paramValue);
        }

        public static void LogMessage(string tag, string message)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("logMessage", tag, message);
        }

        public static void SetSdkValue(string sdkId, string key, string value)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("setSdkValue", sdkId, key, value);
        }

        public static void SetCurrentScreen(string name)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("setCurrentScreen", name);
        }

        public static void RequestLocalNotificationsPermission(string bridgeObjectName)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("requestLocalNotificationsPermission", bridgeObjectName);
        }

        public static void EnableLocalNotifications(string title, string message, int delay)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("enableLocalNotifications", title, message, delay);
        }

        public static void DisableLocalNotifications()
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("disableLocalNotifications");
        }

        public static bool IsPurchasingSupported()
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            return adConnectorClass.CallStatic<bool>("isPurchasingSupported");
        }

        public static void AttemptPurchase(string sku, string bridgeObjectName)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("attemptPurchase", sku, bridgeObjectName);
        }

        public static void ConsumePurchase(string sku, string bridgeObjectName)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("consumePurchase", sku, bridgeObjectName);
        }

        public static string GetDisplayPrice(string sku, string defaultPrice)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            return adConnectorClass.CallStatic<string>("getPurchaseDisplayPrice", sku, defaultPrice);
        }

        public static bool IsItemOwned(string sku)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            return adConnectorClass.CallStatic<bool>("isPurchaseItemOwned", sku);
        }

		public static int GetOwnedItemCount(string sku)
		{
			AndroidJavaClass adConnectorClass = new AndroidJavaClass ("com.fgl.enhance.unityconnector.FGLUnityConnector");
			return adConnectorClass.CallStatic<int>("getOwnedItemCount", sku);
		}

        public static bool IsRestoringNeeded()
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            return adConnectorClass.CallStatic<bool>("isRestoringNeeded");
        }

        public static void RestorePurchases(string bridgeObjectName)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("restorePurchases", bridgeObjectName);
        }

        public static void RequestAppConfig(string bridgeObjectName)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("requestAppConfig", bridgeObjectName);
        }

        public static void ManuallyRestorePurchases(string bridgeObjectName)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("manuallyRestorePurchases", bridgeObjectName);
        }

        public static string GetDisplayTitle(string sku, string defaultTitle)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            return adConnectorClass.CallStatic<string>("getDisplayTitle", sku, defaultTitle);
        }

        public static string GetDisplayDescription(string sku, string defaultDescription)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            return adConnectorClass.CallStatic<string>("getDisplayDescription", sku, defaultDescription);
        }

        public static void RequiresDataConsentOptIn(string bridgeObjectName)
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("requiresDataConsentOptIn", bridgeObjectName);
        }

        public static void ServiceTermsOptIn(string[] requestedSdks)
        {
            string requestedSdksString = null;
            if(requestedSdks != null) requestedSdksString = string.Join(",", requestedSdks);

            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("serviceTermsOptIn", requestedSdksString);
        }

        public static void ShowServiceOptInDialogs(string[] requestedSdks, string bridgeObjectName)
        {
            string requestedSdksString = null;
            if(requestedSdks != null) requestedSdksString = string.Join(",", requestedSdks);

            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("showServiceOptInDialogs", requestedSdksString, bridgeObjectName);
        }

        public static void ServiceTermsOptOut()
        {
            AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
            adConnectorClass.CallStatic("serviceTermsOptOut");
        }

        public static void LogEventWithParameters(string eventType, Dictionary<string, string> parameters){
			string[] paramArray = new string[parameters.Count];
			int i = 0;
			string paramsJson = "{";
    		foreach(KeyValuePair<string, string> entry in parameters)
			{
				paramArray[i] = "\""+entry.Key+"\":\"" + entry.Value + "\"";
				i++;
			}
			paramsJson += string.Join( ",", paramArray );
			paramsJson += "}";
			AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
			adConnectorClass.CallStatic("logEventWithParameters", eventType, paramsJson);
		}

		public static void SetSdkConfiguration(string sdkId, string configurationKey, string configurationValue){
			AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
			adConnectorClass.CallStatic("setSdkConfiguration", sdkId, configurationKey, configurationValue);
		}

		public static void SetOnReadyCallback(string bridgeObjectName)
		{
			AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
			adConnectorClass.CallStatic("setOnReadyCallback", bridgeObjectName);
		}

		public static void SetOnCompleteCallback(string bridgeObjectName)
		{
			AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
			adConnectorClass.CallStatic("setOnCompleteCallback", bridgeObjectName);
		}

		public static void SetOnClickedCallback(string bridgeObjectName)
		{
			AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
			adConnectorClass.CallStatic("setOnClickedCallback", bridgeObjectName);
		}

		public static void SetOnShowingCallback(string bridgeObjectName)
		{
			AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
			adConnectorClass.CallStatic("setOnShowingCallback", bridgeObjectName);
		}

		public static void SetOnUnavailableCallback(string bridgeObjectName)
		{
			AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
			adConnectorClass.CallStatic("setOnUnavailableCallback", bridgeObjectName);
		}

		public static void SetOnFailedToShowCallback(string bridgeObjectName)
		{
			AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
			adConnectorClass.CallStatic("setOnFailedToShowCallback", bridgeObjectName);
		}

		public static void SetOnLoadingCallback(string bridgeObjectName)
		{
			AndroidJavaClass adConnectorClass = new AndroidJavaClass("com.fgl.enhance.unityconnector.FGLUnityConnector");
			adConnectorClass.CallStatic("setOnLoadingCallback", bridgeObjectName);
        }
    }
}
#endif
