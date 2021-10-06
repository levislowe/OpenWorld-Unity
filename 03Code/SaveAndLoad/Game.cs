using System.Collections;
using UnityEngine;

[System.Serializable]
public class Game
{
    public static Game current;
    public Character george;
    public Character scott;
    public Character spock;

    public Game()
    {
        george = new Character();
        scott = new Character();
        spock = new Character();
    }
}
