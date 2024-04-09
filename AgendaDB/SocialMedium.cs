using System;
using System.Collections.Generic;

namespace Amiar_Agenda.AgendaDB;

public partial class SocialMedium
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public virtual ICollection<SocialProfil> SocialProfils { get; set; } = new List<SocialProfil>();
}
