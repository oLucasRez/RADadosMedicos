using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MyVolumeRendering : MonoBehaviour
{
    public int size = 256;
    [SerializeField] public Shader shader;
    public Material material;
    public Texture3D texture;

    // Start is called before the first frame update
    void Start()
    {
        material = new Material(shader);
        GetComponent<MeshRenderer>().sharedMaterial = material;

        int max = size * size * size;
        Color[] colors = new Color[max];
        float inv = 1f / (size - 1);

        texture = new Texture3D(size, size, size, TextureFormat.ARGB32, false);
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.filterMode = FilterMode.Bilinear;
        texture.anisoLevel = 0;

        for (int i = 0; i < size; i++)
        {
            string path = string.Format("Assets/Textures/Slices/-{0:D4}.pgm", i + 1);
            //var pgmfile = Resources.Load(string.Format("Slices/-{0:D4}.pgm", i + 1));
            using (var stream = new FileStream(path, FileMode.Open))
            {
                for (int j = 0; j < size * size; j++)
                {
                    if (i * size + j == max) break;
                    int byteValue = stream.ReadByte();
                    float f = byteValue * inv;
                    colors[i * size * size + j] = new Color(f, f, f, f);
                }
            }
        }

        texture.SetPixels(colors);
        texture.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        material.SetTexture("_Volume", texture);
    }
}
