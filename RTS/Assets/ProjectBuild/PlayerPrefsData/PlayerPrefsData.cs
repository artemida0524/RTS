using System;
using UnityEngine;



public interface IPlayerPrefsService
{

    void Load();
    void Save();

    string Get();
}


public abstract class ServiceDataBase : IPlayerPrefsService
{
    public abstract string Path { get; protected set; }

    public abstract string Get();

    public abstract void Load();

    public abstract void Save();
}
