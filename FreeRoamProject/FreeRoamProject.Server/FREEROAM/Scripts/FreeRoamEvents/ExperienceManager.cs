using System;
using System.Linq;
using FreeRoamProject.Server.Core.Buckets;


namespace FreeRoamProject.Server.FreeRoam.Scripts.FreeroamEvents
{
    public class ExperienceManager
    {
        public static void OnAddExperience(PlayerClient client, int experiencePoints)
        {
            try
            {
                bool leveledUp = false;
                int currentLevel = BucketsHandler.FreeRoam.GetCurrentLevel(client);
                int currentRankLimit = Experience.RankRequirement.Where(x => x.Key == currentLevel).First().Value;
                int nextRankLimit = Experience.NextLevelExperiencePoints(currentLevel);
                int currentXp = BucketsHandler.FreeRoam.GetCurrentExperiencePoints(client);

                BucketsHandler.FreeRoam.AddExperience(client, experiencePoints);

                int updatedLevel = BucketsHandler.FreeRoam.GetCurrentLevel(client);
                int updatedXp = BucketsHandler.FreeRoam.GetCurrentExperiencePoints(client);
                int updatedCurrentRankLimit = currentRankLimit;
                int updatedNextRankLimit = nextRankLimit;

                if (currentLevel != updatedLevel)
                {
                    updatedCurrentRankLimit = Experience.RankRequirement.Where(x => x.Key == updatedLevel).First().Value;
                    updatedNextRankLimit = Experience.NextLevelExperiencePoints(updatedLevel);

                    // assume you can only level up once
                    leveledUp = true;
                }

                EventDispatcher.Send(client, "worldEventsManage.Client.UpdateExperience", currentRankLimit, nextRankLimit, updatedCurrentRankLimit, updatedNextRankLimit, currentXp, updatedXp, currentLevel, updatedLevel, leveledUp);
            }
            catch (Exception e)
            {
                ServerMain.Logger.Error(e.ToString());
            }
        }
    }
}
