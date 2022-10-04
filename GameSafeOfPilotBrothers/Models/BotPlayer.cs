using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSafeOfPilotBrothers.Models
{
    internal class BotPlayer
    {
        public Safe Safe { get; set; }
        public BotPlayer(Safe safe)
        {
            Safe = safe;
        }

        public Dictionary<int, Safe>GetDictionary()
        {
            Dictionary<int, Safe> dict = new Dictionary<int, Safe>();
            Dictionary<int,int> dictionary = new Dictionary<int, int>();
            dict[SafeToInt(Safe)] = Safe;
            for (int i = 0; i < 100; i++)
            {
                var dictForeach = new Dictionary<int, Safe>();
                
                foreach (var safeForeach in dict.Values)
                {
                    dictForeach[SafeToInt(safeForeach)] = safeForeach;
                    for (int j = 0; j < Safe.NumberHandlesInRow; j++)
                    {
                        for (int k = 0; k < Safe.NumberHandlesInRow; k++)
                        {
                            var sa = (Safe) safeForeach.Clone();
                            sa.TurnHandle(new PositionInLock(j,k));
                            int intFromSafe = SafeToInt(sa);
                            dictForeach[intFromSafe] = sa;
                            if (!dictionary.ContainsKey(intFromSafe))
                            {
                                dictionary[intFromSafe] = 0;
                            }

                            dictionary[intFromSafe] += 1;
                        }
                    }
                }

                if (dict.Count == dictForeach.Count)
                {
                    break;
                }
                dict = dictForeach;
            }
            dictionary = dictionary.OrderBy(a => a.Key).ToDictionary(a => a.Key, a => a.Value);
            dict = dict.OrderBy(a => a.Key).ToDictionary(a=>a.Key,a=> a.Value);
            return dict;
        }

        public int SafeToInt(Safe safe)
        {
            int s=0;
            for (int i = 0; i < safe.NumberHandlesInRow; i++)
            {
                for (int j = 0; j < safe.NumberHandlesInRow; j++)
                {
                    if (safe.HandleLock[i][j])
                    {
                        s +=(int) Math.Pow(2, j + i * safe.NumberHandlesInRow);
                    }
                }
            }

            return s;
        }
    }
}
