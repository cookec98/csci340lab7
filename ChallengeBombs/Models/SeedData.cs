using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChallengeBombs.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeBombs.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ChallengeBombsContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ChallengeBombsContext>>()))
            {
                if (context.Bomb.Any())
                {
                    return;
                }

                context.Bomb.AddRange(
                    new Bomb
                    {
                        Name = "Sky Enigma",
                        Time = 100,
                        Modules = 47,
                        Difficulty = "Medium",
                        Pack = "Tach's 47 Missions",
                        Hardest = "Bamboozling Button, Ten-Button Color Code"
                    },
                    new Bomb
                    {
                        Name = "Never Gonna Blown Your Brain Up",
                        Time = 300,
                        Modules = 47,
                        Difficulty = "Hard",
                        Pack = "Tach's 47 Missions",
                        Hardest = "Mazeswapper"
                    },
                    new Bomb
                    {
                        Name = "Galaxy Collapse",
                        Time = 120,
                        Modules = 55,
                        Difficulty = "Very Hard",
                        Pack = "Tach's Parody Missions",
                        Hardest = "Collapse, Mislocation, Kugelblitz"
                    },
                    new Bomb
                    {
                        Name = "Best Cipher Contest",
                        Time = 600,
                        Modules = 48,
                        Difficulty = "Easy",
                        Pack = "OSA and XP4 Heroes Missions",
                        Hardest = "Bamboozling Button, Ten-Button Color Code"
                    },
                    new Bomb
                    {
                        Name = "The Tachturion (Hard)",
                        Time = 160,
                        Modules = 101,
                        Difficulty = "Hard",
                        Pack = "OSA and XP4 Heroes Missions",
                        Hardest = "Forget Everything, Forget Them All"
                    }
                    );
            }
        }
    }
}


