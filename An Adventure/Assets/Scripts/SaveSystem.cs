using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{

    public static void SavePlayer(GameStateController controller)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "player.bin");

        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(controller);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Path.Combine(Application.persistentDataPath, "player.bin");
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData playerData = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return playerData;
        }
        else
        {
            return null;
        }
    }
}
