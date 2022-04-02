﻿namespace NorthWind.Core.Interfaces
{
    public interface ICurrentUserService
    {
        int UserId { get; }
        string UserName { get; }
        bool IsAuthenticated { get; }
    }
}