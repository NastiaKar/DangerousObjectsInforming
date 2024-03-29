﻿using System.Security.Cryptography;
using DangerousObjectsBLL.Services.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;

namespace DangerousObjectsBLL.Services;

public class PasswordHasher : IPasswordHasher
{
    public string GenerateSalt() => Convert.ToBase64String(RandomNumberGenerator.GetBytes(8));

    public string HashPassword(string password, string salt)
    {
        byte[] saltBytes = Convert.FromBase64String(salt);
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: saltBytes,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 32));
    }
}