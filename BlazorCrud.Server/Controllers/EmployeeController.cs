using AutoMapper;
using BlazorCrud.Server.Data;
using BlazorCrud.Server.Models;
using BlazorCrud.Server.Utilities.Static;
using BlazorCrud.Shared.Commons.Base;
using BlazorCrud.Shared.Dtos.Departament.Response;
using BlazorCrud.Shared.Dtos.Employee.Request;
using BlazorCrud.Shared.Dtos.Employee.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly CrudBlazorContext _context;
        private readonly IMapper _mapper;

        public EmployeeController(CrudBlazorContext crudBlazorContext, IMapper mapper)
        {
            _context = crudBlazorContext;
            _mapper = mapper;
        }

        [HttpGet("ListEmployees")]
        public async Task<IActionResult> ListEmployees()
        {
            var response = new BaseResponse<List<EmployeeResponseDto>>();

            try
            {
                var employees = await _context.Employees.Include(x => x.Departament).AsNoTracking().ToListAsync();

                if (employees is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<List<EmployeeResponseDto>>(employees);
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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var response = new BaseResponse<EmployeeResponseDto>();

            try
            {
                var employees = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.EmployeeId.Equals(id));


                if (employees is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<EmployeeResponseDto>(employees);
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

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterEmployee([FromForm] EmployeeRequestDto requestDto)
        {
            var response = new BaseResponse<int>();

            try
            {
                var employee = _mapper.Map<Employee>(requestDto);
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();

                if (employee.EmployeeId != 0)
                {
                    response.IsSuccess = true;
                    response.Data = employee.EmployeeId;
                    response.Message += ReplyMessage.MESSAGE_SAVE;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_FAILED;
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);

        }

        [HttpPut("Edit/{id:int}")]
        public async Task<IActionResult> EditEmployee(EmployeeRequestDto requestDto, int id)
        {
            var response = new BaseResponse<int>();

            try
            {
                var editEmployee = await GetEmployeeById(id);

                if (editEmployee is not null)
                {
                    var employee = _mapper.Map<Employee>(requestDto);
                    employee.EmployeeId = id;
                    _context.Employees.Update(employee);
                    await _context.SaveChangesAsync();

                    response.IsSuccess = true;
                    response.Data = employee.EmployeeId;
                    response.Message = ReplyMessage.MESSAGE_UPDATE;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_FAILED;
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var response = new BaseResponse<int>();

            try
            {
                var employee = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.EmployeeId.Equals(id));

                if (employee is not null)
                {
                    _context.Employees.Remove(employee);
                    await _context.SaveChangesAsync();

                    response.IsSuccess = true;
                    response.Message = ReplyMessage.MESSAGE_DELETE;
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = ReplyMessage.MESSAGE_FAILED;
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
