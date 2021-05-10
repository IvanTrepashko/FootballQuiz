﻿using System;
using System.ComponentModel.DataAnnotations;

namespace RepositoryContracts.Models
{
    public class User
    {
        [Key]
        public string UserID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}