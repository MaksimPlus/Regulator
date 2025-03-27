using Microsoft.Extensions.DependencyInjection;
using Regulator.Server.Data;

ServiceCollection services = new ServiceCollection();
services.AddDbContext<RegulatorContext>();