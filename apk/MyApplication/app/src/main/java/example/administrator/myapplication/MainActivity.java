package example.administrator.myapplication;

import android.content.*;
import android.net.Uri;
import android.os.*;
import android.support.v4.content.*;
import com.unity3d.player.*;
import java.io.*;
public class MainActivity {
    public static boolean installAPK(String apkPath) {
        File apkFile = new File(apkPath);
        if (apkFile.exists()) {
            Intent intent = new Intent(Intent.ACTION_VIEW);
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
                intent.setFlags(Intent.FLAG_GRANT_READ_URI_PERMISSION);
                Uri contentUri = FileProvider.getUriForFile(UnityPlayer.currentActivity, UnityPlayer.currentActivity.getPackageName()+".fileprovider", apkFile);
                intent.setDataAndType(contentUri, "application/vnd.android.package-archive");
            } else {
                intent.setDataAndType(Uri.fromFile(apkFile), "application/vnd.android.package-archive");
                intent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            }
           // if (UnityPlayer.currentActivity.getPackageManager().queryIntentActivities(intent, 0).size() > 0) {
                UnityPlayer.currentActivity.startActivity(intent);
          //  }
            return true;
        } else {
            return false;
        }
    }
}
