using AutoMapper;
using Ayda.Ecommerce.App.Contract.IRepository;
using Ayda.Ecommerce.Data.DataContext;
using Ayda.Ecommerce.ShareModels.BaseModel;
using Ayda.Ecommerce.ShareModels.Slider;
using Microsoft.EntityFrameworkCore;

namespace Ayda.Ecommerce.App.Services.Repository;

public class PossitionRepository : IPossitionRepository {
    private readonly DataBaseContext _db;
    private IMapper _mapper;

    public PossitionRepository(DataBaseContext db, IMapper mapper) {
        _db = db;
        _mapper = mapper;
    }

    public async Task<ResultDto<IEnumerable<PossitionDto>>> GetPossitionAsync() {
        var possitions = await _db.Possitions.ToListAsync();
        return new ResultDto<IEnumerable<PossitionDto>> {
            Data = _mapper.Map<IEnumerable<PossitionDto>>(possitions),
            IsSuccess = true
        };
    }
}