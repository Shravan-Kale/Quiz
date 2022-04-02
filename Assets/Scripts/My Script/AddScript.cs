using UnityEngine;
using UnityEngine.SceneManagement;
using admob;

public class AddScript : MonoBehaviour
{
	AdSize adSizeOnMenu = new AdSize(200, 50);
	AdSize adSizeOnPlay = new AdSize(50, 50);

	#region Admob
	Admob ad;
	//string appID="";
	string bannerID = "";
	string interstitialID = "";
	string videoID = "";
	string nativeBannerID = "";

	void Awake()
	{
		Debug.Log("Awake is called!----------");
		initAdmob();
	}

	void Update()
	{
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			Debug.Log(KeyCode.Escape + "-----------------");
		}
	}
	void initAdmob()
	{
#if UNITY_IOS
        		// appID="ca-app-pub-3940256099942544~1458002511";
				 bannerID="ca-app-pub-3940256099942544/2934735716";
				 interstitialID="ca-app-pub-3940256099942544/4411468910";
				 videoID="ca-app-pub-3940256099942544/1712485313";
				 nativeBannerID = "ca-app-pub-3940256099942544/3986624511";
#elif UNITY_ANDROID
        		 //appID="ca-app-pub-3940256099942544~3347511713";
				 bannerID="ca-app-pub-3940256099942544/6300978111";
				 interstitialID="ca-app-pub-3940256099942544/1033173712";
				 videoID="ca-app-pub-3940256099942544/5224354917";
				 nativeBannerID = "ca-app-pub-3940256099942544/2247696110";
#endif
		AdProperties adProperties = new AdProperties();
		adProperties.isTesting(false);
		adProperties.isAppMuted(true);
		adProperties.isUnderAgeOfConsent(false);
		adProperties.appVolume(100);
		adProperties.maxAdContentRating(AdProperties.maxAdContentRating_G);
		string[] keywords = { "diagram", "league", "brambling" };
		adProperties.keyworks(keywords);

		ad = Admob.Instance();
		ad.bannerEventHandler += onBannerEvent;
		ad.interstitialEventHandler += onInterstitialEvent;
		ad.rewardedVideoEventHandler += onRewardedVideoEvent;
		ad.nativeBannerEventHandler += onNativeBannerEvent;
		ad.initSDK(adProperties);//reqired,adProperties can been null
	}

	void onInterstitialEvent(string eventName, string msg)
	{
		Debug.Log("handler onAdmobEvent---" + eventName + "   " + msg);
		if (eventName == AdmobEvent.onAdLoaded)
		{
			Admob.Instance().showInterstitial();
		}
	}
	void onBannerEvent(string eventName, string msg)
	{
		Debug.Log("handler onAdmobBannerEvent---" + eventName + "   " + msg);
	}
	void onRewardedVideoEvent(string eventName, string msg)
	{
		Debug.Log("handler onRewardedVideoEvent---" + eventName + "  rewarded: " + msg);
	}
	void onNativeBannerEvent(string eventName, string msg)
	{
		Debug.Log("handler onAdmobNativeBannerEvent---" + eventName + "   " + msg);
	}
	#endregion
	
	private void Start()
    {
		loadBannerOnStart();
    }
	
	public void loadBannerOnStart()
	{
		Admob.Instance().showBannerRelative(bannerID, adSizeOnMenu, AdPosition.BOTTOM_CENTER);
	}

	public void destroyBanner()
    {
		Admob.Instance().removeBanner();
		Admob.Instance().removeBanner("mybanner");
		Admob.Instance().removeNativeBanner();
	}

	public void loadBannerOnPlay()
    {
		Admob.Instance().showBannerRelative(bannerID, adSizeOnPlay, AdPosition.BOTTOM_CENTER);
	}
}
