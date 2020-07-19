﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeXieCheng.API.Dtos;
using FakeXieCheng.API.Models;
using FakeXieCheng.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace FakeXieCheng.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TouristRoutesController : ControllerBase
    {
        private ITouristRouteRepository _touristRouteRepository;

        public readonly IMapper _mapper;
        public TouristRoutesController(ITouristRouteRepository touristRouteRepository,IMapper mapper)
        {
            _touristRouteRepository = touristRouteRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetTouristRoutes()
        {
            var touristRoutesFromRepo = _touristRouteRepository.GetTouristRoutes();
            if (touristRoutesFromRepo == null || touristRoutesFromRepo.Count() <= 0)
            {
                return NotFound("没有旅游路线");
            }
            var touristRouteDto = _mapper.Map<IEnumerable<TouristRoute>>(touristRoutesFromRepo);
            return Ok(touristRoutesFromRepo);
        }

        [HttpGet("{touristRouteId}")]
        public IActionResult GetTouristRouteById(Guid touristRouteId)
        {
            var touristRouteFromRepo = _touristRouteRepository.GetTouristRoute(touristRouteId);
            if (touristRouteFromRepo==null)
            {
                return NotFound($"未找到路线");
            }
            //decimal price = 0;
            //if (touristRouteFromRepo.DiscountPresent != null)
            //{

            //    price = touristRouteFromRepo.OriginalPrice * (decimal)touristRouteFromRepo.DiscountPresent;
            //}
            //else
            //{
            //    price = touristRouteFromRepo.OriginalPrice * 1;
            //}
            //ToutistRouteDto toutistRouteDto = new ToutistRouteDto()
            //{ 
            //    Id=touristRouteFromRepo.Id,
            //    Title=touristRouteFromRepo.Title,
            //    Description=touristRouteFromRepo.Description,
            //    Price = price,
            //    CreateTime=touristRouteFromRepo.CreateTime,
            //    UpdateTime=touristRouteFromRepo.UpdateTime,
            //    Features=touristRouteFromRepo.Features,
            //    Fees=touristRouteFromRepo.Fees,
            //    Notes=touristRouteFromRepo.Notes,
            //    Rating=touristRouteFromRepo.Rating,
            //    TravelDays=touristRouteFromRepo.TravelDays.ToString(),
            //    TripType=touristRouteFromRepo.TripType.ToString(),
            //    DepartureCity=touristRouteFromRepo.DepartureCity.ToString()

            //};
            var touristRouteDto = _mapper.Map<ToutistRouteDto>(touristRouteFromRepo);
            return Ok(touristRouteDto);
        }
    }
}
