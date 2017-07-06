using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Windows.Speech;
using System.Text;
using System;

public class PlayerSpeak_Wani : MonoBehaviour
{
    string[] keyWords;

    //怒りモードのキーワード
    string[] angerKeyWords =
    {
        "よゆう",
        "かんたん"
    };

    //にこやかモード
    string[] smileKeyWords =
    {
        "やめて"
    };

    public Transform playerHead;
    public Enemy_Create enemyCreate;


    KeywordRecognizer kwRecognizer;

    void Start ()
    {
        KeyUnion();

        kwRecognizer = new KeywordRecognizer(keyWords);
        kwRecognizer.OnPhraseRecognized += OnPhraseRecognized;
        kwRecognizer.Start();
    }

    //string配列を統合
    void KeyUnion()
    {
        keyWords = new string[angerKeyWords.Length + smileKeyWords.Length];

        int keyNo = 0;

        for(int i = 0; i < keyWords.Length; i++)
        {
            //一つの配列に
            if(i < angerKeyWords.Length)
                keyWords[i] = angerKeyWords[keyNo];
            else
                keyWords[i] = smileKeyWords[keyNo];

            if (i == angerKeyWords.Length - 1) keyNo = 0;
            else keyNo++;
        }
    }

    void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        //ログ出力
        //StringBuilder builder = new StringBuilder();
        //builder.AppendFormat("{0} ({1}){2}", args.text, args.confidence, Environment.NewLine);
        //builder.AppendFormat("\tTimestamp: {0}{1}", args.phraseStartTime, Environment.NewLine);
        //builder.AppendFormat("\tDuration: {0} seconds{1}", args.phraseDuration.TotalSeconds, Environment.NewLine);
        //Debug.Log(builder.ToString());

        //認識したキーワードで処理判定
        foreach(string key in angerKeyWords)
        {
            if(args.text == key)
            {
                //EnemyManager.PlayerSpeak(playerHead.position, 20.0f, Color.red);
                enemyCreate.ChangeMode(2);
            }
        }

        foreach(string key in smileKeyWords)
        {
            if(args.text == key)
            {
                //EnemyManager.PlayerSpeak(playerHead.position, 20.0f, Color.blue);
                enemyCreate.ChangeMode(0);
            }
        }
    }
}
