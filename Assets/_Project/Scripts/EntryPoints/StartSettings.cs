using Unity.VisualScripting;
using UnityEngine;
using YG;

public class StartSettings : MonoBehaviour
{
    private int _firstLaunch;
    private SavingManagement _savingManagement;


    public void Initialized()
    {
        if (_savingManagement == null)
            _savingManagement = GameObject.Find("SavingManagement").GetComponent<SavingManagement>();

        _firstLaunch = _savingManagement.GetInt("firstLaunch");
        _firstLaunch = 0;
        Debug.Log("Убрать _firstLaunch = 0;");
        if (_firstLaunch == 0)
        {
            SettingParameters();
            SettingParametersEnemy();
            SettingParametersPlayer();
        }
    }

    private void SettingParameters()
    {
        YG2.SetLeaderboard("Top", 0);
        if (_savingManagement.GetInt("Premium") >= 1)
            _savingManagement.SetInt("Premium", 0);                 
        //_savingManagement.SetString("LoadingScene", "Lvl_01");
        _savingManagement.SetString("LoadingScene", "Menu");
        _savingManagement.SetInt("firstLaunch", 1);                 
                                                                    
    }

    private void SettingParametersPlayer()
    {

    }

    private void SettingParametersEnemy()
    {

    }

}
