using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    
    void Start()
    {
        transform.position = new Vector3(RandomValueA(), RandomValueB(), RandomValueC());
        transform.localScale = Vector3.one * RandomValueA();
        
        Material material = Renderer.material;
        
        material.color = new Color(RandomValueA(), RandomValueB(), RandomValueC());
    }
    
    void Update()
    {
        transform.Rotate(RandomValueA() * Time.deltaTime, RandomValueB() * Time.deltaTime, RandomValueC() * Time.deltaTime);
    }

    private float RandomValueA()
    {
        float a = Random.Range(1, 9);

        return a;
    }

    private float RandomValueB()
    {
        float b = Random.Range(1, 9);

        return b;
    }

    private float RandomValueC()
    {
        float c = Random.Range(1, 9);

        return c;
    }
}
