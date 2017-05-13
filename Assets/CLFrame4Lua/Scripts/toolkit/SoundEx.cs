using UnityEngine;
using System.Collections;
using LuaInterface;

namespace Toolkit
{
	public class SoundEx
	{
		/// <summary>
		/// Plaies the sound with callback.播放音效，带完成回调方法
		/// </summary>
		/// <param name='go'>
		/// Go.
		/// </param>
		/// <param name='clip'>
		/// Clip.
		/// </param>
		/// <param name='volume'>
		/// Volume.
		/// </param>
		/// <param name='callback'>
		/// Callback.
		/// </param>
		public static void PlaySoundWithCallback (MonoBehaviour go, AudioClip clip, float volume, object callback)
		{
//		audio.PlayOneShot (clip);
			NGUITools.PlaySound (clip, volume);
			go.StartCoroutine (DelayedCallback (clip, clip.length, callback));
		}

		static IEnumerator DelayedCallback (AudioClip clip, float time, object callback)
		{
			yield return new WaitForSeconds (time);
			SSoundPool.returnAudio (clip.name);
			if (typeof(LuaFunction) == callback.GetType ()) {
				((LuaFunction)callback).Call (clip);
			} else if (typeof(Callback) == callback.GetType ()) {
				((Callback)callback) (clip);
			}
		}
	
		static Hashtable playSoundCount = new Hashtable ();
		/// <summary>
		/// Plaies the sound.播放音效，可指定同时最大播放次数
		/// </summary>
		/// <param name='soundPath'>
		/// Sound path.
		/// </param>
		/// <param name='volume'>
		/// Volume.
		/// </param>
		/// <param name='maxTimes'>
		/// Max times.同时最大播放次数
		/// </param>
		public static void playSound (string name, float volume, int maxTimes = 1)
		{
			if (!soundEffSwitch)
				return;
			if (!string.IsNullOrEmpty (name)) {
				AudioClip clip = SSoundPool.borrowAudio (name);
				if (clip != null) {
					if (playSoundCount [clip.name] == null || (int)(playSoundCount [clip.name]) < maxTimes) {
						playSoundCount [clip.name] = (playSoundCount [clip.name] == null ? 1 : (int)(playSoundCount [clip.name]) + 1);
						Callback cb = finishPlaySound;
						PlaySoundWithCallback (CLMain.self, clip, volume, cb);
					}
				} else {
					SSoundPool.setPrefab(name, (Callback)onFinishSetAudio);
				}
			}
		}
		
		public static void onFinishSetAudio(params object[] args) {
			if(args == null || args.Length == 0) return;
			AudioClip ac =((AudioClip)args [0]); 
			if(ac != null) {
				string name = ac.name;
				playSound (name, 1);
			}
		}

		//只能同时播一个音乐/音效
		public static void playSoundSingleton(string name, float volume) {
			if (!soundEffSwitch)
				return;
			SCfg.self.singletonAudio.loop = false;
			SCfg.self.singletonAudio.Stop();
			if (!string.IsNullOrEmpty (name)) {
				AudioClip clip = SSoundPool.borrowAudio (name);
				if (clip != null) {
					SCfg.self.singletonAudio.clip = clip;
					SCfg.self.singletonAudio.Play();
				} else {
                    SSoundPool.setPrefab(name, (Callback)onFinishSetAudio4Singleton);
				}
			}
		}

		public static void onFinishSetAudio4Singleton(params object[] args) {
            AudioClip ac =((AudioClip)args [0]); 
            if(ac != null) {
                string name = ac.name;
                playSoundSingleton (name, 1);
            }
		}
		
		public static bool soundEffSwitch {
			get {
				int f = PlayerPrefs.GetInt ("soundEffSwitch", 0);
				return f == 0 ? true : false;
			}
			set {
				int f = value ? 0 : 1;
				PlayerPrefs.SetInt ("soundEffSwitch", f);
			}
		}

		public static bool musicSwitch {
			get {
				int f = PlayerPrefs.GetInt ("musicSwitch", 0);
				return f == 0 ? true : false;
			}
			set {
				int f = value ? 0 : 1;
				PlayerPrefs.SetInt ("musicSwitch", f);
			}
		}
		
		public static void playSound (AudioClip clip, float volume, int maxTimes = 1)
		{
//		if (!DBPrefs.getSoundEffSwitch ())
//			return;
			if (clip == null)
				return;
			if (playSoundCount [clip.name] == null || (int)(playSoundCount [clip.name]) < maxTimes) {
				playSoundCount [clip.name] = (playSoundCount [clip.name] == null ? 1 : (int)(playSoundCount [clip.name]) + 1);
				Callback cb = finishPlaySound;
				PlaySoundWithCallback (CLMain.self, clip, volume, cb);
			}
		}
		
		public static void playSound2 (string clipName, float volume)
		{
			AudioClip clip = Resources.Load (clipName) as AudioClip;
			NGUITools.PlaySound (clip, volume);
		}
	
		static void finishPlaySound (params object[] obj)
		{
			AudioClip clip = (AudioClip)(obj [0]);
			if (clip != null) {
				playSoundCount [clip.name] = (playSoundCount [clip.name] == null ? 0 : (int)(playSoundCount [clip.name])) - 1;
				playSoundCount [clip.name] = (int)(playSoundCount [clip.name]) < 0 ? 0 : playSoundCount [clip.name];
				//Resources.UnloadAsset(clip);
			}
		}


//		-- 播放背景音乐---------------
		public static AudioClip mainClip;
		public static void onGetMainMusic (params object[] args)
		{
			string path = (string)(args[0]);
			AssetBundle content = (AssetBundle)(args[1]);
			if(content == null) {
				return;
			}
			mainClip = (AudioClip)(content.mainAsset);
			doPlayMainMusic (mainClip);
		}
		
		public static void doPlayMainMusic (AudioClip clip)
		{
			if (SCfg.self.mainAudio.clip != mainClip) {
				SCfg.self.mainAudio.clip = mainClip;
				SCfg.self.mainAudio.Play ();
			} else {
				if (!SCfg.self.mainAudio.isPlaying) {
					SCfg.self.mainAudio.Play ();
				}
			}
		}
		
		public static void playMainMusic ()
		{
			if (SoundEx.musicSwitch) {
				if (mainClip != null) {
					doPlayMainMusic (mainClip);
				} else {
					string path = PathCfg.self.basePath + "/" + PathCfg.upgradeRes + "/other/sound/" + PathCfg.self.platform + "/MainScen.unity3d";
					CLVerManager.self.getNewestRes (
						path,
						CLAssetType.assetBundle, 
						(Callback)onGetMainMusic, null
					); 
				}
			}
		}
	}
}
