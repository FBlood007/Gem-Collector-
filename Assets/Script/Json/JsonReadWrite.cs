using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class JsonReadWrite : MonoBehaviour
{

    public InputField idInputField;
    public InputField nameInputField;
    public InputField infoInputField;

    public static JsonReadWrite Instance;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void SaveToJson()
    {
        JsonDemo data = new JsonDemo();
        data.Id = idInputField.text;
        data.Name = nameInputField.text;    
        data.Description = infoInputField.text;

        string json = JsonUtility.ToJson(data,true);
        File.WriteAllText(Application.dataPath + "/DataFile.json",json);
    }

    public void LoadFromJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/DataFile.json");
        JsonDemo data = JsonUtility.FromJson<JsonDemo>(json);

        idInputField.text = data.Id;
        nameInputField.text = data.Name;    
        infoInputField.text = data.Description;
    }
}
