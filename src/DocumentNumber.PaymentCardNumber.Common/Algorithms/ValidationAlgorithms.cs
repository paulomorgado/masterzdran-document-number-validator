using System;

namespace DocumentNumber.PaymentCardNumber.Common.Algorithms
{
  public static class ValidationAlgorithms
  {
    public static bool LuhnAlgorithm(string value)
    {
      var sum = 0;
      int number = 0;


      for (int idx = value.Length - 1; idx > -1; idx--)
      {
        number = value[idx] - '0';
        if ((value.Length - idx & 0x1) == 0)
        {
          number = number * 2;
          number = number / 10 + number % 10;
        }

        sum += number;
      }


      return sum % 10 == 0;
    }
  }
}
