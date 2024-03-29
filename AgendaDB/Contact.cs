using System;
using System.Collections.Generic;

namespace Amiar_Agenda.AgendaDB;

public partial class Contact
{
    public int Id { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public DateOnly Birth { get; set; }

    public string Sex { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public string Tel { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual ICollection<SocialProfil> SocialProfils { get; set; } = new List<SocialProfil>();
}
