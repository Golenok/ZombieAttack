using System.Collections;
using TMPro;
using UnityEngine;
using YG;

public class RateGame : MonoBehaviour
{
    [Header("Оценить игру")]
    [SerializeField] private GameObject _rate;
    private WaitForSeconds _ws = new WaitForSeconds(0.1f);
    private Coroutine _initialSettings;
    private SavingManagement _savingManagement;

    private void Start()
    {
        if (_savingManagement == null)
            _savingManagement = GameObject.Find("SavingManagement").GetComponent<SavingManagement>();
        if (_savingManagement.GetInt("RateGame") == 1)
        {
            _rate.SetActive(false);
        }
    }

    public void But_RateGame()
    {
        YG2.onReviewSent += CheckReviewReward;
        YG2.ReviewShow();
        if (_savingManagement.GetInt("RateGame") == 0)
        {
            _savingManagement.SetInt("RateGame", 1);
        }
    }

    private void CheckReviewReward(bool success)
    {
        Debug.Log("Дать денег за голосование");
        //_entryPoint.AddCrystals(10000);
        YG2.onReviewSent -= CheckReviewReward;
    }
}
