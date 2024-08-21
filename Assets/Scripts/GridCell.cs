using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    [HideInInspector] public int x;
    [HideInInspector] public int z;
    [HideInInspector] public Vector3 vector;
    [HideInInspector] public  Color color;
    private MeshRenderer meshRenderer;
    [HideInInspector] public Hex hexCoordinates;
    public bool isEmpty = true;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Initialize(Hex coordinates)
    {
        hexCoordinates = coordinates;
        transform.name = $"Hex ({coordinates.q}, {coordinates.r})";
    }
    public Color GridCellColor { get => color; set => color = value; }

    public void SetColor()
    {
        if ((meshRenderer = GetComponentInChildren<MeshRenderer>()) != null)
        {
            foreach (Material mat in meshRenderer.materials)
            {
                if (mat.HasProperty("_BaseColor"))
                {
                    mat.SetColor("_BaseColor", color);
                    color.a = 1;
                }
                else
                {
                    mat.color = color;
                    color.a = 1;
                }
            }
        }
        else
            Debug.Log("meshrenderer bulunamadý");
    }
    public void SetColor(Color color)
    {
        if ((meshRenderer = GetComponentInChildren<MeshRenderer>()) != null)
        {
            foreach (Material mat in meshRenderer.materials)
            {
                if (mat.HasProperty("_BaseColor"))
                {
                    mat.SetColor("_BaseColor", color);
                    this.color.a = 1;
                }
                else
                {
                    mat.color = color;
                    this.color.a = 1;
                }
            }
        }
        else
            Debug.Log("meshrenderer bulunamadý");
    }
}