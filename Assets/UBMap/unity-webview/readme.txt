https://github.com/gree/unity-webview
================================================
For iOS

CADisplayLink stops updating when UIWebView scrolled, thus you have to change AppController.mm as the following.

-        [_displayLink addToRunLoop:[NSRunLoop currentRunLoop] forMode:NSDefaultRunLoopMode];
+        [_displayLink addToRunLoop:[NSRunLoop currentRunLoop] forMode:NSRunLoopCommonModes];
================================================
For Web Player

Since using IFRAME, some problems can be occurred because of browsers' XSS prevention. 
It is desired that "an_unityplayer_page.html…" and "a_page_loaded_in_webview.html…" are located at same domain.

================================================
Android: Uncaught TypeError: Object [object Object] has no method 'call'

https://github.com/gree/unity-webview/issues/10

================================================
Sample Project

$ open sample/Assets/Sample.unity
$ open dist/unity-webview.unitypackage
Import all files
================================================
Notes on Adnroid

Once you built an apk, please copy sample/Temp/StatingArea/AndroidManifest-main.xml to 
sample/Assets/Plugins/AndroidManifest.xml, 
edit the latter to add android:hardwareAccelerated="true" to 
<activity android:name="com.unity3d.player.UnityPlayerActivity" ..., 
and rebuilt the apk. Although some old/buggy devices may not work 
well with android:hardwareAccelerated="true", the webview runs very smoothly with this setting.