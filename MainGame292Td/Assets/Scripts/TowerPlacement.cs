using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerPlacement : MonoBehaviour
{
    public static TowerPlacement main;
    [Header("References")]
    [SerializeField] private Tower[] towers;

    private int selectedTower = 0;

    private void Awake()
    {
        main = this;
    }

    public Tower GetSelectedTower()
    {
        return towers[selectedTower];
    }

    public void SetSelectedTower(int _selectedTower)
    {
        selectedTower = _selectedTower;
    }
}
