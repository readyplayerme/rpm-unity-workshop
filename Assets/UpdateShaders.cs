using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UpdateShaders : Editor
{
    [MenuItem("Tools/Update Shaders")]
    public static void Update()
    {
        var materials = AssetDatabase.FindAssets("t:Material");
        foreach (var material in materials)
        {
            var path = AssetDatabase.GUIDToAssetPath(material);
            var mat = AssetDatabase.LoadAssetAtPath<Material>(path);

            if (mat.shader.name == "Custom/ToonShader")
            {
                Texture mainTex = mat.GetTexture("_MainTex");
                Color mainColor = mat.GetColor("_Color");
                float specPower = mat.GetFloat("_SpecularPower");

                mat.shader = Shader.Find("Universal Render Pipeline/Lit");
                mat.SetTexture("_BaseMap", mainTex);
                mat.SetColor("_BaseColor", mainColor);
                mat.SetFloat("_Smoothness", specPower);
            }
        }
    }
}
