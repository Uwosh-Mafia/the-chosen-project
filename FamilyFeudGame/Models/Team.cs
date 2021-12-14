using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Built by Ryan Schauer
/// This is the team class and it will store point totals, their name, and if they're the playing team. 
/// </summary>
namespace FamilyFeudGame.Models
{
    public class Team
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public bool IsPlaying { get; set; }

        public Team(string name, bool isPlaying)
        {
            Name = name;
            IsPlaying = isPlaying;
            Points = 0;
        }

        /// <summary>
        /// This will add points to the team class.
        /// </summary>
        /// <param name="addPoints"></param>
        public void AddPoints(int addPoints)
        {
            Points += addPoints;
        }

        /// <summary>
        /// This will return the total points earned.
        /// </summary>
        /// <returns></returns>
        public int GetPoints()
        {
            return Points;
        }
    }


}
