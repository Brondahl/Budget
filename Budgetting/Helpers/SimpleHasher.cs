using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Budgetting.Helpers
{
  public class SimpleHasher
  {
    private static readonly MD5 hasher = MD5.Create();

    public static string Hash(params object[] inputs)
    {
      byte[] currentHash = new byte[16];
      foreach (var input in inputs)
      {
        var newInputBytes = currentHash.Concat(ControlledObjectToBytes(input));
        currentHash = hasher.ComputeHash(newInputBytes.ToArray());
      }

      return BitConverter.ToString(currentHash).Replace("-", "");
    }

    private static byte[] ControlledObjectToBytes(object input)
    {
      switch (input)
      {
        case null: return new byte[2];
        case string stringInput: return Encoding.UTF8.GetBytes(stringInput);
        case int intInput: return BitConverter.GetBytes(intInput);
        case DateTime dateTimeInput: return BitConverter.GetBytes(dateTimeInput.ToBinary());
        case byte byteInput: return new []{byteInput};
        case byte[] bytesInput: return bytesInput;
        default: throw new NotImplementedException("Tried to hash an object that was not a supported type (string, int, byte[])");
      }
    }
  }
}
