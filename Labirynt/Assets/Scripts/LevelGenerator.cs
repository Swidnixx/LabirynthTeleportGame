using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public ColorToPrefab[] colorMappings;
    public Texture2D map;
    public float offset = 5;

    void Start()
    {
        GenerateLabirynth();
    }

    void GenerateTile(int x, int z)
    {
        Color pixelColor = map.GetPixel(x, z);

        if (pixelColor.a == 0)
            return;

        foreach(ColorToPrefab mapping in colorMappings)
        {
            if(mapping.color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(x, 0, z) * offset;
                Instantiate(mapping.prefab, position, Quaternion.identity);
            }
        }
    }

    public void GenerateLabirynth()
    {
        for( int x=0; x < map.width; x++)
        {
            for( int z=0; z < map.height; z++)
            {
                GenerateTile(x, z);
            }
        }
    }

}
