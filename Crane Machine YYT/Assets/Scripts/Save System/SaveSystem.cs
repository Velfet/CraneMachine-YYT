using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    public static void SaveData(MasterPlayerData mPD)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerSave.Data";
        FileStream stream = new FileStream(path, FileMode.Create);

        SavedPlayerData data = new SavedPlayerData(mPD);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SavedPlayerData LoadData()
    {
        string path = Application.persistentDataPath + "/playerSave.Data";

        if(File.Exists(path) == true)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SavedPlayerData data = formatter.Deserialize(stream) as SavedPlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogWarning("save file not found in " + path);
            return null;
        }
    }
}
