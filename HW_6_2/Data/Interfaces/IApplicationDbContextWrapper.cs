﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HW_6_2.Data.Interfaces;

public interface IApplicationDbContextWrapper<out T>
    where T : DbContext
{
    T ApplicationDbContext { get; }
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
}