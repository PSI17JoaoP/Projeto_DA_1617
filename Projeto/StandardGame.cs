//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projeto
{
    using System;
    using System.Collections.Generic;
    
    public partial class StandardGame : Game
    {
        public int StandardTournamentId { get; set; }
        public Nullable<int> PlayerId1 { get; set; }
        public Nullable<int> PlayerId2 { get; set; }
    
        public virtual StandardTournament Tournament { get; set; }
        public virtual Player Player1 { get; set; }
        public virtual Player Player2 { get; set; }
    }
}
