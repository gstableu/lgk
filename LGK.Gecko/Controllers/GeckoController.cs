using AutoMapper;
using LGK.Geckos.Models;
using LGK.Geckos.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    [HttpGet]
    public IQueryable<Gecko> Get()
    {
        return _dbContext.Gecko;
    }

    [HttpPost]
    public async Task<Gecko> Add(GeckoViewModel input, CancellationToken cancellationToken)
    {
        var data = await _dbContext.Gecko.FirstOrDefaultAsync(x => x.Id == input.Id, cancellationToken);
        data = _mapper.Map<Gecko>(input);
        if (data == null)
        {
            _dbContext.Gecko.Add(data);
        }
        await _dbContext.SaveChangesAsync(cancellationToken);
        return data;
    }

}