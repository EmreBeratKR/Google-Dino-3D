using UnityEngine;

namespace NumberRenderer
{
    public class DigitMesh : MonoBehaviour
    {
        public void Set(int digit)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(i == digit);
            }
        }
    }
}
