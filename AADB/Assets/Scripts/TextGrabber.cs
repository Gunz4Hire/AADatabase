using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class TextGrabber : MonoBehaviour {

    private string url = "https://wiki.alphaarchive.net/Builds.txt";
    public Text buildListTxtElement;
    public Text timer;
    bool downloading = true;

    void Start ()
    {
        StartCoroutine("GetTextFromWWW");
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
                    downloading = false;
                }
                System.IO.File.WriteAllBytes(savePath, www.downloadHandler.data);
            }
        }
    }
}
