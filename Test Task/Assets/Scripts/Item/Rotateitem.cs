using UnityEngine;

namespace GameLogic
{
    public class Rotateitem : MonoBehaviour
    {
        private Item _item;
        private void Start()
        {
            _item = GetComponent<Item>();
            if (_item.Name == "Eight" || _item.Name == "Seven")
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
        }
    }
}
