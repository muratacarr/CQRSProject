﻿namespace API.Core.Domain
{
    public class AppRole
    {
        public int Id { get; set; }
        public string Definition { get; set; } = null!;
        public ICollection<AppUser>? AppUsers { get; set; }
    }
}
