using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UploadToForm : MonoBehaviour
{

    [SerializeField]
    private string URL = "https://docs.google.com/forms/d/1zc-Yl6IOo2UAGvZOldcXyYyAZqG1GQn5xbeh0WfBDRE/edit";

    private void OnEnable()
    {
        GameManager.onGameEvent += UploadUnityInformation;

    }

    private void OnDisable()
    {
        GameManager.onGameEvent -= UploadUnityInformation;

    }

    IEnumerator Upload()
    {


        WWWForm form = new WWWForm();
        /*
        form.AddField("entry.1871055262", GameManager.Instance.devHazardScore.ToString());
        form.AddField("entry.1041268702", GameManager.Instance.posHazardScore.ToString());
        form.AddField("entry.1669501835", GameManager.Instance.hazardArea.ToString());

        form.AddField("entry.1138500240", (int)GameManager.Instance.lookingDirections.x);
        form.AddField("entry.1381830432", (int)GameManager.Instance.lookingDirections.y);
        form.AddField("entry.1915059984", (int)GameManager.Instance.lookingDirections.z);
        */
        UnityWebRequest website = UnityWebRequest.Post(URL, form);




        yield return website.SendWebRequest();

        if (website.isNetworkError)
        {
            Debug.Log(website.error);
        }
    }


    void UploadUnityInformation(GameEvents events)
    {
        if (events != GameEvents.GAMEEVENT_UPLOADSTART)
            return;

        StartCoroutine(Upload());

    }
}
