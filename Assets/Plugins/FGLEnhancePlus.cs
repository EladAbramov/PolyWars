/**
 * Enhance connector for Unity
 */

using UnityEngine;
using System;
using FGL.Enhance.Internals;

/**
 * @deprecated
 */

public class FGLEnhancePlus
{
    ///// PUBLIC /////

    /**
     * Log debug message to the console
     * 
     * @param tag tag to use
     * @param message message to log
     */
    public static void LogMessage(string tag, string message)
    {
        Enhance.InitializeEnhance();

#if UNITY_EDITOR
        FGLEditorInternals.LogMessage(tag, message);
#elif UNITY_ANDROID
        FGLAndroidInternals.LogMessage(tag, message);
#elif UNITY_IOS
        FGLiOSInternals.LogMessage(tag, message);
#endif
    }

    /**
	 * Update the value of a particular SDK key
	 *
	 * @param id ID of sdk to set key for
	 * @param key key to set
	 * @param value new value
     */
    public static void SetSdkValue(string sdkId, string key, string value)
    {
        Enhance.InitializeEnhance();

#if UNITY_EDITOR
        FGLEditorInternals.SetSdkValue(sdkId, key, value);
#elif UNITY_ANDROID
        FGLAndroidInternals.SetSdkValue(sdkId, key, value);
#elif UNITY_IOS
        FGLiOSInternals.SetSdkValue(sdkId, key, value);
#endif
    }

    /**
	 * Set current screen
	 *
	 * @param name name of the currently displayed screen
	 */
    public static void SetCurrentScreen(string name)
    {
        Enhance.InitializeEnhance();

#if UNITY_EDITOR
        FGLEditorInternals.SetCurrentScreen(name);
#elif UNITY_ANDROID
        FGLAndroidInternals.SetCurrentScreen(name);
#elif UNITY_IOS
        FGLiOSInternals.SetCurrentScreen(name);
#endif
    }
}
