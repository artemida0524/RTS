using UnityEngine;

public interface IBuild
{
    Renderer [] Renderer { get; }

    int SizeX { get; }
    int SizeZ { get; }

    void Build();

    void CanBuilt();

    void DontBuild();
}



[SelectionBase]
public abstract class BuildBase : MonoBehaviour, IBuild
{
    [SerializeField] protected Renderer[] renderer;
    [SerializeField] protected int sizeX;
    [SerializeField] protected int sizeZ;



    public Renderer[] Renderer => renderer;

    public int SizeX => sizeX;

    public int SizeZ => sizeZ;

    public virtual void Build()
    {
        foreach (var renderer in renderer)
        {
            renderer.material.color = Color.white;
        }
    }

    public virtual void CanBuilt()
    {
        foreach (var renderer in renderer)
        {
            renderer.material.color = Color.yellow;
        }
    }

    public virtual void DontBuild()
    {
        foreach (var renderer in renderer)
        {
            renderer.material.color = Color.red;
        }
    }
}


