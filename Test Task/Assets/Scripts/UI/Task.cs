using System.Collections.Generic;
using TMPro;
using UnityEngine;
using GameLogic;

namespace UI
{
    public class Task : MonoBehaviour
    {
        [SerializeField] private LevelLoader _levelLoader;

        private TextMeshProUGUI _textTask;
        private ItemPackInfo[] _itemPacks;

        private int _correctItemIndex, _randomIndex;
        private List<string> _pastAssignments = new List<string>(10);
        private string _correctItemName;

        private void Awake()
        {
            _textTask = GetComponent<TextMeshProUGUI>();
        }
        public void SetTask(List<int> IndexItems, int indexPack)
        {
            for (int i = 0; i < 50; i++)
            {
                _randomIndex = Random.Range(0, IndexItems.Count);
                _correctItemIndex = IndexItems[_randomIndex];

                if (_pastAssignments.Contains(indexPack.ToString() + _correctItemIndex))
                    continue;

                _pastAssignments.Add(indexPack.ToString() + _correctItemIndex);
                break;
            }
            _correctItemName = _itemPacks[indexPack].ItemName[_correctItemIndex];
            _textTask.text = $"Find {_correctItemName}";
        }
        public void SetItemPack(ItemPackInfo[] itemPackInfo)
        {
            _itemPacks = itemPackInfo;
        }
        public bool CheckCorrectChoise(string nameItem)
        {
            if (nameItem == _correctItemName)
            {
                _levelLoader.SwitchLevel();
                return true;
            }
            return false;
        }
    }
}
