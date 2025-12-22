using Erledigt.Api.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Erledigt.Api.Data;

public class ErledigtDbContext(DbContextOptions<ErledigtDbContext> options)
    : IdentityDbContext<ApplicationUser>(options) { }

