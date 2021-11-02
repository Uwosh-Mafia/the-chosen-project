using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
