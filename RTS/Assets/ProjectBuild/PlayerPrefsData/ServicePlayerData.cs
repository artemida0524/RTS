using System;
using UnityEngine;

public sealed class ServicePlayerData : ServiceDataBase
{
    public override string Path { get; protected set; } = "PlayerData";

    private PlayerDataDTO _data;

    public PlayerDataDTO Data { get => _data; private set => _data = value; }

    public override void Load()
    {
        Debug.Log("load");
        _data = new PlayerDataDTO();

        string data = Get();

        if (data != string.Empty)
        {
            _data = JsonUtility.FromJson<PlayerDataDTO>(data);
        }
    }

    public override void Save()
    {
        if (_data == null)
        {
            return;
        }

        string json = JsonUtility.ToJson(_data);

        UnityEngine.PlayerPrefs.SetString(Path, json);

    }

    public override string Get()
    {
        return JsonUtility.ToJson(_data);
    }
}



[Serializable]
public class PlayerDataDTO
{
    public string name;
    public int level;
}