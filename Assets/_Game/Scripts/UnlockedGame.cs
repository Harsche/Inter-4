using UnityEngine;
using System.IO;

public class UnlockedGame : MonoBehaviour
{
    public TextAsset[] daySaves;

    public void ChangeDaySave(int day)
    {
        int save = day - 2;
        if(File.Exists(SaveManager.savePath))
        {
            File.Delete(SaveManager.savePath);
        }
        File.WriteAllText(SaveManager.savePath, daySaves[save].ToString());
    }
}
