using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
#if WINDOWS_UWP
using System;
using Windows.Storage;
using Windows.System;
using System.Threading.Tasks;
using Windows.Storage.Streams;
#endif

public class OutputToFile : MonoBehaviour {

#if WINDOWS_UWP
    Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
    Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
#endif
    private static string timeStamp = System.DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
    private static string fileName = timeStamp + ".txt";

    private static bool firstSave = true;
    // Use this for initialization
    void Start () {
        //var fileName = "MyFile.txt";
       
        
        

        

        InvokeRepeating("WriteData", 1.0f, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
       
    }
#if WINDOWS_UWP
    async void WriteData()
    {
        var headPosition = Camera.main.transform.position;

        var saveInformation = "X =" + headPosition.x.ToString() + "Y =" + headPosition.y.ToString();
        if (firstSave){
        StorageFile sampleFile = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
        await FileIO.AppendTextAsync(sampleFile, saveInformation + "\r\n");
        firstSave = false;
        }
    else{
        StorageFile sampleFile = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
        await FileIO.AppendTextAsync(sampleFile, saveInformation + "\r\n");
    }
    }
#endif



    /*void UpdatePos()
    {
        
        var headPosition = Camera.main.transform.position;
        var sr = File.AppendText("c:\\KBTest.txt");
        sr.WriteLine("X = {0}, Y = {1}, Z = {2}", headPosition.x, headPosition.y, headPosition.z);
    }
    */
}


