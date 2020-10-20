using System;
using UnityEngine;

namespace Resources.Scripts.Environment
{
    public class TerrainGeneration : MonoBehaviour
    {
        public int width = 256;
        public int height = 256;
        public int depth = 20;
        public float scale = 20;
        
        private void Start()
        {
            var terrain = GetComponent<Terrain>();
            terrain.terrainData = GenerateTerrain(terrain.terrainData);
        }

        private TerrainData GenerateTerrain(TerrainData terrainData)
        {
            terrainData.heightmapResolution = width + 1;
            terrainData.size = new Vector3(width, depth, height);
            terrainData.SetHeights(0, 0, GenerateHeights());

            return terrainData;
        }

        private float[,] GenerateHeights()
        {
            var heights = new float[width, height];

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    heights[x, y] = CalculateHeight(x, y);
                }
            }

            return heights;
        }

        private float CalculateHeight(int x, int y)
        {
            var xCoord = (float)x / width * scale;
            var yCoord = (float)y / height * scale;

            return Mathf.PerlinNoise(xCoord, yCoord);
        }
    }
}
