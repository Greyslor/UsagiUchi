using GoogleMobileAds.Api;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class AdManager : MonoBehaviour
{
    private int contador;
    public Text contadorText;

    public enum RewardType
    {
        Zanahoria,
        Alfalfa,
        Corral,
        Almohada
    }

    private readonly int zanahoriaReward = 2;
    private readonly int alfalfaReward = 3;
    private readonly int corralReward = 1;
    private readonly int almohadaReward = 1;

    private RewardType selectedRewardType;
    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
    private string adUnitIdRewarded = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
  private string adUnitIdRewarded = "ca-app-pub-3940256099942544/1712485313";
#else
  private string adUnitIdRewarded = "unused";
#endif

    private RewardedAd rewardedAd;

    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
    private string adUnitIdBanner = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
  private string adUnitIdBanner = "ca-app-pub-3940256099942544/2934735716";
#else
  private string adUnitIdBanner = "unused";
#endif

    BannerView bannerView;

    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        contadorText.text = contador.ToString();
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // This callback is called once the MobileAds SDK is initialized.
            RequestBanner();
            LoadRewardedAd();
        });
    }
    public void RequestBanner()
    {
        Debug.Log("Creating banner view");

        // If we already have a banner, destroy the old one.
        if (bannerView != null)
        {
            bannerView.Destroy();
        }

        // Create a 320x50 banner at bottom of the screen
        bannerView = new BannerView(adUnitIdBanner, AdSize.Banner, AdPosition.Bottom);

        var adRequest = new AdRequest();

        Debug.Log("Loading banner ad.");
        bannerView.LoadAd(adRequest);
    }

    private void ListenToAdEvents()
    {
        // Raised when an ad is loaded into the banner view.
        bannerView.OnBannerAdLoaded += () =>
        {
            Debug.Log("Banner view loaded an ad with response : "
                + bannerView.GetResponseInfo());
        };
        // Raised when an ad fails to load into the banner view.
        bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.LogError("Banner view failed to load an ad with error : "
                + error);
            RequestBanner();
        };
        // Raised when the ad is estimated to have earned money.
        bannerView.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Banner view paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        bannerView.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Banner view recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        bannerView.OnAdClicked += () =>
        {
            Debug.Log("Banner view was clicked.");
        };
        // Raised when an ad opened full screen content.
        bannerView.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Banner view full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        bannerView.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Banner view full screen content closed.");
        };
    }
    public void LoadRewardedAd()
    {
        // Clean up the old ad before loading a new one.
        if (rewardedAd != null)
        {
            rewardedAd.Destroy();
            rewardedAd = null;
        }

        Debug.Log("Loading the rewarded ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        RewardedAd.Load(adUnitIdRewarded, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("Rewarded ad failed to load an ad " +
                                   "with error : " + error);
                    return;
                }

                Debug.Log("Rewarded ad loaded with response : "
                          + ad.GetResponseInfo());

                rewardedAd = ad;
            });

    }

    public void SetRewardType(RewardType rewardType)
    {
        selectedRewardType = rewardType;
    }
    public void ShowRewardedAd()
    {
        const string rewardMsg =
            "Rewarded ad rewarded the user. Type: {0}, amount: {1}.";

        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) =>
            {
                // TODO: Reward the user.
                Debug.Log(String.Format(rewardMsg, reward.Type, reward.Amount));

                //lógica para recompensar al jugador

                contador += (int)reward.Amount;
                contadorText.text = contador.ToString();
            });
        }
    }

    private void GrantReward()
    {
        switch (selectedRewardType)
        {
            case RewardType.Zanahoria:
                contador += zanahoriaReward;
                Debug.Log("Has ganado " + zanahoriaReward + " Zanahorias");
                break;
            case RewardType.Alfalfa:
                contador += alfalfaReward;
                Debug.Log("Has ganado " + alfalfaReward + " Alfalfa");
                break;
            case RewardType.Corral:
                contador += corralReward;
                Debug.Log("Has ganado " + corralReward + " Corral");
                break;
            case RewardType.Almohada:
                contador += almohadaReward;
                Debug.Log("Has ganado " + almohadaReward + " Almohada");
                break;
        }
    }

    private void RegisterEventHandlers(RewardedAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Rewarded ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Rewarded ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Rewarded ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Rewarded ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
            rewardedAd.Destroy();
            LoadRewardedAd();
            RegisterEventHandlers(rewardedAd);
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content " +
                           "with error : " + error);
            rewardedAd.Destroy();
            LoadRewardedAd();
            RegisterEventHandlers(rewardedAd);
        };
    }
}
