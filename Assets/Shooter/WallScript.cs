using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    [SerializeField]
    GameObject cubePrefab;
    List<GameObject> cubes = new List<GameObject>();
    Color[] colors = {
        new Color(1.0f, 0.0f, 0.0f, 0.5f), new Color(0.0f, 1.0f, 0.0f, 0.5f),
        new Color(0.0f, 0.0f, 1.0f, 0.5f), new Color(1.0f, 1.0f, 1.0f, 0.5f) };
    public int x_box_num = 5;
    public int y_box_num = 5;
    // Start is called before the first frame update
    void Start()
    {
        InitializeWall();
    }
    void InitializeWall()
    {
        int index = 0;
        float offset = cubePrefab.transform.localScale.x * (x_box_num - 1) * 0.5f;
        for (int y = 0; y < y_box_num; y++)
        {
            for (int x = 0; x < x_box_num; x++)
            {
                GameObject cube = GameObject.Instantiate(cubePrefab);
                cube.transform.parent = transform;
                cube.transform.localPosition = new Vector3(x * cube.transform.localScale.x-offset, y * cube.transform.localScale.y, 0);
                cube.GetComponent<Renderer>().material.color = colors[index];
                index++;
                index %= colors.Length;
                cubes.Add(cube);

            }
        }
    }
    public void ResetWall()
    {
        for(int i = 0; i < cubes.Count; i++)
        {
            DestroyImmediate(cubes[i]);
        }
        cubes.Clear();
        InitializeWall();
    }
}
