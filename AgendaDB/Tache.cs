using System;
using System.Collections.Generic;

namespace Amiar_Agenda.AgendaDB;

public partial class Tache
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ToDoListId { get; set; }

    public string Etat { get; set; } = null!;

    public virtual ToDoList ToDoList { get; set; } = null!;
}
