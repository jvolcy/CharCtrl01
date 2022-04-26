using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCtrl : MonoBehaviour
{
    public GameObject Civilian;
    public GameObject HumanHero;

    SkinnedMeshRenderer[] CivilianSkinnedMeshRenderers; //list of civilian skinned mesh renderer
    Shader[] DefaultCivilianShader;     //list of shaders corresponding to each civilian mesh renderer
    //Shader CivilianShader;      //the current rendere assigned to all civilian meshes.

    List<Shader> DefaultHumanHeroShader;
    Shader HumanHeroShader;

    // Start is called before the first frame update
    void Start()
    {
        StoreDefaultSkinnedMeshRenderes();
    
    }

    void SetTransparentShaders()
    {
        //restore the default shader for each of the civilian's meshrenderers
        for (int i = 0; i < CivilianSkinnedMeshRenderers.Length; i++)
        {
            CivilianSkinnedMeshRenderers[i].material.shader = Shader.Find("Standard");
            //CivilianSkinnedMeshRenderers[i].material.shader.
        }

    }


    void StoreDefaultSkinnedMeshRenderes()
    {
        if (CivilianSkinnedMeshRenderers == null)
        {
            CivilianSkinnedMeshRenderers = Civilian.GetComponentsInChildren<SkinnedMeshRenderer>();
        }

        Debug.Log("Found " + CivilianSkinnedMeshRenderers.Length + " Civilian SkinnedMeshRenderers.");

        //create an array of shaders, one for each meshrenderer
        DefaultCivilianShader = new Shader[CivilianSkinnedMeshRenderers.Length];

        //store the default shader for each of the civilian's meshrenderers
        for (int i = 0; i < CivilianSkinnedMeshRenderers.Length; i++)
        {
            //Lists are ordered, so this logic will keep a 1-to-1 correlation between the shader and materials list
            DefaultCivilianShader[i] = CivilianSkinnedMeshRenderers[i].material.shader;
            Debug.Log("Civilian material shader: " + DefaultCivilianShader[i]);
        }

    }

    void restoreDefaultSkinnedMeshRenderes()
    {
        if (CivilianSkinnedMeshRenderers == null)       //this should never happen
        {
            Debug.Log("There are no skinned mesh renderers. (Therefore, no material shaders to restore.)");
            return;
        }

        //restore the default shader for each of the civilian's meshrenderers
        for (int i = 0; i < CivilianSkinnedMeshRenderers.Length; i++)
        {
            CivilianSkinnedMeshRenderers[i].material.shader = DefaultCivilianShader[i];
            Debug.Log("Restored Civilian material shader: " + DefaultCivilianShader[i]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetTransparentShaders();
            Civilian.GetComponent<Animator>().SetTrigger("FadeOut");
        }
    }
}
