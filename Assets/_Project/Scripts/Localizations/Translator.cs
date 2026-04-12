using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using YG;
//using YG.Insides;

//namespace YG.Example
//{
public class Translator : MonoBehaviour
{
    private static int LaungageId;
    private static List<Translatable_text> listId = new List<Translatable_text>();
    private SavingManagement _savingManagement;
    private WaitForSeconds _ws = new WaitForSeconds(0.1f);

    private void StartTranslator()
    {
        Debug.Log("запуск StartTranslator из StateMachine самым Первым!!!!");
        if (_savingManagement == null)
            _savingManagement = GameObject.Find("SavingManagement").GetComponent<SavingManagement>();
        //YG2.onCorrectLang += OnСhangeLang;
    }

    public static void OnСhangeLang(string lang)
    {
        if (lang == "ru")
        {
            LaungageId = 0;
        }
        else if (lang == "en")
        {
            LaungageId = 1;
        }
        else if (lang == "es")
        {
            LaungageId = 2;
        }
        else if (lang == "tr")
        {
            LaungageId = 3;
        }
        else
        {
            LaungageId = 1;
        }
        for (int i = 0; i < listId.Count; i++)
        {
            listId[i].UIText.text = LineText[LaungageId, listId[i].textID];
        }
    }

    static public void Update_texts(int _laungageId)
    {
        LaungageId = _laungageId;
        for (int i = 0; i < listId.Count; i++)
        {
            listId[i].UIText.text = LineText[LaungageId, listId[i].textID];
        }
    }

    static public void Update_texts()
    {
        //if (YG2.lang == "ru")
        //{
        //    LaungageId = 0;
        //}
        //else if (YG2.lang == "en")
        //{
        //    LaungageId = 1;
        //}
        //else if (YG2.lang == "es")
        //{
        //    LaungageId = 2;
        //}
        //else if (YG2.lang == "tr")
        //{
        //    LaungageId = 3;
        //}
        //else
        //{
        //    LaungageId = 1;
        //}

        if (LaungageId != 4)
        {
            for (int i = 0; i < listId.Count; i++)
            {
                listId[i].UIText.text = LineText[LaungageId, listId[i].textID];
            }
        }
    }

    static public string Get_text(int textKey)
    {
        return LineText[LaungageId, textKey];
    }

    static public void Add(Translatable_text idtext)
    {
        listId.Add(idtext);
    }

    static public void Delete(Translatable_text idtext)
    {
        listId.Remove(idtext);
    }

    private static string[,] LineText =
        {
        #region Русский
        {
        "Старт", //0     
        "Капибары:\n" +
            "Умение - Шанс замедлить врагов.\n" +
            "Урон по легким целям + 100%.\n" +
            "Урон по средним целям - 70%.\n" +
            "Урон по тяжелым целям - 30%.\n", //22
        "Купить улучшения",//162
        },
        #endregion
        #region Английский
        {
        "Start", //0
        "Settings", //1
        "Improvements", //2     
        },
        #endregion
        #region Испанский
        {
        "Comenzar", //0
        "Ajustes", //1
        "Mejoras", //2
        },
        #endregion
        #region Турецкий
        {
        "Başlangıç", //0
        "Ayarlar", //1
        "İyileştirmeler", //2
        }
        #endregion
    };
}
//}