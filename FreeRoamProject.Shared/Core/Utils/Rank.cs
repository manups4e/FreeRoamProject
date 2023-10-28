using System;
using System.Collections.Generic;

namespace FreeRoamProject.Shared
{

    public class Rank
    {
        private readonly int _a = 25;
        private readonly int _b = 23575;
        private readonly int _c = -1023150;
        private readonly int _x = (int)Math.Floor(-23575 / 50f);
        // each rank is 800 units.. a better solution to check for level upgrading is to simply check "value % 800 == 0"
        private List<int> Ranks = new List<int>()
        {
            0,
            800,
            2100,
            3800,
            6100,
            9500,
            12500,
            16000,
            19800,
            24000, // 10
			28500,
            33400,
            38700,
            44200,
            50200,
            56400,
            63000,
            69900,
            77100,
            84700, // 20
			92500,
            100700,
            109200,
            118000,
            127100,
            136500,
            146200,
            156200,
            166500,
            177100, // 30
			188000,
            199200,
            210700,
            222400,
            234500,
            246800,
            259400,
            272300,
            285500,
            299000, // 40
			312700,
            326800,
            341000,
            355600,
            370500,
            385600,
            401000,
            416600,
            432600,
            448800, // 50
			465200,
            482000,
            499000,
            516300,
            533800,
            551600,
            569600,
            588000,
            606500,
            625400, // 60
			644500,
            663800,
            683400,
            703300,
            723400,
            743800,
            764500,
            785400,
            806500,
            827900, // 70
			849600,
            871500,
            893600,
            916000,
            938700,
            961600,
            984700,
            1008100,
            1031800,
            1055700, // 80
			1079800,
            1104200,
            1128800,
            1153700,
            1178800,
            1204200,
            1229800,
            1255600,
            1281700,
            1308100, //90
			1334600,
            1361400,
            1388500,
            1415800,
            1443300,
            1471100,
            1499100,
            1527300,
            1555800,
            1584350, // 100
		};
        public int CalculateRank(int exp)
        {
            if (exp == 0)
                return 1;
            for (int i = 2; i < Ranks.Count; i++)
                if (exp == Ranks[i])
                    return i;
                else if (exp < Ranks[i])
                    return i - 1;

            int d = _b ^ 2 - 4 * _a * (_c - exp);
            if (d == 0)
                return _x;
            if (d > 0)
                return (int)Math.Floor((float)Math.Max(-_b + ((float)Math.Sqrt(d) / (2 * _a)), -_b - ((float)Math.Sqrt(d) / (2 * _a))));
            return 0;
        }

        public int GetRequiredExperience(int rank)
        {
            if (rank <= Ranks.Count)
                return Ranks[rank];
            else
                return -_a * rank ^ 2 + _b * rank + _c;
        }

    }
}