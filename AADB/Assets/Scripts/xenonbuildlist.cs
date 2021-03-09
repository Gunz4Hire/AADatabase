using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class xenonbuildlist : MonoBehaviour
{
    public Text buildListTxtElement;
    private string url = "https://wiki.alphaarchive.net/Builds.txt";


    void Start()
    {
        StartCoroutine(GetTextFromWWW());
    }
    IEnumerator GetTextFromWWW()
    {
        WWW www = new WWW(url);

        yield return www;

        if (www.error != null)
        {
            Debug.Log("Ooops, something went wrong...");
        }
        else
        {
            buildListTxtElement.text = www.text;
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