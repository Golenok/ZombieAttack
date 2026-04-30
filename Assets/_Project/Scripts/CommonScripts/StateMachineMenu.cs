using UnityEngine;

public class StateMachineMenu : MonoBehaviour
{
    private Translator _translator;
    void Start()
    {
        if (_translator == null)
            _translator = GameObject.Find("Translator").GetComponent<Translator>();
        _translator.StartTranslator();
    }

}
