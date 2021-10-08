﻿using System;
using NorthWindProject.Application.Entities.User;

namespace NorthWindProject.Application.Entities
{
    public abstract class Metadata
    {
        public DateTime TimeCreated { get; set; } = new DateTime();
        public int UserCreatedId { get; set; }
        public ApplicationUser UserCreated { get; set; }
    }
}