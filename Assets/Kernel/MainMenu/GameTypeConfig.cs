using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Aposta Ganha/GameTypeConfig")]
public class GameTypeConfig : ScriptableObject
{
    public List<GameDataKvp> gameDataKvps;
}

[Serializable]
public struct GameDataKvp
{
    public GameType MyType;

    public Sprite ExtraSprite;
}

public enum GameType : Int32
{
    basket =0,
    aero = 1,
    foot = 2
}