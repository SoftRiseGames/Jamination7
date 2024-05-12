using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelus : MonoBehaviour
{
    [SerializeField] GameObject letter;
    private void Start()
    {
        FavoriteAnimal();
    }
    void FavoriteAnimal()
    {
        SystemSaveTool.instance.booleans.dataCheck.Add("isPelus");
        SystemSaveTool.instance.booleans.BoyFavoriteAnimal = this.gameObject.name;
        SystemSaveTool.instance.JsonSaveVoid();
    }
    // Start is called before the first frame update
    
}
