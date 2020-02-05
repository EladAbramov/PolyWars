using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AdManager : MonoBehaviour
{

	private bool _isBannerAdShown = false;
	private bool _hasLocalNotificationPermission = false;

	void Awake()
	{
		// Ask for permission to show local notifications
		// It can be done at any point in the application

		if (!_hasLocalNotificationPermission)
			Enhance.RequestLocalNotificationPermission(OnPermissionGranted, OnPermissionRefused);

		// Set currency callback (offerwalls)
		// It is important to do in the beginning of the application's logic

	}

	// Interstitial Ad

	public void OnShowInterstitialAd()
	{
		// Check whether an interstitial ad is ready

		if (!Enhance.IsInterstitialReady())
		{
			return;
		}

		// The ad is ready

		Enhance.ShowInterstitialAd();
	}

	// Rewarded Ad

	public void OnShowRewardedAd()
	{
		// Check whether a rewarded ad is ready 
		if (!Enhance.IsRewardedAdReady())
		{
			return;
		}

	}

	// Analytics

	public void OnLogEvent()
	{
		// Send a custom event to analytics network(e.g. Google Analytics)

		// Simple event:
		Enhance.LogEvent("event_type");

		// Event with an additional parameter:
		Enhance.LogEvent("event_type", "event_param_key", "event_param_value");

	}

	// Offerwall

	public void OnShowOfferwall()
	{
		// Check whether an offerwall is available

		if (!Enhance.IsOfferwallReady())
		{
			return;
		}

		// The offerwall is ready, show it

		Enhance.ShowOfferwall();
	}

	// Special Offer

	public void OnShowSpecialOffer()
	{
		// Check whether a special offer is available

		if (!Enhance.IsSpecialOfferReady())
		{
			return;
		}

		// The special offer is ready, display it

		Enhance.ShowSpecialOffer();
	}

	// Local Notification

	public void OnEnableLocalNotification()
	{
		// Check if we have permission to schedule notification

		if (!_hasLocalNotificationPermission)
		{
			return;
		}

		// We have permission, enable a local notification
		// It will appear 5 seconds after the app is deactivated

		Enhance.EnableLocalNotification("Enhance", "Local Notification!", 5);
	}

	public void OnDisableLocalNotification()
	{
		// Cancel previously scheduled notification
		Enhance.DisableLocalNotification();
	}

	// GDPR

	public void OnGDPROptIn()
	{
		Enhance.ServiceTermsOptIn();
	}

	public void OnGDPROptOut()
	{
		Enhance.ServiceTermsOptOut();
	}

	private void OnOptInNotRequired()
	{
		// No action needed
	}

	// Permission callbacks

	private void OnPermissionGranted()
	{
		_hasLocalNotificationPermission = true;
	}

	private void OnPermissionRefused()
	{
		_hasLocalNotificationPermission = false;
	}

	
}


