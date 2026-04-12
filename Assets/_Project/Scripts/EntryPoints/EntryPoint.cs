
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
//using YG;

public class EntryPoint : MonoBehaviour
{
    public static EntryPoint instance;
    private int _crystals, _phoenix;
    private bool _done = false;
    private SavingManagement _savingManagement;
    private StartSettings _startSettings;
    private Coroutine _initialParameters;
    private WaitForSeconds _ws = new WaitForSeconds(0.1f);
    private static int _langId;

    private void Start()
    {
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
        _initialParameters = StartCoroutine(InitialParameters());
    }
    IEnumerator InitialParameters()
    {
        yield return _ws;
        //if (YG2.isSDKEnabled)
        //{
        //    if (_savingManagement == null)
        //        _savingManagement = GameObject.Find("SavingManagement").GetComponent<SavingManagement>();
        //    if (_startSettings == null)
        //        _startSettings = GameObject.Find("StartSettings").GetComponent<StartSettings>();
        //    _startSettings.Initialized();
        //    _crystals = _savingManagement.GetInt("CrystalMoney");
        //    _langId = 4;
        //    YG2.onCorrectLang += On—hangeLang;
        //    SceneManager.LoadScene("LoadingScene");
        //    yield break;
        //}
        //else
        //{
        //    _initialParameters = StartCoroutine(InitialParameters());
        //}
    }
    public int GetCrystals()
    {
        if (_done)
        {
            _crystals = _savingManagement.GetInt("CrystalMoney");
        }
        return _crystals;
    }
    public bool GetPhoenix()
    {
        _phoenix = _savingManagement.GetInt("Phoenix");
        if (_phoenix > 0)
        {
            _savingManagement.SetInt("Phoenix", _phoenix - 1);
            _savingManagement.SetFloat("PhoenixPercent", _savingManagement.GetFloat("PhoenixPercent") - 10.0f);
            _phoenix = _phoenix - 1;
            return true;
        }
        return false;
    }
    public void SetCrystals(int crystal)
    {
        _crystals = _crystals - crystal;
    }
    public void AddCrystals(int crystal)
    {
        _crystals = _crystals + crystal;
        BuyConfirm();
    }

    public void BuyConfirm() //œÓ‰Ú‚Â‰ËÚ¸ ÔÓÍÛÔÍÛ
    {
        _savingManagement.SetInt("CrystalMoney", _crystals);
    }
}

