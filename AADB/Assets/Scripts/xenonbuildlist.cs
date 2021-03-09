using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class xenonbuildlist : MonoBehaviour
{
    private string textFromWWW;
    public Text siteText;
    private string url = "https://wiki.alphaarchive.net/Builds.txt";
    //public Text siteTextb;
    //private string urlb = "https://wiki.alphaarchive.net/Builds2.txt";

    void Start()
    {
        StartCoroutine(GetTextFromWWW());
    }
    IEnumerator GetTextFromWWW()
    {
        WWW www = new WWW(url);
        //WWW wwwb = new WWW(urlb);
        yield return www;
        //yield return wwwb;
        if (www.error != null)
        {
            Debug.Log("Ooops, something went wrong...");
        }
        else
        {
            //siteTextb.text = wwwb.text;
            siteText.text = www.text;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}