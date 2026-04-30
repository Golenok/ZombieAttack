using UnityEngine;
using UnityEngine.UI;
using YG;

public class LanguageChanges : MonoBehaviour
{
    [Header("Страны")]
    [SerializeField] private Button _buttonRu, _buttonEn, _buttonEs, _buttonTr;


    private void Start()
    {
        if (YG2.lang == "ru")
        {
            language(0);
        }
        else if (YG2.lang == "en")
        {
            language(1);
        }
        else if (YG2.lang == "es")
        {
            language(2);
        }
        else if (YG2.lang == "tr")
        {
            language(3);
        }
        else
        {
            language(1);
        }
        
    }

    private void language(int id)
    {
        if (id == 0)
        {
            _buttonRu.interactable = false;
            _buttonEn.interactable = true;
            _buttonEs.interactable = true;
            _buttonTr.interactable = true;
        }
        if (id == 1)
        {
            _buttonRu.interactable = true;
            _buttonEn.interactable = false;
            _buttonEs.interactable = true;
            _buttonTr.interactable = true;
        }
        if (id == 2)
        {
            _buttonRu.interactable = true;
            _buttonEn.interactable = true;
            _buttonEs.interactable = false;
            _buttonTr.interactable = true;
        }
        if (id == 3)
        {
            _buttonRu.interactable = true;
            _buttonEn.interactable = true;
            _buttonEs.interactable = true;
            _buttonTr.interactable = false;
        }
    }

    public void But_language(int id)
    {
        switch (id)
        {
            case 0:
                YG2.lang = "ru";
                break;
            case 2:
                YG2.lang = "es";
                break;
            case 3:
                YG2.lang = "tr";
                break;
            default:
                YG2.lang = "en";
                break;
        }
        language(id);

        Translator.Update_texts(id);
    }
}
