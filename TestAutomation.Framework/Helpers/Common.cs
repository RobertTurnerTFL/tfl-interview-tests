using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using FluentAssertions;

namespace TestAutomation.Framework.Helpers
{
    public class Common
    {
        public static void compareDataTables(DataTable master, DataTable subset)
        {
            for (int i = 0; i < subset.Rows.Count; i++)
            {
                for (int c = 0; c < subset.Columns.Count; c++)
                {
                    subset.Rows[i][c].ToString().Should().Be(master.Rows[i][c].ToString());
                }
            }
        }

        public static int timeInMins(string Duration)
        {
            if (Duration.Contains("hrs") && Duration.Contains("mins"))
            {
                return int.Parse(Duration.Split("hrs")[0].Trim()) * 60 +
                       int.Parse(Duration.Split("hrs")[1].Split("mins")[0].Trim());
            }
            else if (Duration.Contains("hrs"))
            {
                return (int.Parse(Duration.Split("hrs")[0].Trim()) * 60);
            }
            else if (Duration.Contains("mins"))
            {
                return int.Parse(Duration.Split("mins")[0].Trim());
            }

            return 0;
        }

    }
}
