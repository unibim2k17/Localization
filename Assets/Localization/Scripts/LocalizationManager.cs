using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager instance;

    private Dictionary<string, string> localizedText;
    private bool isReady;
    private string missingText = "Localized Text Not Found";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void LoadLocalizedText(string filename)
    {
        localizedText = new Dictionary<string, string>();
        string filePath = Path.Combine(Application.streamingAssetsPath, filename);
        
        
        if (File.Exists(filePath))
        {
            string datajason = File.ReadAllText(filePath);
            LocalizationData loadeddata = JsonUtility.FromJson<LocalizationData>(datajason);

            for (int i = 0; i < loadeddata.items.Length; i++)
            {
                localizedText.Add(loadeddata.items[i].key, loadeddata.items[i].value);
            }

            Debug.Log("Data Loded, Found Entries: " + loadeddata.items.Length);

        }
        else
        {
            Debug.LogError("canot find path");
        }

        isReady = true;
    }

    public string GetLocalizedValue(string key)
    {
        string result = missingText;
        if (localizedText.ContainsKey(key))
        {
            result = localizedText[key];
        }
        return result;
    }

    public bool GetISReady()
    {
        return isReady;
    }

}
