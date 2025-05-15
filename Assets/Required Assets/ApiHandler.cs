#region The First Call
//using UnityEngine;
//using UnityEngine.Networking;
//using System.Collections;
//using UnityEngine.UI;
//using TMPro;
//using System.Collections.Generic;
//using Newtonsoft.Json;
//using System.Text;

//public class ApiHandler : MonoBehaviour
//{
//    [SerializeField] private TMP_Text factText;
//    [SerializeField] private Button fetchFactButton;

//    public void CallGetFact()
//    {
//        Debug.Log("CallGetFact invoked. Starting the GetFact coroutine.");
//        StartCoroutine(GetFact());
//    }

//    public IEnumerator GetFact()
//    {
//        Debug.Log("Sending web request (POST) to fetch fact.");
//        WWWForm form = new WWWForm();
//        using (UnityWebRequest www = UnityWebRequest.Post("http://tempweb90.com/text-processor/api.php", form))
//        {
//            yield return www.SendWebRequest();

//            if (www.result == UnityWebRequest.Result.Success)
//            {
//                Debug.Log("Web request succeeded. Response: " + www.downloadHandler.text);
//                FactApi factApi = JsonConvert.DeserializeObject<FactApi>(www.downloadHandler.text);
//                factText.text = factApi.fact;
//            }
//            else
//            {
//                Debug.LogError("Error fetching fact: " + www.error);
//            }
//        }
//    }
//}

//[System.Serializable]
//public class FactApi
//{
//    public string fact;
//    public int length;
//}
#endregion
#region Big One
//using UnityEngine;
//using UnityEngine.Networking;
//using System.Collections;
//using TMPro;
//using Newtonsoft.Json;
//using System.Text;
//using UnityEngine.UI;
//public class ApiHandler : MonoBehaviour
//{
//    [SerializeField] private TMP_Text factText;
//    [SerializeField] private Button fetchFactButton;

//    // Existing method: fetch the fact from the server
//    public void CallGetFact()
//    {
//        Debug.Log("CallGetFact invoked. Starting the GetFact coroutine.");
//        StartCoroutine(GetFact());
//    }

//    public IEnumerator GetFact()
//    {
//        Debug.Log("Sending GET request to fetch fact.");

//        using (UnityWebRequest www = UnityWebRequest.Get("https://tempweb90.com/text-processor/api.php"))
//        {
//            yield return www.SendWebRequest();

//            if (www.result == UnityWebRequest.Result.Success)
//            {
//                Debug.Log("Web request succeeded. Response: " + www.downloadHandler.text);

//                try
//                {
//                    FactApi factApi = JsonConvert.DeserializeObject<FactApi>(www.downloadHandler.text);
//                    if (factApi != null && !string.IsNullOrEmpty(factApi.fact))
//                    {
//                        factText.text = factApi.fact;
//                        Debug.Log("Fact displayed: " + factApi.fact);
//                    }
//                    else
//                    {
//                        Debug.LogWarning("No fact exists on the server.");
//                        factText.text = "No existing fact on server.";
//                    }
//                }
//                catch (JsonException ex)
//                {
//                    Debug.LogError("Failed to parse JSON response: " + ex.Message);
//                    factText.text = "Error: Failed to parse server response.";
//                }
//            }
//            else
//            {
//                Debug.LogError("Error fetching fact: " + www.error);
//                factText.text = "Error: Unable to fetch fact.";
//            }
//        }
//    }

//    // New method: Check then post fact text
//    public void CallPostFact()
//    {
//        Debug.Log("CallPostFact invoked.");
//        StartCoroutine(CheckAndPostFact());
//    }

//    // First check if a fact exists and log an appropriate message before posting.
//    private IEnumerator CheckAndPostFact()
//    {
//        // Send a GET request to check for existing text.
//        Debug.Log("Sending GET request to check if fact exists on the server.");
//        using (UnityWebRequest getRequest = UnityWebRequest.Get("https://tempweb90.com/text-processor/api.php"))
//        {
//            yield return getRequest.SendWebRequest();

//            bool exists = false;
//            if (getRequest.result == UnityWebRequest.Result.Success)
//            {
//                try
//                {
//                    FactApi currentFact = JsonConvert.DeserializeObject<FactApi>(getRequest.downloadHandler.text);
//                    if (currentFact != null && !string.IsNullOrEmpty(currentFact.fact))
//                    {
//                        exists = true;
//                        Debug.Log("Fact already exists on the server. It will be changed.");
//                    }
//                    else
//                    {
//                        Debug.Log("No fact exists on the server. Creating a new one.");
//                    }
//                }
//                catch (JsonException ex)
//                {
//                    Debug.LogError("Failed to parse JSON while checking: " + ex.Message);
//                }
//            }
//            else
//            {
//                Debug.LogError("Error checking for fact: " + getRequest.error);
//            }

//            // Now post the new fact (whether or not one exists)
//            yield return PostFact();
//        }
//    }

//    // Method to post the text from factText.text
//    private IEnumerator PostFact()
//    {
//        Debug.Log("Sending POST request to update fact with: " + factText.text);

//        string jsonPayload = "{\"text\": \"" + factText.text + "\"}";
//        byte[] jsonData = Encoding.UTF8.GetBytes(jsonPayload);

