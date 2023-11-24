using Microsoft.EntityFrameworkCore;

namespace Ardalis.EFCore.Extensions;

public static class DbContextExtensions
{
    /// <summary>
    /// Enable Tracking for DbContext
    /// </summary>
    /// <param name="dbContext"></param>
    public static void EnableTracking(this DbContext dbContext)
    {
        dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
    }

    /// <summary>
    /// Enable Tracking for DbContext
    /// </summary>
    /// <param name="dbContext"></param>
    public static void DisableTracking(this DbContext dbContext)
    {
        dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }
}
