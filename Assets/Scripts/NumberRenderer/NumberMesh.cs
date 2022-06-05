using UnityEngine;

namespace NumberRenderer
{
    public class NumberMesh : MonoBehaviour
    {
        [SerializeField] private DigitMesh[] digits;


        public void Set(int number)
        {
            var numberAsString = number.ToString();
            var numberLength = numberAsString.Length;

            for (int i = 0; i < digits.Length - numberLength; i++)
            {
                numberAsString = "0" + numberAsString;
            }


            numberAsString = numberAsString.Substring(0, digits.Length);

            for (int i = 0; i < digits.Length; i++)
            {
                var digit = int.Parse(numberAsString.Substring(i, 1));
                digits[i].Set(digit);
            }
        }
    }
}
