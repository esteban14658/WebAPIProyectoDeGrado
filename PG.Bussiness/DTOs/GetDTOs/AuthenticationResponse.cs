﻿using System;

namespace PG.Bussiness.DTOs.GetDTOs
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
