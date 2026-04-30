using UnityEngine;
using YG;

public class LaunchingAds : MonoBehaviour
{
    private SavingManagement _savingManagement;
    private void Start()
    {
        if (_savingManagement == null)
            _savingManagement = GameObject.Find("SavingManagement").GetComponent<SavingManagement>();
    }

    public void ShowAdvertising()
    {
        if (_savingManagement.GetInt("Premium") <= 0)
        {
            YG2.InterstitialAdvShow();
        }   
    }

    public void AwardAdv()
    {
        if (_savingManagement.GetInt("Premium") <= 0)
        {
            YG2.RewardedAdvShow("GetBonus");
        }
        else
        {
            GetBonus();
        }
    }

    public void GetBonus()
    {
        
    }


}
