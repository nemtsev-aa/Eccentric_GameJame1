using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meshHeightCalculator : MonoBehaviour
{
    public Mesh mesh;
    public Material material;
    public int matIndex;

    public float fillValue;
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        material = gameObject.GetComponent<MeshRenderer>().materials[matIndex];
    }

    public void FillingObject(float time)
    {
        fillValue = Mathf.Lerp(0, 1, time);
        material.SetFloat("_Fill", fillValue);
    }
}
