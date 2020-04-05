using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridAutoSize : MonoBehaviour {

    private GridLayoutGroup grid;

    private void Awake()
    {
        grid = GetComponent<GridLayoutGroup>();
        float cellS = Screen.height / 1.3f;
        float cellS2 = Screen.height / 7.2f;
        float spa = Screen.height / 20;
        float pad = Screen.height / 2.4f;
        grid.cellSize = new Vector2(cellS, cellS2);
        grid.spacing = new Vector2(spa, spa);
        grid.padding.top = Mathf.RoundToInt(pad);
        grid.padding.bottom = Mathf.RoundToInt(pad);
    }
}
