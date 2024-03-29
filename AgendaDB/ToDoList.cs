using System;
using System.Collections.Generic;

namespace Amiar_Agenda.AgendaDB;

public partial class ToDoList
{
    public int Id { get; set; }

    public string Titre { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Date { get; set; } = null!;

    public string EndDate { get; set; } = null!;

    public string Mask { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
