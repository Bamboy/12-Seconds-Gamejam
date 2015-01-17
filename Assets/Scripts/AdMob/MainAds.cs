using UnityEngine;
using System;
using GoogleMobileAds;
using GoogleMobileAds.Api;

namespace Excelsion.Ads{
	public class MainAds : MonoBehaviour {
		public static BannerView bannerView;
		private InterstitialAd interstitial;

		private void Awake(){
			RequestBanner();
			if(UnityEngine.Random.value < 0.1f)
				RequestInterstitial();
		}
		private void RequestBanner(){//small banner on the screen
#if UNITY_EDITOR
			string adUnitId = "unused";
#elif UNITY_ANDROID
			string adUnitId = "ca-app-pub-9366101405481807/3675096775";
#elif UNITY_IPHONE
			string adUnitId = "";
#else
			string adUnitId = "unexpected_platform";
#endif
			//create 320x50 banner
			bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);
			//Register for ad events
			bannerView.AdLoaded += HandleAdLoaded;
			bannerView.AdFailedToLoad += HandleAdFailedToLoad;
			bannerView.AdOpened += HandleAdOpened;
			bannerView.AdClosing += HandleAdClosing;
			bannerView.AdClosed += HandleAdClosed;
			bannerView.AdLeftApplication += HandleAdLeftApplication;
			//load banner ad
			bannerView.LoadAd(createAdRequest());
		}
		private void RequestInterstitial(){//full screen ad
#if UNITY_EDITOR
			string adUnitId = "unused";
#elif UNITY_ANDROID
			string adUnitId = "ca-app-pub-9366101405481807/3675096775";
#elif UNITY_IPHONE
			string adUnitId = "";
#else
			string adUnitId = "unexpected_platform";
#endif
			//create an interstitial ad
			interstitial = new InterstitialAd(adUnitId);
			interstitial.AdLoaded += HandleInterstitialAdLoaded;
			interstitial.AdFailedToLoad += HandleAdInterstitialFailedToLoad;
			interstitial.AdOpened += HandleInterstitialAdOpened;
			interstitial.AdClosing += HandleInterstitialAdClosing;
			interstitial.AdClosed += HandleInterstitialAdClosed;
			interstitial.AdLeftApplication += HandleInterstitialAdLeftApplication;
			//load interstitial ad
			interstitial.LoadAd(createAdRequest());
		}
		private AdRequest createAdRequest(){
			return new AdRequest.Builder()
				.AddTestDevice(AdRequest.TestDeviceSimulator)
				.AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
				.AddKeyword("game")
				.SetGender(Gender.Male)
				.SetBirthday(new DateTime(1985, 1, 1))
				.TagForChildDirectedTreatment(false)
				.AddExtra("color_bg", "9B30FF")
				.Build();
		}

		void HandleAdLeftApplication (object sender, EventArgs e)
		{

		}

		void HandleAdClosed (object sender, EventArgs e)
		{

		}

		void HandleAdClosing (object sender, EventArgs e)
		{

		}

		void HandleAdOpened (object sender, EventArgs e)
		{

		}

		void HandleAdFailedToLoad (object sender, AdFailedToLoadEventArgs e)
		{

		}

		void HandleAdLoaded (object sender, EventArgs e)
		{

		}
		void HandleInterstitialAdLeftApplication (object sender, EventArgs e)
		{
			
		}
		
		void HandleInterstitialAdClosed (object sender, EventArgs e)
		{
			
		}
		
		void HandleInterstitialAdClosing (object sender, EventArgs e)
		{
			
		}
		
		void HandleInterstitialAdOpened (object sender, EventArgs e)
		{
			
		}
		
		void HandleAdInterstitialFailedToLoad (object sender, AdFailedToLoadEventArgs e)
		{
			
		}
		
		void HandleInterstitialAdLoaded (object sender, EventArgs e)
		{
			
		}
	}
}