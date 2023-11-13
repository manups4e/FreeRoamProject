using FreeRoamProject.Shared.TypeExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeRoamProject.Client.Handlers
{
    public class LabelsHandler
    {
        public static List<GameLabel> CustomGameLabels = new List<GameLabel>();

        /// <summary>
        /// Reload all the custom labels into the current Language
        /// </summary>
        /// <param name="jsonLabels"></param>
        /// <returns></returns>
        public static async Task UpdateLanguageLabels(Dictionary<string, string> jsonLabels)
        {
            List<GameLabel> tempList = CustomGameLabels.ToList();
            CustomGameLabels.Clear();
            await tempList.ForEachAsync(async (x) =>
            {
                if (!string.IsNullOrWhiteSpace(x.Name))
                    CustomGameLabels.Add(CreateNewLabel(x.Name, jsonLabels[x.Name]));
                else
                    CustomGameLabels.Add(CreateNewLabelByHash(x.Hash, jsonLabels[x.Hash.ToString("X")]));
            });
        }

        public static string GetLabel(GameLabel label, params LabelArgument[] arguments)
        {
            string lbl = Game.GetGXTEntry(label.Name);
            foreach (LabelArgument argument in arguments)
            {
                switch (argument.Value)
                {
                    case int:
                    case double:
                    case float:
                    case DateTime:
                    case TimeSpan:
                        lbl.ReplaceFirst("~1~", argument.ToString());
                        break;
                    case string:
                    case char:
                    case bool:
                        lbl.ReplaceFirst("~a~", argument.ToString());
                        break;
                    default:
                        throw new ArgumentException(string.Format("Unknown argument type '{0}' passed to label with key {1}...", argument.GetType().Name, label), "arguments");
                }
            }
            return lbl;
        }

        public static GameLabel CreateNewLabel(string labelName, string labelContent)
        {
            AddTextEntry(labelName, labelContent);
            return new GameLabel(labelName);
        }
        public static GameLabel CreateNewLabelByHash(uint hash, string labelContent)
        {
            AddTextEntryByHash(hash, labelContent);
            return new GameLabel(hash);
        }
    }
}
