using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Entities.hr;
using Core.interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace API.Controllers {
 
    public class HRController : BaseController {
  
       
        private readonly IGenericRepository<Employees> _repoEmployees;
        private readonly IGenericRepository<Holidays> _repProductHolidays;
        private readonly IGenericRepository<Departments> _repoDepartments;
        private readonly IMapper _mapper;

        public HRController (IGenericRepository<Employees> repoEmployees,
            IGenericRepository<Holidays> repProductHolidays,
            IGenericRepository<Departments> repoDepartments,
            IMapper mapper) {
            _repoEmployees = repoEmployees;
            _repProductHolidays = repProductHolidays;
            _repoDepartments = repoDepartments;
            _mapper = mapper;
        }

        [HttpGet("hr")]
        public async Task<ActionResult<IReadOnlyList<Employees>>> GetEmployess()  {
           var spec = new HRWithTypeAndBrandSpecifications(); 

  
           var employeesList= await _repoEmployees.ListAsync(spec);
         var data = _mapper.Map<IReadOnlyList<Employees>,IReadOnlyList<employeesDto>>(employeesList);
           
                      

            return  Ok(data); 
           
             
        }

        [HttpGet ("{id}")]
        [ProducesResponseType((StatusCodes.Status200OK))]
        [ProducesResponseType(typeof(ApiResponse),(StatusCodes.Status404NotFound))]
 
        public async Task<ActionResult<Employees>> GetEmployess (int id) {

            var spec = new HRWithTypeAndBrandSpecifications(id); 
            var hr = await _repoEmployees.GetEntityWithSpec(spec);
            if(hr==null) {
              return NotFound(new ApiResponse(404));
            }

                       var data = _mapper.Map<Employees,employeesDto>(hr);

            return  Ok(data); 
     
        }

         [HttpGet("holidays")]
        public async Task<ActionResult<Holidays>> GetHoliday () {
          var holiday = await _repProductHolidays.ListAllAsync() ;
          return Ok(holiday);
        }
        
          [HttpGet("departments")]
        public async Task<ActionResult<Departments>> GetDepartments () {
          var Departments = await _repoDepartments.ListAllAsync() ;

          return Ok(Departments);
        }
        
    }}