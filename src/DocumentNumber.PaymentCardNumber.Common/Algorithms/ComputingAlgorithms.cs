namespace DocumentNumber.PaymentCardNumber.Common.Algorithms
{

  public static class ComputingAlgorithms
  {
    public static int LuhnAlgorithm(string value)
    {
      var sum = 0;
      for (int idx = 0; idx < value.Length; idx++)
      {
        int number = value[value.Length - 1 - idx] - '0';
        if (((value.Length - 1 - idx) % 2) == 0)
        {
          number = number * 2;
          number = number / 10 + number % 10;
        }

        sum += number;
      }
      int checkDigit = 10 - (sum % 10);
      return checkDigit;
    }
  }
}
