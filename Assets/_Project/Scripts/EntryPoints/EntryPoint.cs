
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;
//using YG;

public class EntryPoint : MonoBehaviour
{
    public static EntryPoint instance;
    private SavingManagement _savingManagement;
    private StartSettings _startSettings;
    private Coroutine _initialParameters;
    private WaitForSeconds _ws = new WaitForSeconds(0.1f);

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
        if (YG2.isSDKEnabled)
        {
            Debug.Log("YG2.lang " + YG2.lang);
            if (_savingManagement == null)
                _savingManagement = GameObject.Find("SavingManagement").GetComponent<SavingManagement>();
            if (_startSettings == null)
                _startSettings = GameObject.Find("StartSettings").GetComponent<StartSettings>();
            _startSettings.Initialized();
            SceneManager.LoadScene("LoadingScene");
            yield break;
        }
        else
        {
            _initialParameters = StartCoroutine(InitialParameters());
        }
    }
   
   
}

