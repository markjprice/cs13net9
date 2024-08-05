using static System.Environment;

namespace Northwind.EntityModels;

public class NorthwindContextLogger
{
  public static void WriteLine(string message)
  {
    string dateTimeStamp = DateTime.Now.ToString(
      "yyyyMMdd_HHmmss");

    string path = Path.Combine(GetFolderPath(
      SpecialFolder.DesktopDirectory), 
      $"northwindlog-{dateTimeStamp}.txt");

    StreamWriter textFile = File.AppendText(path);
    textFile.WriteLine(message);
    textFile.Close();
  }
}
