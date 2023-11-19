﻿namespace Api.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; }
}