//        using (UnityWebRequest postRequest = new UnityWebRequest("https://tempweb90.com/text-processor/api.php", "POST"))
//        {
//            postRequest.uploadHandler = new UploadHandlerRaw(jsonData);
//            postRequest.downloadHandler = new DownloadHandlerBuffer();

//            // Set headers as needed (using text/plain for content type per your example)
//            postRequest.SetRequestHeader("Content-Type", "text/plain");
//            postRequest.SetRequestHeader("Accept", "application/json");

//            yield return postRequest.SendWebRequest();

//            if (postRequest.result == UnityWebRequest.Result.Success)
//            {
//                Debug.Log("POST succeeded. Response: " + postRequest.downloadHandler.text);
//            }
//            else
//            {
//                Debug.LogError("Error posting fact: " + postRequest.error);
//            }
//        }
//    }
//}

//[System.Serializable]
//public class FactApi
//{
//    public string fact;
//    public int length;
//}

#endregion
#region Another One
//using UnityEngine;
//using UnityEngine.Networking;
//using System.Collections;
//using TMPro;
//using Newtonsoft.Json;
//using System.Text;

//public class ApiHandler : MonoBehaviour
//{
//    [SerializeField] private TMP_Text factText;

//    public void CallPostFact()
//    {
//        StartCoroutine(CheckAndPostFact());
//    }

//    private IEnumerator CheckAndPostFact()
//    {
//        // Send a GET request to check for an existing fact
//        UnityWebRequest getRequest = UnityWebRequest.Get("https://tempweb90.com/text-processor/api.php");
//        yield return getRequest.SendWebRequest();

//        bool exists = false;
//        if (getRequest.result == UnityWebRequest.Result.Success)
//        {
//            FactApi existing = JsonConvert.DeserializeObject<FactApi>(getRequest.downloadHandler.text);
//            exists = (existing != null && !string.IsNullOrEmpty(existing.fact));
//            Debug.Log(exists ? "Fact exists; will update it." : "No fact exists; creating new entry.");
//        }
//        else
//        {
//            Debug.Log("Error checking fact: " + getRequest.error);
//        }

//        // Post the text from factText.text regardless of check result
//        yield return PostFact();
//    }

//    private IEnumerator PostFact()
//    {
//        string jsonPayload = "{\"text\":\"" + factText.text + "\"}";
//        byte[] jsonData = Encoding.UTF8.GetBytes(jsonPayload);

//        UnityWebRequest postRequest = new UnityWebRequest("https://tempweb90.com/text-processor/api.php", "POST");
//        postRequest.uploadHandler = new UploadHandlerRaw(jsonData);
//        postRequest.downloadHandler = new DownloadHandlerBuffer();
//        postRequest.SetRequestHeader("Content-Type", "text/plain");
//        postRequest.SetRequestHeader("Accept", "application/json");

//        yield return postRequest.SendWebRequest();

//        if (postRequest.result == UnityWebRequest.Result.Success)
//            Debug.Log("Post succeeded. Response: " + postRequest.downloadHandler.text);
//        else
//            Debug.Log("Post error: " + postRequest.error);
//    }
//}

//[System.Serializable]
//public class FactApi
//{
//    public string fact;
//    public int length;
//}

#endregion

#region The Last One
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;

public class ApiHandler : MonoBehaviour
{
    [SerializeField] private string url;
    [SerializeField] private TMP_Text factText;
    [SerializeField] private Button fetchFactButton;

        void Start()
        {
            // A correct website page.
            StartCoroutine(GetRequest(url));
        }
        IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }

    public void CallPostFact()
    {
        Debug.Log("CallPostFact invoked. Starting the PostFact coroutine.");
        StartCoroutine(PostFact());
    }
    public void CallGetFact()
    {
        Debug.Log("CallGetFact invoked. Starting the GetFact coroutine.");
        StartCoroutine(GetFact());
    }
    public IEnumerator PostFact()
    {
        Debug.Log("Sending web request (POST) to update fact with: " + factText.text);
        WWWForm form = new WWWForm();
        form.AddField("text", factText.text);

        using (UnityWebRequest www = UnityWebRequest.Post("https://tempweb90.com/text-processor/api.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("POST web request succeeded. Response: " + www.downloadHandler.text);
                // Optionally, parse response using FactApi if the server response matches that model.
                FactApi factApi = JsonConvert.DeserializeObject<FactApi>(www.downloadHandler.text);
                factText.text = factApi.fact;
            }
            else
            {
                Debug.LogError("Error posting fact: " + www.error);
            }
        }
    }



    public IEnumerator GetFact()
    {
        Debug.Log("Sending web request (POST) to fetch fact.");
        WWWForm form = new WWWForm();
        using (UnityWebRequest www = UnityWebRequest.Get("https://tempweb90.com/text-processor/api.php"))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Web request succeeded. Response: " + www.downloadHandler.text);
                FactApi factApi = JsonConvert.DeserializeObject<FactApi>(www.downloadHandler.text);
                factText.text = factApi.fact;
            }
            else
            {
                Debug.LogError("Error fetching fact: " + www.error);
            }
        }
    }
}

[System.Serializable]
public class FactApi
{
    public string fact;
    public int length;
}
#endregion