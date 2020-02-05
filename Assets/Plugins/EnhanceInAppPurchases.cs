/**
 * Enhance connector for Unity
 */

using UnityEngine;
using System;
using FGL.Enhance.Internals;

public class EnhanceInAppPurchases
{
    ///// PUBLIC /////

    private static bool _IsSupported()
    {
        Enhance.InitializeEnhance();

#if UNITY_EDITOR
        return FGLEditorInternals.IsPurchasingSupported();
#elif UNITY_ANDROID
        return FGLAndroidInternals.IsPurchasingSupported();
#elif UNITY_IOS
        return FGLiOSInternals.IsPurchasingSupported();
#else
        return false;
#endif
    }

    private static void _AttemptPurchase(string sku, Action onPurchaseSuccessCallback, Action onPurchaseFailedCallback)
    {
        if (GameObject.Find(FGLEnhance_Callbacks.CallbackObjectName) == null)
        {
            string newName = "__FGLEnhance_Callback_" + UnityEngine.Random.Range(0, int.MaxValue);
            GameObject callbackObject = new GameObject(newName);
            callbackObject.AddComponent<FGLEnhance_Callbacks>();
        }

        FGLEnhance_Callbacks.OnPurchaseSuccessCallback = onPurchaseSuccessCallback;
        FGLEnhance_Callbacks.OnPurchaseFailedCallback = onPurchaseFailedCallback;

        Enhance.InitializeEnhance();
#if UNITY_EDITOR
        FGLEditorInternals.AttemptPurchase(sku, FGLEnhance_Callbacks.CallbackObjectName);
#elif UNITY_ANDROID
        FGLAndroidInternals.AttemptPurchase(sku, FGLEnhance_Callbacks.CallbackObjectName);
#elif UNITY_IOS
        FGLiOSInternals.AttemptPurchase(sku, FGLEnhance_Callbacks.CallbackObjectName);
#endif
    }

	private static void _Consume(string sku, Action onConsumeSuccessCallback, Action onConsumeFailedCallback)
	{
		if (GameObject.Find(FGLEnhance_Callbacks.CallbackObjectName) == null)
		{
			string newName = "__FGLEnhance_Callback_" + UnityEngine.Random.Range(0, int.MaxValue);
			GameObject callbackObject = new GameObject(newName);
			callbackObject.AddComponent<FGLEnhance_Callbacks>();
		}

		FGLEnhance_Callbacks.OnConsumeSuccessCallback = onConsumeSuccessCallback;
		FGLEnhance_Callbacks.OnConsumeFailedCallback = onConsumeFailedCallback;

		Enhance.InitializeEnhance();
#if UNITY_EDITOR
		FGLEditorInternals.ConsumePurchase(sku, FGLEnhance_Callbacks.CallbackObjectName);
#elif UNITY_ANDROID
		FGLAndroidInternals.ConsumePurchase(sku, FGLEnhance_Callbacks.CallbackObjectName);
#elif UNITY_IOS
		FGLiOSInternals.ConsumePurchase(sku, FGLEnhance_Callbacks.CallbackObjectName);
#endif
	}

    private static string _GetDisplayPrice(string sku, string defaultPrice)
    {
        Enhance.InitializeEnhance();

#if UNITY_EDITOR
        return FGLEditorInternals.GetDisplayPrice(sku, defaultPrice);
#elif UNITY_ANDROID
        return FGLAndroidInternals.GetDisplayPrice(sku, defaultPrice);
#elif UNITY_IOS
        return FGLiOSInternals.GetDisplayPrice(sku, defaultPrice);
#else
        return defaultPrice;
#endif
    }

    private static bool _IsItemOwned(string sku)
    {
        Enhance.InitializeEnhance();

#if UNITY_EDITOR
        return FGLEditorInternals.IsItemOwned(sku);
#elif UNITY_ANDROID
        return FGLAndroidInternals.IsItemOwned(sku);
#elif UNITY_IOS
        return FGLiOSInternals.IsItemOwned(sku);
#else
        return false;
#endif
    }

