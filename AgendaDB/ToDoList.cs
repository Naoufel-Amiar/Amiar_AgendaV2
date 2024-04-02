using System;
using System.Collections.Generic;

namespace Amiar_Agenda.AgendaDB;

public partial class ToDoList
{
    public int Id { get; set; }

    public string Titre { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateOnly Date { get; set; }

    public DateOnly EndDate { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
