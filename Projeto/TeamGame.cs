//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projeto
{
    using System;
    using System.Collections.Generic;
    
    public partial class TeamGame : Game
    {
        public int TeamTournamentId { get; set; }
        public Nullable<int> TeamId1 { get; set; }
        public Nullable<int> TeamId2 { get; set; }
    
        public virtual TeamTournament Tournament { get; set; }
        public virtual Team Team1 { get; set; }
        public virtual Team Team2 { get; set; }
    }
}
