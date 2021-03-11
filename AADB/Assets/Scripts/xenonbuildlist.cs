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
    string url = "https://wiki.alphaarchive.net/";
    //private string url = "https://wiki.alphaarchive.net/Builds.txt";
    bool downloading = true;
    void Start()
    {
        //StartCoroutine(GetTextFromWWW());
        //StartCoroutine(GetBuild("Turok"));
        StartCoroutine(GetFile("Turok"));
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
    }
    IEnumerator GetBuild(string build_name)
    {
        string url = "https://wiki.alphaarchive.net/" + build_name + ".rar";

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.Send();

            if (www.isError)
            {
                Debug.Log(www.error);
            }
            else
            {
                string savePath = string.Format("{0}/{1}.rar", Application.persistentDataPath, build_name);

                if (www.downloadProgress == 1f)
                {
                    progressImage.color = Color.green;
                    downloading = false;
                }
                System.IO.File.WriteAllBytes(savePath, www.downloadHandler.data);
            }
        }
    } */
    IEnumerator GetFile(string build_names)
    {
        string url = "https://wiki.alphaarchive.net/" + build_names + ".rar";
        using (WWW www = new WWW(url))
        {
            yield return www;
            string savePath = string.Format("{0}/{1}.rar", Application.persistentDataPath, build_names);
            string savePathB = string.Format("{0}/{1}.rar", Application.streamingAssetsPath, build_names);
            if (www.bytesDownloaded == 1f)
            {
                progressImage.color = Color.green;
                downloading = false;
            }
            System.IO.File.WriteAllBytes(savePath, www.bytes);
            System.IO.File.WriteAllBytes(savePathB, www.bytes);
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