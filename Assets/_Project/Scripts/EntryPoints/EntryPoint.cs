using System.Collections;
using UnityEngine;


public class EntryPoint : MonoBehaviour
{
    public static EntryPoint instance;
    private static bool _firstLaunchBool;

    private Coroutine _initialParameters;
    private WaitForSeconds _ws = new WaitForSeconds(0.1f);

    private SavingManagement _savingManagement;
    //private StartSettings _startSettings;

    //private SavesYG _savesYG;
    private void Start()
    {
        Debug.Log("Переводчик ");
        Debug.Log("Загрузка уровня ");
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);

        //if (_savingManagement == null)
        //    _savingManagement = GameObject.Find("SavingManagement").GetComponent<SavingManagement>();
        //if (_startSettings == null)
        //    _startSettings = GameObject.Find("StartSettings").GetComponent<StartSettings>();
        //if (_savingManagement == null || _startSettings == null)
        //{
        //    _initialParameters = StartCoroutine(InitialParameters());
        //}
        //else
        //{
        //    _startSettings.Initialized();
        //    _crystals = _savingManagement.GetInt("CrystalMoney");
        //    SceneManager.LoadScene("LoadingScene");
        //    _done = true;
        //}
    }

    IEnumerator InitialParameters()
    {
        yield return _ws;
        //if (_savingManagement == null)
        //    _savingManagement = GameObject.Find("SavingManagement").GetComponent<SavingManagement>();
        //if (_startSettings == null)
        //    _startSettings = GameObject.Find("StartSettings").GetComponent<StartSettings>();
        //if (_savingManagement == null || _startSettings == null)
        //{
        //    _initialParameters = StartCoroutine(InitialParameters());
        //}
        //else
        //{
        //    _startSettings.Initialized();
        //    _crystals = _savingManagement.GetInt("CrystalMoney");
        //    SceneManager.LoadScene("LoadingScene");
        //    _done = true;
        //yield break;
        //}
    }

    public void SetFirstLaunchBool(bool flag)
    {
        _firstLaunchBool = flag;
    }

    public bool GetFirstLaunchBool()
    {
        return _firstLaunchBool;
    }



}
