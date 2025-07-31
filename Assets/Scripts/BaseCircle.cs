using UnityEngine;
using UnityEditor.UI;
using Microsoft.Unity.VisualStudio.Editor;

public abstract class BaseCircle : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //ABSTRACTION
    public abstract void RandomizeColor();
    public abstract void SetColor(Color color);
}
