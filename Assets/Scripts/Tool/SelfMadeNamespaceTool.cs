using UnityEngine;


namespace SelfMadeNamespaceTool
{

    class DataTool
    {
   
        
        public static string GetSaveDataPath()
        {
            return Application.dataPath + "/SaveData/";
        }

        public static string GetArchiveDataPath()
        {
            return Application.dataPath + "/SaveData/ArchiveData/";
        }
    }
    
}
