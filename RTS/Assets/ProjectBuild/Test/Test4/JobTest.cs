using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;
using Random = UnityEngine.Random;


public struct JobMove1 : IJobParallelForTransform
{
    public NativeArray<Vector3> velocities;
    public float deltaTime;



    public void Execute(int index, TransformAccess transformAccess)
    {
        transformAccess.position += velocities[index] * deltaTime;
    }
}

public struct JobMove2 : IJobParallelFor
{
    public NativeArray<Vector3> velocities;
    public NativeArray<Vector3> positions;

    public float deltaTime;
    public float speed;

    public void Execute(int index)
    {

        positions[index] += velocities[index] * deltaTime * speed;
    }
}





public class JobTest : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private Transform container;

    [SerializeField] private float speed = 0.5f;

    private int count = 10000;


    private TransformAccessArray transformAccessArray;


    private NativeArray<Vector3> velocities;
    private NativeArray<Vector3> positions;

    Transform[] transforms;

    private void Start()
    {
        velocities = new NativeArray<Vector3>(count, Allocator.Persistent);

        positions = new NativeArray<Vector3>(count, Allocator.Persistent);
        transforms = new Transform[count];

        for (int i = 0; i < count; i++)
        {
            transforms[i] = Instantiate(cube, container).transform;

            transforms[i].localPosition = new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f));

            positions[i] = transforms[i].position;

            velocities[i] = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }

        transformAccessArray = new TransformAccessArray(transforms);

    }



    private void Update()
    {
        //JobMove1 jobRigidbodyMove = new JobMove1()
        //{
        //    velocities = velocities,
        //    deltaTime = Time.deltaTime

        //};

        //JobHandle jobHandle = jobRigidbodyMove.Schedule(transformAccessArray);
        //jobHandle.Complete();



        //for (int i = 0; i < count; i++)
        //{
        //    transformAccessArray[i].transform.position += velocities[i] * Time.deltaTime;
        //}

    }
}