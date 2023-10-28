using System;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.GameMode.FREEROAM.Managers
{
    public static class ExperienceManager
    {
        public static void Init()
        {
            AccessingEvents.OnFreeRoamSpawn += (client) => EventDispatcher.Mount("worldEventsManage.Client.UpdateExperience", new Action<int, int, int, int, int, int, int, int, bool>(OnUpdateExperience));
            AccessingEvents.OnFreeRoamLeave += (client) => EventDispatcher.Unmount("worldEventsManage.Client.UpdateExperience");
        }

        private static async void OnUpdateExperience(int currentRankLimit, int nextRankLimit, int updatedCurrentRankLimit, int updatedNextRankLimit, int currentXp, int updatedXp, int currentLevel, int updatedLevel, bool leveledUp)
        {
            try
            {
                Cache.PlayerCache.MyPlayer.User.Character.Level = updatedLevel;
                Cache.PlayerCache.MyPlayer.User.Character.TotalXp = updatedXp;

                if (!leveledUp)
                {
                    await ShowPlayerRankScoreAfterUpdate(currentRankLimit, nextRankLimit, currentXp, updatedXp, currentLevel);
                }
                else
                {
                    BaseScript.TriggerEvent("worldeventsManage.Client:UpdatedLevel", updatedLevel, true); // TO BE UPDATED AS IT DOESN'T EXIST AT THE MOMENT

                    await ShowPlayerRankScoreAfterUpdate(currentRankLimit, nextRankLimit, currentXp, nextRankLimit, currentLevel);
                    await BaseScript.Delay(2000);
                    await ShowPlayerRankScoreAfterUpdate(updatedCurrentRankLimit, updatedNextRankLimit, 0, updatedXp - currentXp, updatedLevel);
                }
                EventDispatcher.Send("tlg:freeroam:salvapersonaggio");
            }
            catch (Exception e)
            {
                ClientMain.Logger.Error(e.ToString());
            }

            await Task.FromResult(0);
        }

        public static async Task ShowPlayerRankScoreAfterUpdate(int currentRankLimit, int nextRankLimit, int playersPreviousXP, int playersCurrentXP, int rank)
        {
            RequestHudScaleform(19);
            while (!HasHudScaleformLoaded(19)) await BaseScript.Delay(0);
            PushScaleformMovieFunctionFromHudComponent(19, "OVERRIDE_ANIMATION_SPEED");
            PushScaleformMovieFunctionParameterInt(2000);
            PopScaleformMovieFunctionVoid();
            PushScaleformMovieFunctionFromHudComponent(19, "SET_COLOUR");
            PushScaleformMovieFunctionParameterInt(116);
            PushScaleformMovieFunctionParameterInt(123);
            PopScaleformMovieFunctionVoid();
            BeginScaleformMovieMethodHudComponent(19, "SET_RANK_SCORES");
            PushScaleformMovieFunctionParameterInt(currentRankLimit);
            PushScaleformMovieFunctionParameterInt(nextRankLimit);
            PushScaleformMovieFunctionParameterInt(playersPreviousXP);
            PushScaleformMovieFunctionParameterInt(playersCurrentXP);
            PushScaleformMovieFunctionParameterInt(rank);
            PopScaleformMovieFunctionVoid();
        }

    }
}
