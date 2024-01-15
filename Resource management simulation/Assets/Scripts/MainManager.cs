using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    // Singleton pattern instance
    public static MainManager Instance { get; private set; }

    // Current selected team color
    public Color TeamColor;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance != null)
        {
            Destroy(gameObject); // Destroy duplicate instances
            return;
        }

        Instance = this; // Set the instance to this if it's the first one
        DontDestroyOnLoad(gameObject); // Ensure the object persists across scenes

        LoadColor();
    }

    // Method to update the team color
    public void NewColorSelected(Color color)
    {   
        MainManager.Instance.TeamColor = color;
    }

    // Serializable class to hold save data
    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

    // Method to save the selected color to a file
    public void SaveColor()
    {
        // Create a SaveData object and populate it with the current team color
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        // Convert the SaveData object to JSON format
        string json = JsonUtility.ToJson(data);

        // Write the JSON data to a file in the persistent data path
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadColor()
    {
        // Define the file path for the save file in the persistent data path
        string path = Application.persistentDataPath + "/savefile.json";

        // Check if the save file exists
        if (File.Exists(path))
        {
            // Read the JSON data from the save file
            string json = File.ReadAllText(path);

            // Deserialize the JSON data into a SaveData object
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            // Update the TeamColor with the loaded color data
            TeamColor = data.TeamColor;
        }
    }

}
