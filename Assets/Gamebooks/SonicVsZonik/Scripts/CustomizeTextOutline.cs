using TMPro;
using UnityEngine;

public class CustomizeTextOutline : MonoBehaviour
{
    public float outlineSize = 0f;

    void Start()
    {
        // Get the TextMeshPro component
        TextMeshProUGUI textMeshPro = GetComponent<TextMeshProUGUI>();
        
        // Get a new instance of the material for this TextMeshPro component
        Material textMaterial = textMeshPro.fontMaterial;

        // Modify the outline size
        textMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, outlineSize);
        
        // Apply the new material instance to the TextMeshPro component
        textMeshPro.fontMaterial = textMaterial;
    }
}
