using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

//handles save and load functions 

public static class SaveAndLoad
{
    //list of saved games 
    public static List<Game> savedGames = new List<Game>();

    public static void Save()
    {
        savedGames.Add(Game.current); //add current game to list 
        BinaryFormatter bf = new BinaryFormatter(); //for serialization 
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd"); //path to file 
        bf.Serialize(file, SaveAndLoad.savedGames); //file name and type for Unity storage 
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd")) //check if file is there 
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            SaveAndLoad.savedGames = (List<Game>)bf.Deserialize(file); //calls location to deserialize and converts to list type
            file.Close();
        }
    }
}
