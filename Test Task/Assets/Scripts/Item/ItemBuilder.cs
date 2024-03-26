using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Animation;
using UI;

namespace GameLogic
{
    public class ItemBuilder : MonoBehaviour
    {
        [SerializeField] private LevelLoader _levelLoader;
        [SerializeField] private GameObject _itemPrefab;
        [SerializeField] private ItemPackInfo[] _itemPackages;
        [SerializeField] private Task _task;

        private GridLayoutGroup _layoutGroup;

        private int _currentPack;

        private List<int> _indexItems = new List<int>(30);
        private int _tempIndex;

        private void Start()
        {
            _layoutGroup = GetComponent<GridLayoutGroup>();
            _task.SetItemPack(_itemPackages);
            SpawnItems();
        }
        public void SpawnItems()
        {
            _indexItems.Clear();
            ClearItems();
            _layoutGroup.constraintCount = _levelLoader.RowsCount;

            _currentPack = Random.Range(0, _itemPackages.Length);
            for (int i = 0; i < _levelLoader.RowsCount * _levelLoader.ColumnsCount; i++)
                SetItemInformation(Instantiate(_itemPrefab, transform));

            _task.SetTask(_indexItems, _currentPack);
        }
        private void SetItemInformation(GameObject item)
        {
            if (_levelLoader.CurrentLevel == 0)
            {
                item.TryGetComponent(out AnimationCell animationCell);
                animationCell.AnimationAppearance();
            }
            item.TryGetComponent(out Item curentItem);
            CalculateIndexItem();
            curentItem.Name = _itemPackages[_currentPack].ItemName[_tempIndex];
            curentItem.SetIcon(_itemPackages[_currentPack].ItemSprite[_tempIndex]);
            curentItem.Task = _task;
        }
        private void CalculateIndexItem()
        {
            _tempIndex = GetRandomValue();

            while (_indexItems.Contains(_tempIndex))
                _tempIndex = GetRandomValue();

            _indexItems.Add(_tempIndex);
        }
        private int GetRandomValue() => Random.Range(0, _itemPackages[_currentPack].ItemName.Count);

        private void ClearItems()
        {
            while (transform.childCount > 0)
            {
                DestroyImmediate(transform.GetChild(0).gameObject);
            }
        }
    }
}
