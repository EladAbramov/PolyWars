/**
 * @deprecated
 * Enhance connector for Unity
 */

using UnityEngine;
using System;
using FGL.Enhance.Internals;

public class FglEnhanceInAppPurchases
{
    ///// PUBLIC /////

    public static bool IsPurchasingSupported()
    {
		return Enhance.Purchases.IsSupported ();
    }

    public static void AttemptPurchase(string sku, Action onPurchaseSuccessCallback, Action onPurchaseFailedCallback)
    {
		Enhance.Purchases.AttemptPurchase (sku, onPurchaseSuccessCallback, onPurchaseFailedCallback);
    }

    public static void ConsumePurchase(string sku, Action onConsumeSuccessCallback, Action onConsumeFailedCallback)
    {
		Enhance.Purchases.Consume (sku, onConsumeSuccessCallback, onConsumeFailedCallback);
    }

    public static string GetDisplayPrice(string sku, string defaultPrice)
    {
		return Enhance.Purchases.GetDisplayPrice (sku, defaultPrice);
    }

    public static bool IsItemOwned(string sku)
    {
		return Enhance.Purchases.IsItemOwned (sku);
    }

    public static bool IsRestoringNeeded()
    {
        FGLEnhance.InitializeEnhance();

#if UNITY_EDITOR
        return FGLEditorInternals.IsRestoringNeeded();
#elif UNITY_ANDROID
        return FGLAndroidInternals.IsRestoringNeeded();
#elif UNITY_IOS
        return FGLiOSInternals.IsRestoringNeeded();
#else
        return false;
#endif
    }

    public static void RestorePurchases(Action onRestoreSuccessCallback, Action onRestoreFailedCallback)
    {
        if (GameObject.Find(FGLEnhance_Callbacks.CallbackObjectName) == null)
        {
            string newName = "__FGLEnhance_Callback_" + UnityEngine.Random.Range(0, int.MaxValue);
            GameObject callbackObject = new GameObject(newName);
            callbackObject.AddComponent<FGLEnhance_Callbacks>();
        }

        FGLEnhance_Callbacks.OnRestoreSuccessCallback = onRestoreSuccessCallback;
        FGLEnhance_Callbacks.OnRestoreFailedCallback = onRestoreFailedCallback;

        FGLEnhance.InitializeEnhance();
#if UNITY_EDITOR
        FGLEditorInternals.RestorePurchases(FGLEnhance_Callbacks.CallbackObjectName);
#elif UNITY_ANDROID
        FGLAndroidInternals.RestorePurchases(FGLEnhance_Callbacks.CallbackObjectName);
#elif UNITY_IOS
		FGLiOSInternals.ManuallyRestorePurchases(FGLEnhance_Callbacks.CallbackObjectName);
#endif
    }
}
