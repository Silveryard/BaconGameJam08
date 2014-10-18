using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Events{
    public static event Action<int> PlayerHealthChanged;
    public static event Action<int> WaveChanged;
    public static event Action<int> ScoreChanged;

    public static void ResetEvents(){
        PlayerHealthChanged = null;
        WaveChanged = null;
        ScoreChanged = null;
    }

    public static void OnScoreChanged(int obj){
        Action<int> handler = ScoreChanged;
        if (handler != null) handler(obj);
    }

    public static void OnWaveChanged(int obj){
        Action<int> handler = WaveChanged;
        if (handler != null) handler(obj);
    }

    public static void OnPlayerHealthChanged(int obj){
        Action<int> handler = PlayerHealthChanged;
        if (handler != null) handler(obj);
    }
}