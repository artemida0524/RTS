using System;
using UnityEngine;



public interface IServicePlayerPrefs
{

    void Load();
    void Save();

    string Get();
}


public abstract class ServiceDataBase : IServicePlayerPrefs
{
    public abstract string Path { get; protected set; }

    public abstract string Get();

    public abstract void Load();

    public abstract void Save();
}
