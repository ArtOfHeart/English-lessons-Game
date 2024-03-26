using UnityEngine;
using Animation;

namespace GameLogic
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField] private LevelInfo[] _levelInfo;
        [SerializeField] private ItemBuilder _itemSpawner;
        [SerializeField] private RestartAnamation _restart;

        private int _currentLevel, _columnsCount, _rowsCount;

        public int CurrentLevel => _currentLevel;
        public int ColumnsCount => _columnsCount;
        public int RowsCount => _rowsCount;

        private void Awake()
        {
            _currentLevel = 0;
            LoadLevelInfo();
        }
        public void LoadLevelInfo()
        {
            _columnsCount = _levelInfo[_currentLevel].ColumnsCount;
            _rowsCount = _levelInfo[_currentLevel].RowCount;
        }
        async public void SwitchLevel()
        {
            await System.Threading.Tasks.Task.Delay(1500);

            if (_currentLevel >= _levelInfo.Length - 1)
            {
                _restart.gameObject.SetActive(true);
                return;
            }
            _currentLevel++;
            LoadLevelInfo();
            _itemSpawner.SpawnItems();
        }
        public void RestartLevels()
        {
            _currentLevel = -1;
        }
    }
}
