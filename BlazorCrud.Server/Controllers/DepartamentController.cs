using AutoMapper;
using BlazorCrud.Server.Data;
using BlazorCrud.Server.Utilities.Static;
using BlazorCrud.Shared.Commons.Base;
using BlazorCrud.Shared.Dtos.Departament.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentController : ControllerBase
    {
        private readonly CrudBlazorContext _context;
        private readonly IMapper _mapper;
        public DepartamentController(CrudBlazorContext crudBlazorContext, IMapper mapper)
        {
            _context = crudBlazorContext;
            _mapper = mapper;
        }

        [HttpGet("ListDepartaments")]
        public async Task<IActionResult> ListDepartaments()
        {
            var response = new BaseResponse<List<DepartamentResponseDto>>();

            try
            {
                var departaments = await _context.Departaments.AsNoTracking().ToListAsync();

                if (departaments is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<List<DepartamentResponseDto>>(departaments);
                    response.Message = ReplyMessage.MESSAGE_QUERY;

                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

    }
}

