using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    // Start is called before the first frame update
    private MeshRenderer myRenderer;
    public float shownOutlineWidth = 0.001f;

    public Color outlineColor;

    public bool showOutlineForChildren = false;

    public bool outlineIsOn = false;


    void Start()
    {
        myRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowOutline(){
        if(outlineIsOn) return;
        foreach(var mat in myRenderer.materials){
            mat.SetFloat("_OutlineWidth",shownOutlineWidth);
            mat.SetColor("_OutlineColor", outlineColor);
        }
        if(showOutlineForChildren){
            foreach(var childRenderer in gameObject.GetComponentsInChildren<MeshRenderer>()){
                foreach(var mat in childRenderer.materials){
                    mat.SetFloat("_OutlineWidth",shownOutlineWidth);
                    mat.SetColor("_OutlineColor", outlineColor);
                }
            }
        }
        outlineIsOn = true;
    }

    public void HideOutline(){
        if(!outlineIsOn) return;
        foreach(var mat in myRenderer.materials){
            mat.SetFloat("_OutlineWidth",0f);
        }
        if(showOutlineForChildren){
            foreach(var childRenderer in gameObject.GetComponentsInChildren<MeshRenderer>()){
                foreach(var mat in childRenderer.materials){
                    mat.SetFloat("_OutlineWidth",0f);
                }
            }
        }

        outlineIsOn = false;
    }

    public void OnHoverEnter(){
        ShowOutline();
    }

    public void OnHoverExit(){
        HideOutline();
    }

}
