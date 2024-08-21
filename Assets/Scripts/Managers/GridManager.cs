using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    public int radius;
    public int desiredAngle;
    float hexRadius;
    float hexWidth;
    float hexHeight;
    GameObject gizmosPrefab;
    public List<Hex> hexs = new List<Hex>();
    private void Awake()
    {
        Instance = this;
        CreateHexGrid();
    }
    private void OnDrawGizmos()
    {
        gizmosPrefab = Resources.Load("HexGridPrefab") as GameObject;
        MeshRenderer meshRenderer = gizmosPrefab.GetComponentInChildren<MeshRenderer>();
        hexWidth = meshRenderer.bounds.size.x;
        hexHeight = meshRenderer.bounds.size.y;

        hexRadius = hexWidth / Mathf.Sqrt(3);

        for (int q = -radius; q <= radius; q++)
        {
            for (int r = Mathf.Max(-radius, -q - radius); r <= Mathf.Min(radius, -q + radius); r++)
            {
                Hex hexCoordinates = new Hex(q, r);
                Vector3 position = HexToPosition(hexCoordinates);
                Gizmos.DrawMesh(gizmosPrefab.GetComponentInChildren<MeshFilter>().sharedMesh,
                    position,
                    Quaternion.identity,
                    gizmosPrefab.GetComponent<Transform>().localScale);
                Gizmos.color = Color.white;
                GUIStyle style = new GUIStyle();
                style.alignment = TextAnchor.MiddleCenter;
                style.normal.textColor = Color.black;
#if UNITY_EDITOR
                UnityEditor.Handles.Label(position, q.ToString() + " - " + r.ToString(), style);
#endif
            }
        }


    }

    public void CreateHexGrid()
    {

        MeshRenderer meshRenderer = GameAssets.Instance.gridPrefab.GetComponentInChildren<MeshRenderer>();
        hexWidth = meshRenderer.bounds.size.x;
        hexHeight = meshRenderer.bounds.size.y;

        if (GameAssets.Instance == null || GameAssets.Instance.gridPrefab == null) return;

        hexRadius = hexWidth / Mathf.Sqrt(3);

        GameObject gridsObj = new GameObject("Grids");
        gridsObj.transform.parent = this.transform;
        for (int q = -radius; q <= radius; q++)
        {
            for (int r = Mathf.Max(-radius, -q - radius); r <= Mathf.Min(radius, -q + radius); r++)
            {
                Hex hex = new Hex(q, r);
                hex.vector = HexToPosition(hex);
                hexs.Add(hex);
                GameObject hexObj = Instantiate(GameAssets.Instance.gridPrefab, hex.vector, Quaternion.identity);
                hexObj.transform.parent = gridsObj.transform;

            }
        }
        gridsObj.transform.rotation = Quaternion.Euler(desiredAngle, 0, 0);
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

