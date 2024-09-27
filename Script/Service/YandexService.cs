using UnityEngine;
using YG;

namespace Script.Yandex
{
    public class YandexService
    {
        public static void PlayRewardedAd()
        {
            YandexGame.RewVideoShow(1);
        }

        public static void SaveBestScore(int score)
        {
            YandexGame.NewLeaderboardScores("MergeEvolution", score);
        }
    }
}