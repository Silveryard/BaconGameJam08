using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Score{
    private static int _score;

    public static void AddScore(int x){
        _score += x;
        Events.OnScoreChanged(_score);
    }

    public static void ResetScore(){
        _score = 0;
        Events.OnScoreChanged(_score);
    }

    public static int GetScore(){
        return _score;
    }
}