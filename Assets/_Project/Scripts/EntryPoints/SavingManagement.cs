using UnityEngine;
using YG;
using PlayerPrefs = RedefineYG.PlayerPrefs;

public class SavingManagement : MonoBehaviour
{
    public void SetInt(string str, int i)
    {
        PlayerPrefs.SetInt(str, i);
        Save();
    }

    public void SetFloat(string str, float i)
    {
        PlayerPrefs.SetFloat(str, i);
        Save();
    }

    public void SetString(string str, string i)
    {
        PlayerPrefs.SetString(str, i);
        Save();
    }

    public int GetInt(string str)
    {
        return PlayerPrefs.GetInt(str);

    }

    public float GetFloat(string str)
    {
        return PlayerPrefs.GetFloat(str);
    }

    public string GetString(string str)
    {
        return PlayerPrefs.GetString(str);
    }

    private void Save()
    {
        //PlayerPrefs.Save();
        YG2.SaveProgress();
    }
}
