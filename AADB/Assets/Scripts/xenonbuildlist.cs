using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;


public class xenonbuildlist : MonoBehaviour
{
    public Text buildListTxtElement;
    public RawImage progressImage;
    public Text timer;
    float uptimer = 0f;
    //private string url = "https://wiki.alphaarchive.net/Builds.txt";
    bool downloading = true;
    void Start()
    {
        //StartCoroutine(GetTextFromWWW());
        StartCoroutine(GetText("Turok"));
    }
    /*IEnumerator GetTextFromWWW()
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
    }*/
    IEnumerator GetText(string file_name)
    {
        string url = "https://wiki.alphaarchive.net/" + file_name + ".rar";

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.Send();

            if (www.isError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string savePath = string.Format("{0}/{1}.rar", Application.persistentDataPath, file_name);

                if (www.downloadProgress == 1f)
                {
                    progressImage.color = Color.green;
                    downloading = false;
                }
                System.IO.File.WriteAllBytes(savePath, www.downloadHandler.data);
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (!downloading)
            return;
        if (downloading = true)
        {
            timer.text = "" + uptimer + 1 * Time.time;
        }
    }
}