using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    public int radius;
    float hexRadius;
    float hexWidth;
    float hexHeight;
    GameObject gizmosPrefab;
    [SerializeField] GameObject hexPrefab;
    List<Hex> hexs = new List<Hex>();
    private void Awake()
    {
        Instance = this;
        CreateHexGrid();
    }
    private void OnDrawGizmos()
    {
        MeshRenderer meshRenderer = hexPrefab.GetComponentInChildren<MeshRenderer>();
        hexWidth = meshRenderer.bounds.size.x;
        hexHeight = meshRenderer.bounds.size.y;

        hexRadius = hexWidth / Mathf.Sqrt(3);

        for (int q = -radius; q <= radius; q++)
        {
            for (int r = Mathf.Max(-radius, -q - radius); r <= Mathf.Min(radius, -q + radius); r++)
            {
                Hex hexCoordinates = new Hex(q, r);
                Vector3 originalPosition = HexToPosition(hexCoordinates);

                Vector3 rotatedPosition = this.transform.rotation * originalPosition;

                Gizmos.DrawWireMesh(hexPrefab.GetComponentInChildren<MeshFilter>().sharedMesh,
                    rotatedPosition,
                    this.transform.rotation,
                    hexPrefab.GetComponent<Transform>().localScale);
                Gizmos.color = Color.white;
                GUIStyle style = new GUIStyle();
                style.alignment = TextAnchor.MiddleCenter;
                style.normal.textColor = Color.black;
                
#if UNITY_EDITOR
                UnityEditor.Handles.Label(rotatedPosition, q.ToString() + " - " + r.ToString(), style);
#endif
            }
        }


    }

    public void CreateHexGrid()
    {

        MeshRenderer meshRenderer = hexPrefab.GetComponentInChildren<MeshRenderer>();
        hexWidth = meshRenderer.bounds.size.x;
        hexHeight = meshRenderer.bounds.size.y;

        hexRadius = hexWidth / Mathf.Sqrt(3);

        GameObject gridsObj = new GameObject("Grids");
        gridsObj.transform.parent = this.transform;
        gridsObj.transform.localRotation = this.transform.localRotation;

        for (int q = -radius; q <= radius; q++)
        {
            for (int r = Mathf.Max(-radius, -q - radius); r <= Mathf.Min(radius, -q + radius); r++)
            {
                Hex hex = new Hex(q, r);
                hex.vector = HexToPosition(hex);
                Vector3 rotatedPosition = this.transform.rotation * hex.vector;
                hexs.Add(hex);
                GameObject hexObj = Instantiate(hexPrefab, 
                    rotatedPosition, 
                    this.transform.rotation);
                hexObj.transform.parent = gridsObj.transform;

            }
        }
    }
    public Vector3 HexToPosition(Hex hex)
    {
        float x = hexWidth * 0.75f * hex.q;
        float y = (Mathf.Sqrt(3.0f) / 2.0f * hex.q + Mathf.Sqrt(3.0f) * hex.r) * hexRadius * (hexHeight / hexWidth);
        return new Vector3(x, y, 0);
    }
}

[System.Serializable]
public class Hex
{
    public int q;
    public int r;
    public Vector3 vector;
    public Color color;

    public Hex(int q, int r)
    {
        this.q = q;
        this.r = r;
    }
    public bool Equals(Hex hex)
    {
        if (hex.q == this.q && hex.r == this.r)
        {
            return true;
        }
        else
            return false;
    }
}

