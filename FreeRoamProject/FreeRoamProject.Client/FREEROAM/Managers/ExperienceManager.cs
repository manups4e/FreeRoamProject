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

        public static void StayOnScreenPlayerRank()
        {
            PushScaleformMovieFunctionFromHudComponent(19, "SHOW");
            PopScaleformMovieFunctionVoid();
        }

        public static async Task ShowPlayerRank(bool show)
        {
            if (!show)
            {
                PushScaleformMovieFunctionFromHudComponent(19, "HIDE");
                PopScaleformMovieFunctionVoid();
            }
            else
            {
                PushScaleformMovieFunctionFromHudComponent(19, "SHOW");
                PopScaleformMovieFunctionVoid();
            }

            if (HasHudScaleformLoaded(19)) return;
            RequestHudScaleform(19);
            while (!HasHudScaleformLoaded(19)) await BaseScript.Delay(0);
            int rank = Cache.PlayerCache.MyPlayer.User.Character.Level;
            int xp = Cache.PlayerCache.MyPlayer.User.Character.TotalXp;
            int nowMaxXp = Experience.RankRequirement[rank];
            int maxXp = Experience.NextLevelExperiencePoints(rank);
            PushScaleformMovieFunctionFromHudComponent(19, "SET_COLOUR");
            PushScaleformMovieFunctionParameterInt(116);
            PushScaleformMovieFunctionParameterInt(123);
            PopScaleformMovieFunctionVoid();
            BeginScaleformMovieMethodHudComponent(19, "SET_RANK_SCORES");
            PushScaleformMovieFunctionParameterInt(nowMaxXp);
            PushScaleformMovieFunctionParameterInt(maxXp);
            PushScaleformMovieFunctionParameterInt(xp);
            PushScaleformMovieFunctionParameterInt(xp);
            PushScaleformMovieFunctionParameterInt(rank);
            PopScaleformMovieFunctionVoid();
            PushScaleformMovieFunctionFromHudComponent(19, "STAY_ON_SCREEN");
            PopScaleformMovieFunctionVoid();
        }

        public static async Task ShowFinishScaleform(bool lost = true)
        {
            Scaleform bg = new("MP_CELEBRATION_BG");
            Scaleform fg = new("MP_CELEBRATION_FG");
            Scaleform cb = new("MP_CELEBRATION");
            RequestScaleformMovie("MP_CELEBRATION_BG");
            RequestScaleformMovie("MP_CELEBRATION_FG");
            RequestScaleformMovie("MP_CELEBRATION");
            while (!bg.IsLoaded || !fg.IsLoaded || !cb.IsLoaded) await BaseScript.Delay(0);

            // Setting up colors.
            bg.CallFunction("CREATE_STAT_WALL", "ch", "HUD_COLOUR_BLACK", -1);
            fg.CallFunction("CREATE_STAT_WALL", "ch", "HUD_COLOUR_RED", -1);
            cb.CallFunction("CREATE_STAT_WALL", "ch", "HUD_COLOUR_BLUE", -1);

            // Setting up pause duration.
            bg.CallFunction("SET_PAUSE_DURATION", 3.0f);
            fg.CallFunction("SET_PAUSE_DURATION", 3.0f);
            cb.CallFunction("SET_PAUSE_DURATION", 3.0f);

            //bool won = new Random().Next(0, 2) == 0;
            //bool won = true;
            string win_lose = lost ? "CELEB_LOSER" : "CELEB_WINNER";
            bg.CallFunction("ADD_WINNER_TO_WALL", "ch", win_lose, GetPlayerName(PlayerId()), "", 0, false, "", false);
            fg.CallFunction("ADD_WINNER_TO_WALL", "ch", win_lose, GetPlayerName(PlayerId()), "", 0, false, "", false);
            cb.CallFunction("ADD_WINNER_TO_WALL", "ch", win_lose, GetPlayerName(PlayerId()), "", 0, false, "", false);

            // Setting up background.
            bg.CallFunction("ADD_BACKGROUND_TO_WALL", "ch");
            fg.CallFunction("ADD_BACKGROUND_TO_WALL", "ch");
            cb.CallFunction("ADD_BACKGROUND_TO_WALL", "ch");

            // Preparing to show the wall.
            bg.CallFunction("SHOW_STAT_WALL", "ch");
            fg.CallFunction("SHOW_STAT_WALL", "ch");
            cb.CallFunction("SHOW_STAT_WALL", "ch");

            // Drawing the wall on screen for 3 seconds + 1 seconds (for outro animation druation).
            int timer = GetGameTimer();

            //DisableDrawing = true;
            while (GetGameTimer() - timer <= 3000 + 1000)
            {
                await BaseScript.Delay(0);
                DrawScaleformMovieFullscreenMasked(bg.Handle, fg.Handle, 255, 255, 255, 255);
                DrawScaleformMovieFullscreen(cb.Handle, 255, 255, 255, 255, 0);
                HideHudAndRadarThisFrame();
            }
            //DisableDrawing = false;

            // Playing effect when it's over.
            StartScreenEffect("MinigameEndNeutral", 0, false);
            PlaySoundFrontend(-1, "SCREEN_FLASH", "CELEBRATION_SOUNDSET", false);

            // Cleaning up.
            bg.CallFunction("CLEANUP");
            fg.CallFunction("CLEANUP");
            cb.CallFunction("CLEANUP");
            bg.Dispose();
            fg.Dispose();
            cb.Dispose();
            //GameController.gameRestarting = false;
            //GameController.Go();
        }
    }
}
