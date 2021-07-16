using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// [ Doc. ]
// : https://docs.unity3d.com/kr/2021.1/Manual/UnityWebRequest-HLAPI.html
public class HttpTest : MonoBehaviour
{

    string endpoint = "http://localhost:3003";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetText(endpoint+"/t1"));   
        StartCoroutine(GetText(endpoint+"/t2"));   
        StartCoroutine(GetText(endpoint+"/t3"));   
        StartCoroutine(GetTextForT4(endpoint+"/t4"));   
        StartCoroutine(GetTextG<T4>(endpoint+"/t4"));   

        StartCoroutine(PostText(endpoint+"/t11"));   
        StartCoroutine(PostText(endpoint+"/t22"));   
        StartCoroutine(PostText(endpoint+"/t33"));   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetText(string url) {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
 
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
 
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
    
    IEnumerator GetTextForT4(string url) {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
 
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            Debug.Log("For T1-----");
            T4 t4 = JsonUtility.FromJson<T4>(www.downloadHandler.text);
            Debug.Log( t4.data );
            Debug.Log("-----For T1");
            byte[] results = www.downloadHandler.data;
        }
    }
    IEnumerator GetTextG<T>(string url) {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();
 
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            Debug.Log("-----For <T>");
            Debug.Log(www.downloadHandler.text);
            T t  = JsonUtility.FromJson<T>(www.downloadHandler.text);
            Debug.Log(t);
            Debug.Log("For <T>-----");
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }

    IEnumerator PostText(string url) {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        UnityWebRequest www = UnityWebRequest.Post(url,formData);
        yield return www.SendWebRequest();
 
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
 
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
}

[System.Serializable]
class T4{
    public string data;
}
