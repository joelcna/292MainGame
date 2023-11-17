using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI creditUI;
    
    private void OnGUI()
    {
        creditUI.text = LevelManager.main.credits.ToString();
    }

    public void SetSelected() { 

    }
}
