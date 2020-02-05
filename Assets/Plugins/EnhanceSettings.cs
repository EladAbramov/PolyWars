/**
 * Enhance connector for Unity
Add a comment to this line
 */

using UnityEngine;
using System;
using FGL.Enhance.Internals;

public class EnhanceSettings
{

	private static void _SetSdkConfiguration(string sdkId, string configurationKey, string configurationValue)
    {
        Enhance.InitializeEnhance();

#if UNITY_EDITOR
		FGLEditorInternals.SetSdkConfiguration(sdkId, configurationKey, configurationValue);
#elif UNITY_ANDROID
		FGLAndroidInternals.SetSdkConfiguration(sdkId, configurationKey, configurationValue);
#elif UNITY_IOS
		FGLiOSInternals.SetSdkConfiguration(sdkId, configurationKey, configurationValue);
#endif
    }

	public void SetSdkConfiguration(string sdkId, string configurationKey, string configurationValue)
	{
		_SetSdkConfiguration (sdkId, configurationKey, configurationValue);
	}

}
