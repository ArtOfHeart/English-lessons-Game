using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Pack Items", menuName = "Gameplay/PackItems")]
public class ItemPackInfo : ScriptableObject
{
    [SerializeField] private List<Sprite> _itemSprite;
    [SerializeField] private List<string> _itemName;

    public List<string> ItemName => _itemName;
    public List <Sprite> ItemSprite => _itemSprite;
}
