using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private Image _bar;
    [SerializeField] private TMP_Text _txt;
    private float _progress;
    private string _nameLvl;
    private SavingManagement _savingManagement;
    private Coroutine _getData, _loadAsync;
    private WaitForSeconds _ws = new WaitForSeconds(0.1f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Translator.StarChangeLang();
        if (_savingManagement == null)
            _savingManagement = GameObject.Find("SavingManagement").GetComponent<SavingManagement>();
        _nameLvl = _savingManagement.GetString("LoadingScene");
        Debug.Log("_nameLvl " + _nameLvl);
        _loadAsync = StartCoroutine(LoadAsync(_nameLvl));
    }



    IEnumerator LoadAsync(string scen)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scen);
        if (asyncLoad.isDone)
            YG2.GameReadyAPI();
        while (!asyncLoad.isDone)
        {
            _progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            _txt.text = (_progress * 100).ToString() + " %";
            _bar.fillAmount = asyncLoad.progress;
            yield return null;
        }
    }
}
