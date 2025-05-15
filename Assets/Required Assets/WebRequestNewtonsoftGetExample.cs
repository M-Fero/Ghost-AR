using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using Newtonsoft.Json;

public class WebRequestNewtonsoftGetExample : MonoBehaviour
{
    // Define a model matching the expected JSON structure.
    public class Post
    {
        public int userId;
        public int id;
        public string title;
        public string body;
    }

    void Start()
    {
        StartCoroutine(GetRequest("https://jsonplaceholder.typicode.com/posts/1"));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError ||
                webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(webRequest.error);
            }
            else
            {
                // Deserialize JSON using Newtonsoft
                Post post = JsonConvert.DeserializeObject<Post>(webRequest.downloadHandler.text);
                Debug.Log($"Title: {post.title}\nBody: {post.body}");
            }
        }
    }
}