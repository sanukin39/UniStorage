using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

/* 参考 
http://stackoverflow.com/questions/5712527/how-to-detect-total-available-free-disk-space-on-the-iphone-ipad-device
http://xoyip.hatenablog.com/entry/2014/04/19/234427
*/
public class UniStorage {

    [DllImport("__Internal")]
    private static extern int availableStorage_();

    // ストレージの空容量を調べる
    public static int StorageAvailableMb(){
        #if UNITY_EDITOR
        return 0;
        #elif UNITY_IPHONE
        return availableStorage_();
        #elif UNITY_ANDROID
        var statFs = new AndroidJavaObject ("android.os.StatFs", Application.persistentDataPath);
        var availableBlocks = statFs.Call<long> ("getAvailableBlocksLong");
        var blockSize = statFs.Call<long> ("getBlockSizeLong");
        var freeBytes = availableBlocks * blockSize;
        Debug.Log("fb: " + freeBytes);
        return (int)(freeBytes / 1024 / 1024);
        #endif
    }
}
