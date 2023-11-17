using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tiles : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TilemapRenderer tr;
    [SerializeField] private Color hoverColor;

    private GameObject tower; // Change the type to GameObject
    private Color startColor;

    private void Start()
    {
        startColor = tr.material.color;
    }

    private void OnMouseEnter()
    {
        tr.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        tr.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if (tower != null) return;

        Tower towerToBuild = TowerPlacement.main.GetSelectedTower();

        if (towerToBuild.cost > LevelManager.main.credits)
        {
            Debug.Log("You can't buy this");
            return;
        }

        LevelManager.main.SpendCredits(towerToBuild.cost);

        tower = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
    }
}
