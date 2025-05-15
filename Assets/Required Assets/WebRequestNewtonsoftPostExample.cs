using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;
using Newtonsoft.Json;

public class WebRequestNewtonsoftPostExample : MonoBehaviour
{
    // Define a model for the POST data
    public class PostData
    {
        public string title;
        public string body;
        public int userId;
    }

    void Start()
    {
        PostData data = new PostData
        {
            title = "foo",
            body = "bar",
            userId = 1
        };

        string jsonData = JsonConvert.SerializeObject(data);
        StartCoroutine(PostRequest("https://jsonplaceholder.typicode.com/posts", jsonData));
    }

    IEnumerator PostRequest(string uri, string json)
    {
        var request = new UnityWebRequest(uri, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError ||
            request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            Debug.Log("Response: " + request.downloadHandler.text);
        }
    }
}