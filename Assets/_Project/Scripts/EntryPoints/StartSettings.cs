using Unity.VisualScripting;
using UnityEngine;

public class StartSettings : MonoBehaviour
{
    private int _firstLaunch;
    private SavingManagement _savingManagement;


    public void Initialized()
    {
        if (_savingManagement == null)
            _savingManagement = GameObject.Find("SavingManagement").GetComponent<SavingManagement>();

        _firstLaunch = _savingManagement.GetInt("firstLaunch");
        if (_firstLaunch == 0)
        {
            SettingParameters();
            SettingParametersEnemy();
            SettingParametersPlayer();
        }
    }

    private void SettingParameters()
    {

    }

    private void SettingParametersPlayer()
    {

    }

    private void SettingParametersEnemy()
    {

    }

}
