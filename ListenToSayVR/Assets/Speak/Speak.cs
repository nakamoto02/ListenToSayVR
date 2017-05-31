using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

using UnityEngine.Windows.Speech;
using System.Text;
using System;

public class Speak : MonoBehaviour {

	string[] key = {
		"ファイア",
		"サンダー",
		"ブリザド",
		"ホイミ",
		"ルーラ",
		"「ホーリーセイバー！」",
        "ダークセイバー",
        "「アンパンマン！新しい顔よ！」",
        "バタ子さんが叫ぶ。",
        "セツナ、私の顔が空高く舞い上がる。",
        "普通の人間ではソクシだが、私はアンパンマン。",
        "顔は単なる入力装置に過ぎない。",
        "そう考えているうちにアタラしい顔がねじ込まれる。",//
        "私の顔は残念ながら生ものなので、",
        "いつかは使えなくなってしまう。",
        "しかし、取り換えの隙を見せるわけにはいかない。",
        "それで生み出されたのがこの交換方法だ。",
        "このホウホウはテキにミせるスキをサイショウゲンまでヘらせる。",//
        "ただ、この交換中も油断できない。",
        "敵にとってはチャンスであるからだ。",
        "アタラしい顔は、私にクリアな世界を見せてくれる。",
        "こうして交換しつつヨけることで、",
        "持続的な戦闘が可能になるのだ。",
    };

	public Text tex_OutMessage;
	public Text tex_OutLog;
    public Image fillImage;

    public ReactCube cube;

	KeywordRecognizer kwRecognizer;
    AudioSource audioSource;

	void Start() {

        InitKeywordRecognize();
        InitRecord();

    }

	void InitKeywordRecognize() {

		if(!PhraseRecognitionSystem.isSupported) {
			Debug.Log("not support!");
		}

		kwRecognizer = new KeywordRecognizer(key);
		kwRecognizer.OnPhraseRecognized += OnPhraseRecognized;
		kwRecognizer.Start();
	}

    void InitRecord()
    {
        audioSource = GetComponent<AudioSource>();

        //AudioSource の AudioClip を出力先にして,録音開始.
        //マイクで取り扱えるサンプルレートを調べて当てはめることもできますが,今回は一般的な 44100(44.1kHz) を指定しています.
        audioSource.clip = Microphone.Start(null, true, 10, 44100);

        //録音したデータを延々と取得するためにループさせます.
        audioSource.loop = true;

        //録音したデータは再生する必要がないのでミュートにします.
        audioSource.mute = true;

        //録音が開始されるまで待ちます.
        while (!(Microphone.GetPosition("") > 0)) { }

        //データの中身を取得するために再生を始めます.
        audioSource.Play();
    }

    // Update is called once per frame
    void Update () {

		InputKey();

        SetVolume(GetAveragedVolume());

        cube.SetScale(GetAveragedVolume());
    }

	private void OnPhraseRecognized(PhraseRecognizedEventArgs args) {
		//ログ出力
		StringBuilder builder = new StringBuilder();
		builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
		builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);
		builder.AppendFormat("\tDuration: {0} seconds{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);
		tex_OutLog.text = builder.ToString();

		//認識したキーワードで処理判定
		tex_OutMessage.text = args.text;
	}

	void InputKey() {
		if(Input.GetKeyDown(KeyCode.Z)) {
			MessageReset();
		}
	}

    void SetVolume(float vol)
    {
        fillImage.rectTransform.localScale = new Vector3(vol, 1, 1);
    }

    float GetAveragedVolume()
    {
        //AudioClip の情報を格納する配列.
        //256は適当です.少なすぎれば平均的なサンプルデータが得られなくなるかもしれず,
        //多すぎれば計算量が増えますので良い感じに...
        float[] data = new float[256];
        //最終的に返す音量データ.
        float a = 0;
        //AudioClipからデータを抽出します.
        audioSource.GetOutputData(data, 0);
        //音データを絶対値に変換します.
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        //平均を返します.

        Debug.Log(a);

        return a / 256;
    }

    void MessageReset() {
		tex_OutMessage.text = "-Message-";
	}
}
