using TMPro;
using UnityEngine;

public class TrainingMessage : MonoBehaviour
{
    [SerializeField] private GameObject[] _txt;
    private int _randomInt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _randomInt = Random.Range(0, _txt.Length);
        _txt[_randomInt].SetActive(true);
    }
}
