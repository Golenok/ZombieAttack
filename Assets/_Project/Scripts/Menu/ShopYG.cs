using UnityEngine;
using System.Collections;
using YG;

public class ShopYG : MonoBehaviour
{

    private SavingManagement _savingManagement;
    private Coroutine _initialSettings;
    private WaitForSeconds _ws = new WaitForSeconds(0.1f);

    void Start()
    {
        if (_savingManagement == null)
            _savingManagement = GameObject.Find("SavingManagement").GetComponent<SavingManagement>();
    }




    private void OnEnable()
    {
        YG2.onPurchaseSuccess += SuccessPurchased;
        YG2.onPurchaseFailed += FailedPurchased;
    }

    private void OnDisable()
    {
        YG2.onPurchaseSuccess -= SuccessPurchased;
        YG2.onPurchaseFailed -= FailedPurchased;
    }

    private void SuccessPurchased(string id)
    {
        if (id == "Money")
            But_AddMoney(777);
        //if (id == "Top")
        //    But_AddMoney(111);
    }

    private void FailedPurchased(string id)
    {
        // Покупка не была совершена  ShopYG
    }

    private void But_AddMoney(int money)
    {
        _savingManagement.SetInt("Money", _savingManagement.GetInt("Money") + money);
    }

}