	private static int _GetOwnedItemCount(string sku)
	{
		Enhance.InitializeEnhance ();

#if UNITY_EDITOR
		return FGLEditorInternals.GetOwnedItemCount(sku);
#elif UNITY_ANDROID
		return FGLAndroidInternals.GetOwnedItemCount(sku);
#elif UNITY_IOS
		return FGLiOSInternals.GetOwnedItemCount(sku);
#else
		return 0;
#endif	
	}

	private static void _ManuallyRestorePurchases(Action onRestoreSuccessCallback, Action onRestoreFailedCallback) 
	{
		if (GameObject.Find(FGLEnhance_Callbacks.CallbackObjectName) == null)
        {
            string newName = "__FGLEnhance_Callback_" + UnityEngine.Random.Range(0, int.MaxValue);
            GameObject callbackObject = new GameObject(newName);
            callbackObject.AddComponent<FGLEnhance_Callbacks>();
        }

        FGLEnhance_Callbacks.OnRestorePurchasesSuccessCallback = onRestoreSuccessCallback;
        FGLEnhance_Callbacks.OnRestorePurchasesFailedCallback = onRestoreFailedCallback;

        Enhance.InitializeEnhance();
#if UNITY_ANDROID
        FGLAndroidInternals.ManuallyRestorePurchases(FGLEnhance_Callbacks.CallbackObjectName);
#elif UNITY_IOS
		FGLiOSInternals.ManuallyRestorePurchases(FGLEnhance_Callbacks.CallbackObjectName);
#endif
	}

	private static string _GetDisplayTitle(string sku, string defaultTitle)
	{
		Enhance.InitializeEnhance();

#if UNITY_EDITOR
		return defaultTitle;
#elif UNITY_ANDROID
		return FGLAndroidInternals.GetDisplayTitle(sku, defaultTitle);
#elif UNITY_IOS
		return FGLiOSInternals.GetDisplayTitle(sku, defaultTitle);
#endif
	}

	private static string _GetDisplayDescription(string sku, string defaultDescription)
	{
		Enhance.InitializeEnhance();

#if UNITY_EDITOR
		return defaultDescription;
#elif UNITY_ANDROID
		return FGLAndroidInternals.GetDisplayDescription(sku, defaultDescription);
#elif UNITY_IOS
		return FGLiOSInternals.GetDisplayDescription(sku, defaultDescription);
#endif
	}

	public bool IsSupported()
	{
		return _IsSupported ();
	}

	public void AttemptPurchase(string sku, Action onPurchaseSuccessCallback, Action onPurchaseFailedCallback)
	{
		_AttemptPurchase (sku, onPurchaseSuccessCallback, onPurchaseFailedCallback);
	}

	public void Consume(string sku, Action onConsumeSuccessCallback, Action onConsumeFailedCallback)
	{
		_Consume (sku, onConsumeSuccessCallback, onConsumeFailedCallback);
	}

	public string GetDisplayPrice(string sku, string defaultPrice)
	{
		return _GetDisplayPrice (sku, defaultPrice);
	}

	public bool IsItemOwned(string sku)
	{
		return _IsItemOwned (sku);
	}

	public int GetOwnedItemCount(string sku)
	{
		return _GetOwnedItemCount (sku);
	}

	public void ManuallyRestorePurchases(Action onRestoreSuccessCallback, Action onRestoreFailedCallback)
	{
		_ManuallyRestorePurchases(onRestoreSuccessCallback, onRestoreFailedCallback);
	}

	public string GetDisplayTitle(string sku, string defaultTitle)
	{
		return _GetDisplayTitle(sku, defaultTitle);
	}

	public string GetDisplayDescription(string sku, string defaultDescription)
	{
		return _GetDisplayDescription(sku, defaultDescription);
	}
}