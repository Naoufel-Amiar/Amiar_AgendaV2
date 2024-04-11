using System;
using System.Collections.Generic;

namespace Amiar_Agenda.AgendaDB;

public partial class SocialMedium
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public int ContactId { get; set; }

    public virtual Contact Contact { get; set; } = null!;
}
