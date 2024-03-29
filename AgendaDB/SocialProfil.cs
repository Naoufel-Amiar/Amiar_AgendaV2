using System;
using System.Collections.Generic;

namespace Amiar_Agenda.AgendaDB;

public partial class SocialProfil
{
    public int Id { get; set; }

    public int ContactId { get; set; }

    public int SocialMediaId { get; set; }

    public virtual Contact Contact { get; set; } = null!;

    public virtual SocialMedium SocialMedia { get; set; } = null!;
}
