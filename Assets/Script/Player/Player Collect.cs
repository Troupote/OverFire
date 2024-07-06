using UnityEngine;
using UnityEngine.UI;

public class PlayerCollect : MonoBehaviour
{
    public GameObject[] imageObjects;
    private int i = 0;

    public void OnTriggerEnter(Collider other)
    {
        // Récupérer le scriptableObject de l'objet touché
        ObjectWithSO objectWithSO = other.GetComponent<ObjectWithSO>();
        if (objectWithSO != null)
        {
            MyScriptableObject scriptableObject = objectWithSO.myScriptableObject;
            if (scriptableObject != null)
            {
                if (scriptableObject.objectName == "feur")
                {
                    if (i < imageObjects.Length)
                    {
                        imageObjects[i].GetComponent<Image>().sprite = scriptableObject.ObjectImage;
                        i++;
                    }
                    Destroy(other.gameObject); // Détruire l'objet collecté
                }
                else
                {
                    GetComponent<Renderer>().material.color = scriptableObject.objectColor;
                }
            }
        }
    }
}
