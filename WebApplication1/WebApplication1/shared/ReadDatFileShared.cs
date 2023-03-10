using System.Text;
using fbk_api.Models;

namespace fbk_api.Shared
{
    public interface IReadDatFileShared{
        string[] ReadDatFile(string path);
    }
	
  public class ReadDatFileShared : IReadDatFileShared
  {
    public string[] ReadDatFile(string path){
       
      string[] readText={};

      if (File.Exists(path))
      {
          readText = File.ReadAllLines(path);
      }

      return readText;

    }
    
  }
}