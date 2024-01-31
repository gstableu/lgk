using AutoMapper;
using LGK.Geckos.Models;
using LGK.Geckos.ViewModels;
using MethodTimer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace LGK.Geckos.Controllers;


[ApiController]
[Route("[controller]")]
public class GeckoController : ControllerBase
{
    private readonly ILogger<GeckoController> _logger;
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GeckoController(ILogger<GeckoController> logger, ApplicationDbContext dbContext, IMapper mapper)
    {
        _logger = logger;
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [Time]
    [HttpGet]
    public IQueryable<GeckoViewModel> Get()
    {
        var data =
                    from x in _dbContext.Gecko
                    from s in _dbContext.Gecko.Where(p => p.Id == x.SireId).DefaultIfEmpty()
                    from d in _dbContext.Gecko.Where(p => p.Id == x.DamId).DefaultIfEmpty()
                    select new GeckoViewModel()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        DamId = d.Id,
                        DamName = d.Name,
                        SireId = s.Id,
                        SireName = s.Name,
                    };
                    
        return data;
    }

    [HttpPost]
    public async Task<Gecko> Add(GeckoViewModel input, CancellationToken cancellationToken)
    {
        var data = await _dbContext.Gecko.FirstOrDefaultAsync(x => x.Id == input.Id, cancellationToken);
        data = _mapper.Map<Gecko>(input);
        if (data.Id == Guid.Empty)
        {
            _dbContext.Gecko.Add(data);
        }
        await _dbContext.SaveChangesAsync(cancellationToken);
        return data;
    }

}