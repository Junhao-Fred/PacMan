using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject manualLevel;
    [SerializeField] private Transform characters;
    [SerializeField] private Camera levelCamera;

    [SerializeField] private GameObject outsideCorner;
    [SerializeField] private GameObject outsideWall;
    [SerializeField] private GameObject insideCorner;
    [SerializeField] private GameObject insideWall;
    [SerializeField] private GameObject batteryCell;
    [SerializeField] private GameObject powerBattery;
    [SerializeField] private GameObject tJunction;
    [SerializeField] private GameObject laserGate;

    private int[,] levelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,8},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0}
    };

    private void Start()
    {
        int rows = levelMap.GetLength(0);
        int columns = levelMap.GetLength(1);

        characters.SetParent(null, true);
        manualLevel.SetActive(false);
        Destroy(manualLevel);

        Transform generatedLevel = new GameObject("Generated Level").transform;
        CreateQuadrant(generatedLevel, "Top Left", Vector3.zero, Vector3.one, rows);
        CreateQuadrant(generatedLevel, "Top Right",
            new Vector3(columns * 2 - 1, 0, 0), new Vector3(-1, 1, 1), rows);
        CreateQuadrant(generatedLevel, "Bottom Left",
            new Vector3(0, -(rows * 2 - 2), 0), new Vector3(1, -1, 1), rows - 1);
        CreateQuadrant(generatedLevel, "Bottom Right",
            new Vector3(columns * 2 - 1, -(rows * 2 - 2), 0),
            new Vector3(-1, -1, 1), rows - 1);

        levelCamera.transform.position = new Vector3(
            columns - 0.5f, 1 - rows, levelCamera.transform.position.z);
        float height = rows * 2 - 1;
        float width = columns * 2;
        levelCamera.orthographicSize = Mathf.Max(
            height / 2f + 1f, width / (2f * levelCamera.aspect) + 1f);
    }

    private void CreateQuadrant(Transform level, string name, Vector3 position,
        Vector3 scale, int rowCount)
    {
        Transform quadrant = new GameObject(name).transform;
        quadrant.SetParent(level);
        quadrant.localPosition = position;
        quadrant.localScale = scale;

        for (int row = 0; row < rowCount; row++)
        {
            for (int column = 0; column < levelMap.GetLength(1); column++)
            {
                GameObject prefab = GetPrefab(levelMap[row, column]);
                if (prefab == null) continue;

                GameObject piece = Instantiate(prefab, quadrant);
                piece.transform.localPosition = new Vector3(column, -row, 0);
                piece.transform.localRotation = Quaternion.Euler(0, 0, GetRotation(row, column));
            }
        }
    }

    private GameObject GetPrefab(int tile)
    {
        switch (tile)
        {
            case 1: return outsideCorner;
            case 2: return outsideWall;
            case 3: return insideCorner;
            case 4: return insideWall;
            case 5: return batteryCell;
            case 6: return powerBattery;
            case 7: return tJunction;
            case 8: return laserGate;
            default: return null;
        }
    }

    private float GetRotation(int row, int column)
    {
        int tile = levelMap[row, column];
        bool left = Connects(tile, GetTile(row, column - 1));
        bool right = Connects(tile, GetTile(row, column + 1));
        bool up = Connects(tile, GetTile(row - 1, column));
        bool down = Connects(tile, GetTile(row + 1, column));

        if (tile == 2 || tile == 4 || tile == 8)
        {
            int horizontal = (left ? 1 : 0) + (right ? 1 : 0);
            int vertical = (up ? 1 : 0) + (down ? 1 : 0);
            return vertical > horizontal ? -90 : 0;
        }

        if (tile == 1 || tile == 3)
        {
            if (right && down && IsOpen(row + 1, column + 1)) return -90;
            if (left && down && IsOpen(row + 1, column - 1)) return 180;
            if (right && up && IsOpen(row - 1, column + 1)) return 0;
            if (left && up && IsOpen(row - 1, column - 1)) return 90;

            if (right && down) return -90;
            if (left && down) return 180;
            if (right && up) return 0;
            return 90;
        }

        if (tile == 7)
        {
            if (!up) return 0;
            if (!down) return 180;
            if (!left) return 90;
            return -90;
        }

        return 0;
    }

    private bool Connects(int tile, int neighbor)
    {
        if (tile == 1 || tile == 2)
            return neighbor == 1 || neighbor == 2 || neighbor == 7;

        if (tile == 3 || tile == 4 || tile == 8)
            return neighbor == 3 || neighbor == 4 || neighbor == 7 || neighbor == 8;

        return neighbor >= 1 && neighbor <= 4 || neighbor == 7 || neighbor == 8;
    }

    private bool IsOpen(int row, int column)
    {
        int tile = GetTile(row, column);
        return tile == 0 || tile == 5 || tile == 6;
    }

    private int GetTile(int row, int column)
    {
        int rows = levelMap.GetLength(0);
        int columns = levelMap.GetLength(1);
        if (row < 0 || column < 0 || row >= rows * 2 - 1 || column >= columns * 2)
            return 0;

        if (row >= rows) row = rows * 2 - 2 - row;
        if (column >= columns) column = columns * 2 - 1 - column;
        return levelMap[row, column];
    }
}
