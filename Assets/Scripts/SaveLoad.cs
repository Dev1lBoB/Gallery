using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
 
public static class SaveLoad {
 
    public static CardInfo[]    savedCards;
    public static bool          savedSettings;
    
    public static void Save<T>(T data, string fileName)
    {
        // Serialize and save 'data' into 'filename'
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create (Application.persistentDataPath + "/" + fileName + ".gd");
        bf.Serialize(file, data);
        file.Close();
    }   
     
    public static void Load()
    {
        // Deserialize all saved data and store it inside class
        if(File.Exists(Application.persistentDataPath + "/CardsInfo.gd"))
        {
            // Information about cards
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/CardsInfo.gd", FileMode.Open);
            SaveLoad.savedCards = (CardInfo[])bf.Deserialize(file);
            file.Close();
        }
        if(File.Exists(Application.persistentDataPath + "/SettingsInfo.gd"))
        {
            // Information about user settings
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SettingsInfo.gd", FileMode.Open);
            SaveLoad.savedSettings = (bool)bf.Deserialize(file);
            file.Close();
        }
    }
}
