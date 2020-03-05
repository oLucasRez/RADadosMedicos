using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour {

    Renderer rend;
    public Slider SliderX, SliderY, SliderZ;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("VolumeRendering / VolumeRendering");
	}

    // Update is called once per frame
    public void UpdateObject() { 
        for (int i = 0; i < rend.materials.Length; i++)
        {
            rend.materials[i].SetVector("_SliceMax", new Vector4(SliderX.value, SliderY.value, SliderZ.value, -1));
        }
    }

}
