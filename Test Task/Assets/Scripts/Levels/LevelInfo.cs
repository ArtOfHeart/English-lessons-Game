using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Gameplay/Level")]
public class LevelInfo : ScriptableObject
{
    [SerializeField] private int _columnsCount;
    [SerializeField] private int _rowCount;

    public int ColumnsCount => _columnsCount;
    public int RowCount => _rowCount;
}
