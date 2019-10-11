using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour//exibe ou esconde a malha da face e o modo debug
{
    //ATRIBUTOS::
    [Tooltip("Shows the attribute values when Debug mode is enabled.")]
    public Text AttributeText;

    public GameObject FaceMesh;

    bool debugMode = false;
    bool showingFace = false;
    public bool ShowingFace { get { return showingFace; } }

    private Transform transf;
    //MÉTODOS::
    void Awake()
    {
        Transform[] tempTransforms = FaceMesh.GetComponentsInChildren<Transform>();
        for (int i = 0; i < tempTransforms.Length; i++)
        {
            if (tempTransforms[i].parent == FaceMesh.transform)
            {
                transf = tempTransforms[i];
                break;
            }
        }
#if WINDOWS_UWP
        HideFace();
#else
        ShowFace();
#endif
        transf.gameObject.SetActive(true);
    }

    public void ShowFace()
    {
        Renderer renderer = FaceMesh.GetComponent<Renderer>();
        renderer.enabled = true;
        showingFace = true;
    }

    public void HideFace()
    {
        Renderer renderer = FaceMesh.GetComponent<Renderer>();
        renderer.enabled = false;
        showingFace = false;
    }

    public void ShowDebug() { debugMode = true; }

    public void HideDebug()
    {
        debugMode = false;
        if (AttributeText != null)
            AttributeText.text = "";
    }
}
